using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.FrostbiteAssets.Enums;
using DAI.ModMaker.Properties;
using DAI.ModMaker.Utilities;

namespace DAI.ModMaker
{
	public partial class ConversationPreviewWindow : Window, IComponentConnector
	{
		private AssetContainer _Container;

		public ConversationPreviewWindow(AssetContainer container, Conversation InConversation)
		{
			InitializeComponent();
			_Container = container;
			DAITreeViewItem dAITreeViewItem = new DAITreeViewItem(InConversation)
			{
				Header = "Root"
			};
			dAITreeViewItem.Expanded += TreeViewItem_Expanded;
			dAITreeViewItem.Collapsed += TreeViewItem_Collapsed;
			if (InConversation.ChildNodes.Count > 0)
			{
				dAITreeViewItem.Items.Add(new TreeViewItem());
			}
			ConversationNodes.Items.Add(dAITreeViewItem);
		}

		private void CloseButton_Click(object sender, RoutedEventArgs e)
		{
			Close();
		}

		private void ConversationNodes_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
		{
			if (ConversationNodes.SelectedItem == null)
			{
				return;
			}
			DAITreeViewItem selectedItem = (DAITreeViewItem)ConversationNodes.SelectedItem;
			if (!selectedItem.UserData.GetType().IsSubclassOf(typeof(ConversationTreeNode)))
			{
				return;
			}
			ConversationTreeNode userData = (ConversationTreeNode)selectedItem.UserData;
			ConditionsListBox.Items.Clear();
			ActionsListBox.Items.Clear();
			if (!(userData.GetType() == typeof(ConversationLine)))
			{
				return;
			}
			ConversationLine conversationLine = (ConversationLine)userData;
			ConversationLineTextBlock.Inlines.Clear();
			ConversationLineTextBlock.Inlines.AddRange(DAI.ModMaker.Utilities.Utilities.ConvertStringToInlines(Library.GetStringValue(Settings.Default.Language, (uint)conversationLine.TextReference.String.StringId)));
			ParaphraseText.Text = Library.GetStringValue(Settings.Default.Language, (uint)conversationLine.ParaphraseReference.StringId);
			HoverText.Text = Library.GetStringValue(Settings.Default.Language, (uint)conversationLine.HoverTextReference.StringId);
			EbxRef ebx = ((conversationLine.TextReference.Speaker == null) ? null : Library.GetEbxByGuid(conversationLine.TextReference.Speaker.Id.FileGuid));
			SpeakerText.Text = ((ebx != null) ? ebx.GetDisplayFullName() : "[noone]");
			foreach (PlotConditionReference plotCondition in conversationLine.PlotConditions)
			{
				if (plotCondition.ConditionType != PlotConditionType.PlotConditionType_DefaultCheckBoolean)
				{
					if (plotCondition.ConditionType == PlotConditionType.PlotConditionType_Custom)
					{
						EbxRef ebxByGuid = Library.GetEbxByGuid(plotCondition.ConditionSchematic.Id.FileGuid);
						ItemCollection items = ConditionsListBox.Items;
						string name = ebxByGuid.Name;
						items.Add("Custom: " + name + " == " + plotCondition.DesiredValue);
					}
				}
				else
				{
					string plotFlag = Library.GetPlotFlag(plotCondition.PlotFlagReference.PlotFlagId.Guid);
					ConditionsListBox.Items.Add("CheckBoolean: " + plotFlag + " == " + plotCondition.DesiredValue);
				}
			}
			foreach (PlotActionReference plotAction in conversationLine.PlotActions)
			{
				if (plotAction.ActionType == PlotActionType.PlotActionType_Custom)
				{
					EbxRef ebx2 = Library.GetEbxByGuid(plotAction.ActionSchematic.Id.FileGuid);
					ActionsListBox.Items.Add("Custom: " + ebx2.Name);
				}
				else if (plotAction.ActionType == PlotActionType.PlotActionType_DefaultClearBoolean)
				{
					string str = Library.GetPlotFlag(plotAction.PlotFlagReference.PlotFlagId.Guid);
					ActionsListBox.Items.Add("ClearBoolean: " + str);
				}
				else if (plotAction.ActionType == PlotActionType.PlotActionType_DefaultClearInteger)
				{
					string plotFlag2 = Library.GetPlotFlag(plotAction.PlotFlagReference.PlotFlagId.Guid);
					ActionsListBox.Items.Add("ClearInteger: " + plotFlag2);
				}
				else if (plotAction.ActionType != PlotActionType.PlotActionType_DefaultIncrementInteger)
				{
					if (plotAction.ActionType == PlotActionType.PlotActionType_DefaultSetBoolean)
					{
						string str2 = Library.GetPlotFlag(plotAction.PlotFlagReference.PlotFlagId.Guid);
						ActionsListBox.Items.Add("SetBoolean: " + str2);
					}
				}
				else
				{
					string plotFlag3 = Library.GetPlotFlag(plotAction.PlotFlagReference.PlotFlagId.Guid);
					ActionsListBox.Items.Add("IncrementInteger: " + plotFlag3);
				}
			}
		}

		private DAITreeViewItem ParseConversationNodes(ConversationTreeNode InNode)
		{
			string str = "LINK";
			if (InNode.GetType() == typeof(ConversationLine))
			{
				ConversationLine inNode = (ConversationLine)InNode;
				EbxRef ebx = ((inNode.TextReference.Speaker == null) ? null : Library.GetEbxByGuid(inNode.TextReference.Speaker.Id.FileGuid));
				string stringValue = Library.GetStringValue(Settings.Default.Language, (uint)inNode.TextReference.String.StringId);
				if (stringValue != null && stringValue.Length > 20)
				{
					stringValue = stringValue.Substring(0, 20) + "...";
				}
				str = "[" + ((ebx != null) ? ebx.Name.Substring(ebx.Name.LastIndexOf("/") + 1) : "noone") + "] " + ((stringValue != null) ? stringValue : "null");
			}
			else if (InNode.GetType() == typeof(ConversationLink))
			{
				return ParseConversationNodes(((ConversationLink)InNode).LinkedLine.GetObject(_Container));
			}
			DAITreeViewItem dAITreeViewItem = new DAITreeViewItem(InNode)
			{
				Header = str
			};
			dAITreeViewItem.Expanded += TreeViewItem_Expanded;
			dAITreeViewItem.Collapsed += TreeViewItem_Collapsed;
			if (InNode.ChildNodes.Count > 0)
			{
				dAITreeViewItem.Items.Add(new TreeViewItem());
			}
			return dAITreeViewItem;
		}

		private void TreeViewItem_Collapsed(object sender, RoutedEventArgs e)
		{
			DAITreeViewItem originalSource = (DAITreeViewItem)e.OriginalSource;
			if (originalSource != null)
			{
				bool count = originalSource.Items.Count > 0;
				originalSource.Items.Clear();
				if (count)
				{
					originalSource.Items.Add(new TreeViewItem());
				}
			}
		}

		private void TreeViewItem_Expanded(object sender, RoutedEventArgs e)
		{
			DAITreeViewItem originalSource = (DAITreeViewItem)e.OriginalSource;
			if (originalSource == null)
			{
				return;
			}
			originalSource.Items.Clear();
			List<ConversationTreeNode> childNodes = null;
			if (originalSource.UserData.GetType().IsSubclassOf(typeof(ConversationTreeNode)))
			{
				childNodes = new List<ConversationTreeNode>();
				foreach (ExternalObject<ConversationLine> objs in ((ConversationTreeNode)originalSource.UserData).ChildNodes)
				{
					childNodes.Add(objs.GetObject(_Container));
				}
			}
			else
			{
				Conversation userData = (Conversation)originalSource.UserData;
				if (userData == null)
				{
					return;
				}
				childNodes = new List<ConversationTreeNode>();
				foreach (ExternalObject<ConversationLine> obj in userData.ChildNodes)
				{
					childNodes.Add(obj.GetObject(_Container));
				}
			}
			if (childNodes != null)
			{
				foreach (ConversationTreeNode childNode in childNodes)
				{
					originalSource.Items.Add(ParseConversationNodes(childNode));
				}
			}
			originalSource.IsExpanded = true;
		}
	}
}
