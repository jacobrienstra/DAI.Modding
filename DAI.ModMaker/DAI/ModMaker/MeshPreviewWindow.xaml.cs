using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.ModMaker.DAIRender;
using DAI.ModMaker.Utilities;

namespace DAI.ModMaker
{
    public partial class MeshPreviewWindow : Window, IComponentConnector
    {
        private MeshRenderScene RenderScene;

        private MyRenderEngine RenderEngine;

        private string[] SupportedAssetTypes = new string[1] { "SkinnedMeshAsset" };

        private bool bMouseDragging;

        private double MouseStartX;

        private double MouseDeltaX;

        private double MouseStartY;

        private double MouseDeltaY;

        public MeshPreviewWindow(Mesh InMesh)
        {
            InitializeComponent();
            RenderScene = new MeshRenderScene();
            RenderEngine = new MyRenderEngine(RenderScene);
            meshRenderControl.RegisterRenderer(RenderEngine);
            if (InMesh != null)
            {
                AddAdditionalMesh(InMesh);
            }
        }

        private void AddAdditionalButton_Click(object sender, RoutedEventArgs e)
        {
            EbxRef selectedAsset = Globals.SelectedAsset;
            if (selectedAsset == null || !SupportedAssetTypes.Contains(selectedAsset.AssetType))
            {
                return;
            }
            AssetContainer container = EbxBase.FromEbx(selectedAsset).GetContainer();
            if (container.IsValid())
            {
                long meshSetResource = 0L;
                if (container.RootObject.GetType() == typeof(SkinnedMeshAsset))
                {
                    meshSetResource = ((SkinnedMeshAsset)container.RootObject).MeshSetResource;
                }
                if (meshSetResource != 0L)
                {
                    ResRef res = Library.GetResByResRid(meshSetResource);
                    AddAdditionalMesh(Mesh.FromRes(res));
                }
            }
        }

        private void AddAdditionalMesh(Mesh InMesh)
        {
            AdditionalMeshesListBox.Items.Add(InMesh.MeshName);
            RemoveAdditionalButton.IsEnabled = true;
            RenderScene.AddMesh(InMesh);
            AdditionalMeshesListBox.SelectedIndex = AdditionalMeshesListBox.Items.Count - 1;
        }

        private void AdditionalMeshesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Mesh item = RenderScene.Meshes[AdditionalMeshesListBox.SelectedIndex];
            SubObjectListBox.Items.Clear();
            foreach (LODSubObject subObject in item.LODLevels[0].SubObjects)
            {
                if (!(subObject.SubObjectName == ""))
                {
                    SubObjectListBox.Items.Add(subObject.SubObjectName);
                }
            }
            MeshVariationComboBox.IsEnabled = true;
            MeshVariationComboBox.Items.Clear();
            List<MeshVariationDatabaseEntry> meshVariations = new List<MeshVariationDatabaseEntry>(Globals.GetMeshVariations(item.MeshNameHash));
            if (meshVariations != null && meshVariations.Count > 0)
            {
                foreach (MeshVariationDatabaseEntry meshVariation in meshVariations)
                {
                    MeshVariationComboBox.Items.Add(meshVariation.VariationAssetNameHash.ToString("X8"));
                }
                MeshVariationComboBox.SelectedIndex = 0;
                if (meshVariations.Count == 1)
                {
                    MeshVariationComboBox.IsEnabled = false;
                }
            }
            SubObjectListBox.SelectedIndex = 0;
        }

        private Texture GetTexture(EbxRef Asset)
        {
            if (Asset != null && Asset.AssetType == "TextureAsset")
            {
                AssetContainer container = EbxBase.FromEbx(Asset).GetContainer();
                if (container.IsValid())
                {
                    long resource = ((TextureAsset)container.RootObject).Resource;
                    if (resource != 0L)
                    {
                        return Texture.FromRes(Library.GetResByResRid(resource));
                    }
                }
            }
            return null;
        }

        private void meshRenderControl_MouseDown(object sender, MouseButtonEventArgs e)
        {
            bMouseDragging = true;
            MouseStartX = e.GetPosition(this).X;
            MouseStartY = e.GetPosition(this).Y;
        }

        private void meshRenderControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (bMouseDragging)
            {
                double x = e.GetPosition(this).X;
                MouseDeltaX = MouseStartX - x;
                MouseStartX = x;
                double y = e.GetPosition(this).Y;
                MouseDeltaY = MouseStartY - y;
                MouseStartY = y;
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    RenderScene.Camera.RotateY((int)(0.0 - MouseDeltaX));
                    RenderScene.Camera.RotateOrtho((int)MouseDeltaY);
                }
            }
        }

        private void meshRenderControl_MouseUp(object sender, MouseButtonEventArgs e)
        {
            bMouseDragging = false;
        }

        private void meshRenderControl_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            double delta = e.Delta;
            RenderScene.Camera.Zoom((int)delta);
        }

        private void MeshVariationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MeshVariationComboBox.SelectedItem == null)
            {
                return;
            }
            Mesh item = RenderScene.Meshes[AdditionalMeshesListBox.SelectedIndex];
            uint num = uint.Parse((string)MeshVariationComboBox.SelectedItem, NumberStyles.HexNumber);
            MeshVariationDatabaseEntry meshVariation = Globals.GetMeshVariation(item.MeshNameHash, num);
            for (int i = 0; i < item.LODLevels[0].SubObjects.Count; i++)
            {
                LODSubObject dAISubObject = item.LODLevels[0].SubObjects[i];
                MeshVariationDatabaseMaterial meshVariationDatabaseMaterial = meshVariation.Materials[dAISubObject.Unknown03];
                if (meshVariationDatabaseMaterial.TextureParameters.Count <= 0)
                {
                    RenderScene.SetMeshDiffuseTexture(AdditionalMeshesListBox.SelectedIndex, i, null);
                    RenderScene.SetMeshNormalTexture(AdditionalMeshesListBox.SelectedIndex, i, null);
                    continue;
                }
                foreach (TextureShaderParameter textureParameter in meshVariationDatabaseMaterial.TextureParameters)
                {
                    EbxRef ebx = Library.GetEbxByGuid(textureParameter.Value.Id.FileGuid);
                    if (!textureParameter.ParameterName.Contains("Diffuse"))
                    {
                        if (textureParameter.ParameterName.Contains("Normal"))
                        {
                            Texture texture = GetTexture(ebx);
                            if (texture != null)
                            {
                                RenderScene.SetMeshNormalTexture(AdditionalMeshesListBox.SelectedIndex, i, texture);
                            }
                        }
                    }
                    else
                    {
                        Texture dAITexture = GetTexture(ebx);
                        if (dAITexture != null)
                        {
                            RenderScene.SetMeshDiffuseTexture(AdditionalMeshesListBox.SelectedIndex, i, dAITexture);
                        }
                    }
                }
            }
        }

        private void SubObjectDiffuseButton_Click(object sender, RoutedEventArgs e)
        {
            Texture texture = GetTexture(Globals.SelectedAsset);
            if (texture != null)
            {
                RenderScene.SetMeshDiffuseTexture(AdditionalMeshesListBox.SelectedIndex, SubObjectListBox.SelectedIndex, texture);
            }
        }

        private void SubObjectHighlightButton_Click(object sender, RoutedEventArgs e)
        {
            RenderScene.SetHighlightedMesh(AdditionalMeshesListBox.SelectedIndex, SubObjectListBox.SelectedIndex);
        }

        private void SubObjectListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (SubObjectListBox.SelectedIndex != -1)
            {
                LODSubObject dAISubObject = RenderScene.Meshes[AdditionalMeshesListBox.SelectedIndex].LODLevels[0].SubObjects[SubObjectListBox.SelectedIndex];
                SubObjectNameTextBlock.Text = dAISubObject.SubObjectName;
            }
        }

        private void SubObjectNormalButton_Click(object sender, RoutedEventArgs e)
        {
            Texture texture = GetTexture(Globals.SelectedAsset);
            if (texture != null)
            {
                RenderScene.SetMeshNormalTexture(AdditionalMeshesListBox.SelectedIndex, SubObjectListBox.SelectedIndex, texture);
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            RenderEngine.Dispose();
        }

        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.W)
            {
                RenderScene.WireframeOverlay = !RenderScene.WireframeOverlay;
            }
        }
    }
}
