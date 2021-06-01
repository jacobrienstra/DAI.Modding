using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

using DAI.AssetLibrary.Assets.Bases;
using DAI.ModMaker.DAIRender;

namespace DAI.ModMaker {
    public partial class TexturePreviewWindow : Window, IComponentConnector {
        private Dictionary<TextureFormat, string> TextureFormatNames = new Dictionary<TextureFormat, string>
        {
            {
                TextureFormat.TF_DXT1,
                "DXT1"
            },
            {
                TextureFormat.TF_DXT1A,
                "DX1A"
            },
            {
                TextureFormat.TF_NormalDXN,
                "ATI2"
            },
            {
                TextureFormat.TF_DXT5A,
                "ATI1"
            },
            {
                TextureFormat.TF_DXT5,
                "DXT5"
            },
            {
                TextureFormat.TF_ABGR32F,
                "32bit RGBA Uncompressed"
            },
            {
                TextureFormat.TF_ARGB8888,
                "8bit RGBA Uncompressed"
            },
            {
                TextureFormat.TF_L8,
                "8bit Grayscale"
            },
            {
                TextureFormat.TF_L16,
                "16bit Grayscale"
            },
            {
                TextureFormat.TF_NormalDXT1,
                "DXT1 (Normals)"
            },
            {
                TextureFormat.TF_R9G9B9E5F,
                "Shared Exponent"
            }
        };

        private TextureRenderScene RenderScene;

        private MyRenderEngine RenderEngine;

        private static SolidColorBrush RedColorBrush;

        private static SolidColorBrush GreenColorBrush;

        private static SolidColorBrush BlueColorBrush;

        private static SolidColorBrush AlphaColorBrush;

        private static SolidColorBrush NullColorBrush;

        static TexturePreviewWindow() {
            RedColorBrush = new SolidColorBrush(Colors.Red);
            GreenColorBrush = new SolidColorBrush(Colors.Green);
            BlueColorBrush = new SolidColorBrush(Colors.Blue);
            AlphaColorBrush = new SolidColorBrush(Colors.White);
            NullColorBrush = null;
        }

        public TexturePreviewWindow(Texture InTexture) {
            InitializeComponent();
            if (!Globals.WarnedAboutTextures) {
                System.Windows.Forms.MessageBox.Show("Some texture files might not preview well and cause the tool to crash.  Please do not report it.  We are working on it.");
            }
            Globals.WarnedAboutTextures = true;
            RenderScene = new TextureRenderScene(InTexture);
            RenderEngine = new MyRenderEngine(RenderScene);
            TextureRenderControl.RegisterRenderer(RenderEngine);
            DimensionsTextBlock.Text = InTexture.Width + "x" + InTexture.Height;
            FormatTextBlock.Text = "Unknown Format";
            if (TextureFormatNames.ContainsKey(InTexture.PixelFormat)) {
                FormatTextBlock.Text = TextureFormatNames[InTexture.PixelFormat];
            }
            if (InTexture.TextureType == TextureType.TT_Cube) {
                FormatTextBlock.Text = "Cubemap - " + FormatTextBlock.Text;
            }
        }

        private void ColorButton_Click(object sender, RoutedEventArgs e) {
            System.Windows.Controls.Button nullColorBrush = (System.Windows.Controls.Button)sender;
            if (!string.IsNullOrEmpty((string)nullColorBrush.Content)) {
                nullColorBrush.Content = "";
                nullColorBrush.Background = NullColorBrush;
                nullColorBrush.Foreground = NullColorBrush;
            } else if (nullColorBrush == RedButton) {
                nullColorBrush.Content = "R";
                nullColorBrush.Background = RedColorBrush;
                nullColorBrush.Foreground = RedColorBrush;
            } else if (nullColorBrush == GreenButton) {
                nullColorBrush.Content = "G";
                nullColorBrush.Background = GreenColorBrush;
                nullColorBrush.Foreground = GreenColorBrush;
            } else if (nullColorBrush != BlueButton) {
                nullColorBrush.Content = "A";
                nullColorBrush.Background = AlphaColorBrush;
                nullColorBrush.Foreground = AlphaColorBrush;
            } else {
                nullColorBrush.Content = "B";
                nullColorBrush.Background = BlueColorBrush;
                nullColorBrush.Foreground = BlueColorBrush;
            }
            string content = (string)RedButton.Content;
            string str = (string)GreenButton.Content;
            string content2 = (string)BlueButton.Content;
            string str2 = (string)AlphaButton.Content;
            if (content == "R" && str == "" && content2 == "" && str2 == "") {
                RenderScene.SetChannelMaskAllActive(0);
                return;
            }
            if (content == "" && str == "G" && content2 == "" && str2 == "") {
                RenderScene.SetChannelMaskAllActive(1);
                return;
            }
            if (content == "" && str == "" && content2 == "B" && str2 == "") {
                RenderScene.SetChannelMaskAllActive(2);
                return;
            }
            if (content == "" && str == "" && content2 == "" && str2 == "A") {
                RenderScene.SetChannelMaskAllActive(3);
                return;
            }
            RenderScene.SetChannelMaskActive(0, content == "R");
            RenderScene.SetChannelMaskActive(1, str == "G");
            RenderScene.SetChannelMaskActive(2, content2 == "B");
            RenderScene.SetChannelMaskActive(3, str2 == "A");
        }

        private void Window_Closing(object sender, CancelEventArgs e) {
            RenderEngine.Dispose();
        }
    }
}
