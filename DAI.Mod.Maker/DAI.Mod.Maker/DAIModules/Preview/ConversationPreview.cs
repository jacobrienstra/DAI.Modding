using DAI.AssetLibrary.Assets.References;
using DAI.FrostbiteAssets;

namespace DAI.ModMaker.DAIModules.Preview {
    public class ConversationPreview : DAIBasePreviewer {
        public string[] GetAssetTypes() {
            return new string[1] { "Conversation" };
        }

        public void Run(AssetContainer InContainer, EbxRef InAsset) {
            new ConversationPreviewWindow(InContainer, (Conversation)InContainer.RootObject).Show();
        }
    }
}
