using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Threading;

using DAI.AssetLibrary;
using DAI.AssetLibrary.Assets.Bases;
using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;
using DAI.ModMaker.DAIRender;
using DAI.ModMaker.Utilities;

using SlimDX;

namespace DAI.ModMaker {
    public partial class LevelDataPreviewWindow : Window, IComponentConnector {
        private LevelRenderScene _RenderScene;

        private MyRenderEngine _RenderEngine;

        private List<LevelLayer> _LevelLayers = new List<LevelLayer>();

        public LevelDataPreviewWindow(AssetContainer data, EbxRef InAsset) {
            InitializeComponent();
            _RenderScene = new LevelRenderScene();
            _RenderEngine = new MyRenderEngine(_RenderScene);
            myRenderControl.RegisterRenderer(_RenderEngine);
            DoLoadMap(data, InAsset);
            _RenderScene.FinializeLevelLoad();
        }

        private void EbxXmlButton_Click(object sender, RoutedEventArgs e) {
            LevelObject selectedItem = (LevelObject)LevelObjectsListBox.SelectedItem;
            EbxRef ebx = Library.GetAllEbx().Find((EbxRef x) => x.Name.ToLower() == selectedItem.Name.ToLower());
            if (ebx != null) {
                new EbxPreviewWindow(EbxBase.FromEbx(ebx)).Show();
            } else {
                MessageBox.Show("Could not find related asset");
            }
        }

        private void HideAllLayersButton_Click(object sender, RoutedEventArgs e) {
            foreach (LevelLayer item in (IEnumerable)LevelLayersListBox.Items) {
                item.SetVisibility(false);
                _RenderScene.SetLayerVisibility(item.Index, false);
            }
            LevelLayersListBox.Items.Refresh();
        }

        private void LevelLayersListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (LevelLayersListBox.SelectedItem != null) {
                LevelLayer selectedItem = (LevelLayer)LevelLayersListBox.SelectedItem;
                selectedItem.SetVisibility(!selectedItem.IsVisible);
                _RenderScene.SetLayerVisibility(selectedItem.Index, selectedItem.IsVisible);
                LevelLayersListBox.Items.Refresh();
            }
        }

        private void LevelLayersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LevelLayersListBox.SelectedItem == null) {
                return;
            }
            LevelLayer selectedItem = (LevelLayer)LevelLayersListBox.SelectedItem;
            LevelSubLayersListBox.Items.Clear();
            foreach (LevelLayer child in selectedItem.Children) {
                LevelSubLayersListBox.Items.Add(child);
            }
            LevelObjectsListBox.Items.Clear();
            foreach (LevelObject @object in selectedItem.Objects) {
                LevelObjectsListBox.Items.Add(@object);
            }
        }

        private void LevelObjectsListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (LevelObjectsListBox.SelectedItem != null) {
                LevelObject selectedItem = (LevelObject)LevelObjectsListBox.SelectedItem;
                _RenderScene.SetCameraPosition(selectedItem.Position);
            }
        }

        private void LevelObjectsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LevelObjectsListBox.SelectedItem == null) {
                EbxXmlButton.IsEnabled = false;
            } else {
                EbxXmlButton.IsEnabled = true;
            }
        }

        private void LevelSubLayersListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e) {
            if (LevelSubLayersListBox.SelectedItem != null) {
                LevelLayer selectedItem = (LevelLayer)LevelSubLayersListBox.SelectedItem;
                selectedItem.SetVisibility(!selectedItem.IsVisible);
                _RenderScene.SetSubLayerVisibility(selectedItem.Parent.Index, selectedItem.Index, selectedItem.IsVisible);
                LevelSubLayersListBox.Items.Refresh();
            }
        }

        private void LevelSubLayersListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (LevelSubLayersListBox.SelectedItem == null) {
                return;
            }
            LevelLayer obj = (LevelLayer)LevelSubLayersListBox.SelectedItem;
            LevelObjectsListBox.Items.Clear();
            foreach (LevelObject @object in obj.Objects) {
                LevelObjectsListBox.Items.Add(@object);
            }
        }

        private void myRenderControl_MouseEnter(object sender, MouseEventArgs e) {
            _RenderScene.HasFocus = true;
        }

        private void myRenderControl_MouseLeave(object sender, MouseEventArgs e) {
            _RenderScene.HasFocus = false;
        }

        private void myRenderControl_MouseMove(object sender, MouseEventArgs e) {
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e) {
            if (SearchTextBox.Text == "") {
                LevelLayersListBox.Items.Clear();
                foreach (LevelLayer levelLayer in _LevelLayers) {
                    LevelLayersListBox.Items.Add(levelLayer);
                }
                return;
            }
            List<LevelLayer> list = _LevelLayers.FindAll(delegate (LevelLayer A) {
                foreach (LevelObject @object in A.Objects) {
                    if (@object.FullName.ToLower().Contains(SearchTextBox.Text.ToLower())) {
                        return true;
                    }
                }
                return false;
            });
            LevelLayersListBox.Items.Clear();
            foreach (LevelLayer levelLayer2 in list) {
                LevelLayersListBox.Items.Add(levelLayer2);
            }
        }

        private void ShowAllLayersButton_Click(object sender, RoutedEventArgs e) {
            foreach (LevelLayer item in (IEnumerable)LevelLayersListBox.Items) {
                item.SetVisibility(true);
                _RenderScene.SetLayerVisibility(item.Index, true);
            }
            LevelLayersListBox.Items.Refresh();
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            _RenderEngine.Dispose();
        }

        private void DoLoadMap(AssetContainer container, EbxRef Asset) {
            if (Asset != null && Asset.AssetType == "LevelData") {
                LevelData levelDatum = ((!container.IsValid()) ? null : ((LevelData)container.RootObject));
                LevelData levelDatum2 = levelDatum;
                if (levelDatum2 == null) {
                    return;
                }
                _ = levelDatum2.Objects.Count;
                int num = 0;
                LevelLayer levelLayer = null;
                myRenderControl.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                    levelLayer = new LevelLayer("Uncategorized", 0);
                    levelLayer.Children.Add(new LevelLayer("Uncategorized", 0, levelLayer));
                    LevelLayersListBox.Items.Add(levelLayer);
                    return null;
                }, null);
                foreach (ExternalObject<GameObjectData> @object in levelDatum2.Objects) {
                    ReadObjectData(container, @object.GetObject(container), Matrix.Identity, levelLayer);
                    num++;
                }
            } else {
                if (Asset == null || !(Asset.AssetType == "SubWorldData")) {
                    return;
                }
                SubWorldData subWorldDatum = ((!container.IsValid()) ? null : ((SubWorldData)container.RootObject));
                if (subWorldDatum == null) {
                    return;
                }
                _ = subWorldDatum.Objects.Count;
                int num2 = 0;
                LevelLayer levelLayer2 = null;
                myRenderControl.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                    string inName = subWorldDatum.Name.Remove(0, subWorldDatum.Name.LastIndexOf('/') + 1);
                    levelLayer2 = new LevelLayer(inName, 0);
                    levelLayer2.Children.Add(new LevelLayer(inName, 0, levelLayer2));
                    LevelLayersListBox.Items.Add(levelLayer2);
                    return null;
                }, null);
                foreach (ExternalObject<GameObjectData> gameObjectDatum in subWorldDatum.Objects) {
                    ReadObjectData(container, gameObjectDatum.GetObject(container), Matrix.Identity, levelLayer2);
                    num2++;
                }
            }
        }

        private void ReadObjectData(AssetContainer RootContainer, GameObjectData ObjectData, Matrix ObjectMatrix, LevelLayer ParentLayer) {
            if (ObjectData == null) {
                return;
            }
            if (ObjectData.GetType().IsSubclassOf(typeof(ReferenceObjectData)) || ObjectData.GetType() == typeof(ReferenceObjectData)) {
                ReferenceObjectData objectData = (ReferenceObjectData)ObjectData;
                if (objectData.Excluded) {
                    return;
                }
                Matrix matrix = RenderUtils.LinearTransformToMatrix(objectData.BlueprintTransform) * ObjectMatrix;
                if (!(objectData.GetType() != typeof(SubWorldReferenceObjectData)) || objectData.GetType().IsSubclassOf(typeof(SubWorldReferenceObjectData))) {
                    int hashCode = ((SubWorldReferenceObjectData)objectData).BundleName.ToLower().GetHashCode();
                    EbxRef ebxAsset = Library.GetAllEbx().Find((EbxRef A) => (A.EntryPath.ToLower() + A.Name.ToLower()).GetHashCode() == hashCode);
                    if (ebxAsset == null) {
                        return;
                    }
                    AssetContainer container = EbxBase.FromEbx(ebxAsset).GetContainer();
                    if (!container.IsValid()) {
                        return;
                    }
                    SubWorldData rootObject = (SubWorldData)container.RootObject;
                    _RenderScene.CreateAndSetLayer(rootObject.Name);
                    LevelLayer levelLayer = null;
                    myRenderControl.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                        levelLayer = new LevelLayer(rootObject.Name.Remove(0, rootObject.Name.LastIndexOf('/') + 1), LevelLayersListBox.Items.Count);
                        LevelLayersListBox.Items.Add(levelLayer);
                        _LevelLayers.Add(levelLayer);
                        return null;
                    }, null);
                    foreach (ExternalObject<GameObjectData> @object in rootObject.Objects) {
                        ReadObjectData(container, @object.GetObject(container), matrix, levelLayer);
                    }
                    return;
                }
                AssetContainer assetContainer = GetAssetContainer(objectData.Blueprint.Id.FileGuid);
                if (!assetContainer.IsValid()) {
                    return;
                }
                if (assetContainer.RootObject.GetType() == typeof(ObjectBlueprint)) {
                    ReadEntityData(((ObjectBlueprint)assetContainer.RootObject).Object.GetObject(assetContainer), matrix);
                } else if (assetContainer.RootObject.GetType() == typeof(SpatialPrefabBlueprint)) {
                    SpatialPrefabBlueprint obj = (SpatialPrefabBlueprint)assetContainer.RootObject;
                    LevelObject levelObject = new LevelObject(obj.Name, matrix);
                    ParentLayer.Objects.Add(levelObject);
                    if (ParentLayer.Parent != null) {
                        ParentLayer.Parent.Objects.Add(levelObject);
                    }
                    foreach (ExternalObject<GameObjectData> gameObjectDatum in obj.Objects) {
                        ReadObjectData(assetContainer, gameObjectDatum.GetObject(assetContainer), matrix, ParentLayer);
                    }
                } else {
                    if (!(assetContainer.RootObject.GetType() == typeof(WorldPartData))) {
                        return;
                    }
                    WorldPartData worldPartDatum = (WorldPartData)assetContainer.RootObject;
                    _RenderScene.CreateAndSetSubLayer(worldPartDatum.Name);
                    LevelLayer levelLayer2 = null;
                    myRenderControl.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                        levelLayer2 = new LevelLayer(worldPartDatum.Name.Remove(0, worldPartDatum.Name.LastIndexOf('/') + 1), ParentLayer.Children.Count, ParentLayer);
                        ParentLayer.Children.Add(levelLayer2);
                        return null;
                    }, null);
                    foreach (ExternalObject<GameObjectData> object2 in worldPartDatum.Objects) {
                        ReadObjectData(assetContainer, object2.GetObject(assetContainer), matrix, levelLayer2);
                    }
                }
            } else {
                if (!(ObjectData.GetType() == typeof(StaticModelGroupEntityData))) {
                    return;
                }
                StaticModelGroupEntityData staticModelGroupEntityDatum = (StaticModelGroupEntityData)ObjectData;
                hkpStaticCompoundShape item = null;
                if (staticModelGroupEntityDatum.PhysicsData.GetObject(RootContainer) != null) {
                    item = (hkpStaticCompoundShape)HkxBase.FromRes(Library.GetResByResRid(staticModelGroupEntityDatum.PhysicsData.GetObject(RootContainer).Asset.GetObject(RootContainer).Resource)).Objects[0];
                }
                int num = 0;
                foreach (StaticModelGroupMemberData memberData in staticModelGroupEntityDatum.MemberDatas) {
                    if (memberData.PhysicsPartCountPerInstance != 0) {
                        for (int i = 0; i < memberData.InstanceCount; i++) {
                            Matrix matrix2 = RenderUtils.TransRotScaleToMatrix(item.Instances[num].Translation.ToSlimDXVector3(), item.Instances[num].Rotation.ToSlimDXVector4(), item.Instances[num].Scale.ToSlimDXVector3());
                            AssetContainer dAIAssetContainer = GetAssetContainer(memberData.MeshAsset.Id.FileGuid);
                            if (dAIAssetContainer != null) {
                                Mesh dAIMesh = null;
                                ResRef resAsset = Library.GetResByResRid(((MeshAsset)dAIAssetContainer.RootObject).MeshSetResource);
                                dAIMesh = Mesh.FromRes(resAsset);
                                myRenderControl.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                                    _RenderScene.AddMesh(dAIMesh, matrix2);
                                    return null;
                                }, null);
                            }
                            num++;
                        }
                        continue;
                    }
                    for (int j = 0; j < memberData.InstanceCount; j++) {
                        Matrix matrix3 = RenderUtils.LinearTransformToMatrix(memberData.InstanceTransforms[j]) * ObjectMatrix;
                        AssetContainer assetContainer2 = GetAssetContainer(memberData.MeshAsset.Id.FileGuid);
                        if (assetContainer2.IsValid()) {
                            Mesh dAIMesh2 = null;
                            ResRef res1 = Library.GetResByResRid(((MeshAsset)assetContainer2.RootObject).MeshSetResource);
                            dAIMesh2 = Mesh.FromRes(res1);
                            myRenderControl.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                                _RenderScene.AddMesh(dAIMesh2, matrix3);
                                return null;
                            }, null);
                        }
                    }
                }
            }
        }

        private void ReadEntityData(EntityData Data, Matrix ObjectMatrix) {
            AssetContainer assetContainer = null;
            if (Data.GetType() == typeof(VegetationTreeEntityData)) {
                assetContainer = GetAssetContainer(((VegetationTreeEntityData)Data).Mesh.Id.FileGuid);
            } else if (Data.GetType() == typeof(StaticModelEntityData)) {
                assetContainer = GetAssetContainer(((StaticModelEntityData)Data).Mesh.Id.FileGuid);
            } else if (Data.GetType() == typeof(DynamicModelEntityData)) {
                assetContainer = GetAssetContainer(((DynamicModelEntityData)Data).Mesh.Id.FileGuid);
            } else if (Data.GetType() == typeof(DebrisClusterData)) {
                assetContainer = GetAssetContainer(((DebrisClusterData)Data).Mesh.Id.FileGuid);
            }
            if (assetContainer.IsValid()) {
                Mesh dAIMesh = null;
                ResRef res = Library.GetResByResRid(((MeshAsset)assetContainer.RootObject).MeshSetResource);
                dAIMesh = Mesh.FromRes(res);
                myRenderControl.Dispatcher.Invoke(DispatcherPriority.Normal, (DispatcherOperationCallback)delegate {
                    _RenderScene.AddMesh(dAIMesh, ObjectMatrix);
                    return null;
                }, null);
            }
        }

        private AssetContainer GetAssetContainer(Guid Guid) {
            if (Guid == Guid.Empty) {
                return new AssetContainer();
            }
            EbxRef ebx = Library.GetEbxByGuid(Guid);
            if (ebx == null) {
                return null;
            }
            return EbxBase.FromEbx(ebx)?.GetContainer();
        }
    }
}
