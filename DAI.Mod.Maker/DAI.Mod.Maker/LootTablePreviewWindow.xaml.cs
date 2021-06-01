using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.ModMaker.Utilities;

namespace DAI.ModMaker {
    public partial class LootTablePreviewWindow : Window, IComponentConnector {
        private LootTableObject LootTable;

        private LootTableReference SelectedLootTableReference;

        private LootTableItem SelectedLootObject;

        private EbxRef Asset;

        private List<object> ObjectsToProcess;

        private AssetContainer _Container;

        public LootTablePreviewWindow(AssetContainer container, LootTableObject InLootTable, EbxRef InAsset) {
            InitializeComponent();
            LootTable = InLootTable;
            Asset = InAsset;
            _Container = container;
            LootTableNameText.Text = LootTable.Name;
            LootTableChanceSlider.Value = LootTable.ChanceOfNoItems * 100f;
            LootTableItemProbComboBox.SelectedIndex = (int)LootTable.ItemProbability;
            LootTableGoldProbComboBox.SelectedIndex = (int)LootTable.GoldProbability;
            LootTableGoldQuantityTextBox.Text = LootTable.GoldQuantity.ToString();
            LootTableTotalWeightItemsText.Text = LootTable.TotalWeightFromItems.ToString();
            LootTableTotalWeightReferencesText.Text = LootTable.TotalWeightFromReferencedTables.ToString();
            for (int i = 0; i < LootTable.ReferencedTables.Count; i++) {
                ReferencedTablesListBox.Items.Add("Referenced Table #" + (i + 1));
            }
            for (int j = 0; j < LootTable.LootTableItems.Count; j++) {
                LootObjectsListBox.Items.Add("Loot Object #" + (j + 1));
            }
            ObjectsToProcess = new List<object>();
        }

        private void AddLootObjectButton_Click(object sender, RoutedEventArgs e) {
            LootTableItem lootTableItem = new LootTableItem {
                Id = new ExternalGuid(Asset.FileGuid, Guid.NewGuid()),
                MinQuantity = 1,
                MaxQuantity = 1
            };
            LootTable.LootTableItems.Add(new ExternalObject<LootTableItem>(lootTableItem.Id, lootTableItem));
            LootObjectsListBox.Items.Add("Loot Object #" + LootTable.LootTableItems.Count);
            LootObjectsListBox.SelectedIndex = LootObjectsListBox.Items.Count - 1;
        }

        private void AddReferenceTableButton_Click(object sender, RoutedEventArgs e) {
            LootTableReference lootTableReference = new LootTableReference {
                Id = new ExternalGuid(Asset.FileGuid, Guid.NewGuid()),
                WeightMultiplier = -1f
            };
            LootTable.ReferencedTables.Add(new ExternalObject<LootTableReference>(lootTableReference.Id, lootTableReference));
            ReferencedTablesListBox.Items.Add("Referenced Table #" + LootTable.ReferencedTables.Count);
            ReferencedTablesListBox.SelectedIndex = ReferencedTablesListBox.Items.Count - 1;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            List<EbxRef> ebxAssets = new List<EbxRef>();
            foreach (SubBundleRef sb in from x in Library.GetAllSubBundles()
                                        where x.Contains(Asset)
                                        select x) {
                ebxAssets.AddRange(sb.GetSbEbx());
            }
            new ReferenceSearchWindow().ShowDialog(Asset, ebxAssets.Distinct().ToList());
        }

        private ExternalGuid GetExternalGuidFromEbx(EbxRef InAsset) {
            if (InAsset == null) {
                return null;
            }
            EbxBase dAIEbx = EbxBase.FromEbx(InAsset);
            return new ExternalGuid(dAIEbx.FileGuid, dAIEbx.Instances.Keys.ElementAt(0));
        }

        private void LootObjectsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            UpdateObjects();
            if (LootObjectsListBox.SelectedIndex == -1) {
                LootObjectAssetPicker.AssignedAsset = null;
                LootObjectMinQuantityText.Text = "";
                LootObjectMaxQuantityText.Text = "";
                LootObjectMaxPerAreaText.Text = "";
                LootObjectWeightText.Text = "";
            } else {
                SelectedLootObject = LootTable.LootTableItems[LootObjectsListBox.SelectedIndex].GetObject(_Container);
                EbxRef ebx = (LootObjectAssetPicker.AssignedAsset = ((SelectedLootObject.ItemAsset == null) ? null : Library.GetEbxByGuid(SelectedLootObject.ItemAsset.Id.FileGuid)));
                LootObjectMinQuantityText.Text = SelectedLootObject.MinQuantity.ToString();
                LootObjectMaxQuantityText.Text = SelectedLootObject.MaxQuantity.ToString();
                LootObjectMaxPerAreaText.Text = SelectedLootObject.MaxQuantity.ToString();
                LootObjectWeightText.Text = SelectedLootObject.Weight.ToString();
            }
        }

        private void RecursiveTypeScan(Type CurrentType, object CurrentObj, ref EbxBase EbxFile, ref MemoryStream CurrentStream) {
        }

        private void ReferencedTablesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (ReferencedTablesListBox.SelectedIndex == -1) {
                ReferencedTableAssetPicker.AssignedAsset = null;
                ReferencedTableWeightText.Text = "";
                ReferencedTableWeightMultText.Text = "";
            } else {
                SelectedLootTableReference = LootTable.ReferencedTables[ReferencedTablesListBox.SelectedIndex].GetObject(_Container);
                EbxRef ebx = (ReferencedTableAssetPicker.AssignedAsset = ((SelectedLootTableReference.LootTable == null) ? null : Library.GetEbxByGuid(SelectedLootTableReference.LootTable.Id.FileGuid)));
                ReferencedTableWeightText.Text = SelectedLootTableReference.Weight.ToString("F3");
                ReferencedTableWeightMultText.Text = SelectedLootTableReference.WeightMultiplier.ToString("F3");
            }
        }

        private void RemoveLootObjectButton_Click(object sender, RoutedEventArgs e) {
            if (LootObjectsListBox.SelectedIndex != -1) {
                int selectedIndex = LootObjectsListBox.SelectedIndex;
                SelectedLootObject = null;
                LootObjectsListBox.Items.RemoveAt(selectedIndex);
                LootTable.LootTableItems.RemoveAt(selectedIndex);
            }
        }

        private void RemoveReferenceTableButton_Click(object sender, RoutedEventArgs e) {
            if (ReferencedTablesListBox.SelectedIndex != -1) {
                int selectedIndex = ReferencedTablesListBox.SelectedIndex;
                SelectedLootTableReference = null;
                ReferencedTablesListBox.Items.RemoveAt(selectedIndex);
                LootTable.ReferencedTables.RemoveAt(selectedIndex);
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
        }

        private void UpdateObjects() {
            if (SelectedLootTableReference != null) {
                SelectedLootTableReference.Weight = Convert.ToSingle(ReferencedTableWeightText.Text);
                SelectedLootTableReference.WeightMultiplier = Convert.ToSingle(ReferencedTableWeightMultText.Text);
                SelectedLootTableReference.LootTable = new ExternalObject<LootTableObject>((LootTableObject)EbxBase.FromEbx(ReferencedTableAssetPicker.AssignedAsset).GetContainer().RootObject);
            }
            if (SelectedLootObject != null) {
                BaseItemAsset assetBase = (BaseItemAsset)EbxBase.FromEbx(ReferencedTableAssetPicker.AssignedAsset).GetContainer().RootObject;
                SelectedLootObject.ItemAsset = new ExternalObject<BaseItemAsset>(assetBase.Id, assetBase);
                SelectedLootObject.MinQuantity = Convert.ToInt32(LootObjectMinQuantityText.Text);
                SelectedLootObject.MaxQuantity = Convert.ToInt32(LootObjectMaxQuantityText.Text);
                SelectedLootObject.MaxPerArea = Convert.ToInt32(LootObjectMaxPerAreaText.Text);
                SelectedLootObject.Weight = Convert.ToSingle(LootObjectWeightText.Text);
            }
        }
    }
}
