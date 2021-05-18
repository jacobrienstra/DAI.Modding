using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DAI.ModMaker.Themes 
{

    public static class TreeViewItemHelper
    {

        public static readonly DependencyProperty IsEnabledProperty =
            DependencyProperty.RegisterAttached(
                "IsEnabled",
                typeof(bool),
                typeof(TreeViewItemHelper),
                new PropertyMetadata(OnIsEnabledChanged));

        public static bool GetIsEnabled(TreeViewItem treeViewItem)
        {
            return (bool)treeViewItem.GetValue(IsEnabledProperty);
        }

        public static void SetIsEnabled(TreeViewItem treeViewItem, bool value)
        {
            treeViewItem.SetValue(IsEnabledProperty, value);
        }

        private static void OnIsEnabledChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var treeViewItem = (TreeViewItem)d;
            if ((bool)e.NewValue)
            {
                treeViewItem.IsVisibleChanged += OnTreeViewItemIsVisibleChanged;
                if (treeViewItem.IsVisible)
                {
                    UpdateIndentation(treeViewItem);
                }
            }
            else
            {
                treeViewItem.IsVisibleChanged -= OnTreeViewItemIsVisibleChanged;
                treeViewItem.ClearValue(IndentationPropertyKey);
            }
        }

        private static void OnTreeViewItemIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue)
            {
                UpdateIndentation((TreeViewItem)sender);
            }
        }

        public static string GetCollapsedGlyph(TreeViewItem treeViewItem)
        {
            return (string)treeViewItem.GetValue(CollapsedGlyphProperty);
        }

        public static void SetCollapsedGlyph(TreeViewItem treeViewItem, string value)
        {
            treeViewItem.SetValue(CollapsedGlyphProperty, value);
        }

        public static readonly DependencyProperty CollapsedGlyphProperty =
            DependencyProperty.RegisterAttached(
                "CollapsedGlyph",
                typeof(string),
                typeof(TreeViewItemHelper),
                new PropertyMetadata("\uE76C"));

        public static string GetExpandedGlyph(TreeViewItem treeViewItem)
        {
            return (string)treeViewItem.GetValue(ExpandedGlyphProperty);
        }

        public static void SetExpandedGlyph(TreeViewItem treeViewItem, string value)
        {
            treeViewItem.SetValue(ExpandedGlyphProperty, value);
        }

        public static readonly DependencyProperty ExpandedGlyphProperty =
            DependencyProperty.RegisterAttached(
                "ExpandedGlyph",
                typeof(string),
                typeof(TreeViewItemHelper),
                new PropertyMetadata("\uE70D"));

        public static UIElement GetCollapsedIcon(TreeViewItem treeViewItem)
        {
            return (UIElement)treeViewItem.GetValue(CollapsedIconProperty);
        }

        public static void SetCollapsedIcon(TreeViewItem treeViewItem, UIElement value)
        {
            treeViewItem.SetValue(CollapsedIconProperty, value);
        }

        public static readonly DependencyProperty CollapsedIconProperty =
            DependencyProperty.RegisterAttached(
                "CollapsedIcon",
                typeof(UIElement),
                typeof(TreeViewItemHelper));

        public static UIElement GetExpandedIcon(TreeViewItem treeViewItem)
        {
            return (UIElement)treeViewItem.GetValue(ExpandedIconProperty);
        }

        public static void SetExpandedIcon(TreeViewItem treeViewItem, UIElement value)
        {
            treeViewItem.SetValue(ExpandedIconProperty, value);
        }

        public static readonly DependencyProperty ExpandedIconProperty =
            DependencyProperty.RegisterAttached(
                "ExpandedIcon",
                typeof(UIElement),
                typeof(TreeViewItemHelper));

        public static Brush GetGlyphBrush(TreeViewItem treeViewItem)
        {
            return (Brush)treeViewItem.GetValue(GlyphBrushProperty);
        }
        
        public static void SetGlyphBrush(TreeViewItem treeViewItem, Brush value)
        {
            treeViewItem.SetValue(GlyphBrushProperty, value);
        }

        public static readonly DependencyProperty GlyphBrushProperty =
            DependencyProperty.RegisterAttached(
                "GlyphBrush",
                typeof(Brush),
                typeof(TreeViewItemHelper),
                null);

        public static double GetGlyphOpacity(TreeViewItem treeViewItem)
        {
            return (double)treeViewItem.GetValue(GlyphOpacityProperty);
        }

     
        public static void SetGlyphOpacity(TreeViewItem treeViewItem, double value)
        {
            treeViewItem.SetValue(GlyphOpacityProperty, value);
        }

       
        public static readonly DependencyProperty GlyphOpacityProperty =
            DependencyProperty.RegisterAttached(
                "GlyphOpacity",
                typeof(double),
                typeof(TreeViewItemHelper),
                new PropertyMetadata(1.0));

       
        public static double GetGlyphSize(TreeViewItem treeViewItem)
        {
            return (double)treeViewItem.GetValue(GlyphSizeProperty);
        }

    
        public static void SetGlyphSize(TreeViewItem treeViewItem, double value)
        {
            treeViewItem.SetValue(GlyphSizeProperty, value);
        }

    
        public static readonly DependencyProperty GlyphSizeProperty =
            DependencyProperty.RegisterAttached(
                "GlyphSize",
                typeof(double),
                typeof(TreeViewItemHelper),
                new PropertyMetadata(12.0));

        private static readonly DependencyPropertyKey IndentationPropertyKey =
            DependencyProperty.RegisterAttachedReadOnly(
                "Indentation",
                typeof(Thickness),
                typeof(TreeViewItemHelper),
                null);

     
        public static readonly DependencyProperty IndentationProperty =
            IndentationPropertyKey.DependencyProperty;


        public static Thickness GetIndentation(TreeViewItem treeViewItem)
        {
            return (Thickness)treeViewItem.GetValue(IndentationProperty);
        }

        private static void SetIndentation(TreeViewItem treeViewItem, Thickness value)
        {
            treeViewItem.SetValue(IndentationPropertyKey, value);
        }

        private static void UpdateIndentation(TreeViewItem item)
        {
            SetIndentation(item, new Thickness(GetDepth(item) * 16, 0, 0, 0));
        }


        private static int GetDepth(TreeViewItem item)
        {
            int depth = 0;
            while (ItemsControl.ItemsControlFromItemContainer(item) is TreeViewItem parentItem)
            {
                depth++;
                item = parentItem;
            }
            return depth;
        }
    }
}