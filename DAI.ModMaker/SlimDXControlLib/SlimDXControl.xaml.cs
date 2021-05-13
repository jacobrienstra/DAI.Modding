using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

using SlimDX.Direct3D11;
using DAI.ModMaker.DAIRender;

namespace Flaxen.SlimDXControlLib
{
    public partial class SlimDXControl : ContentControl, IComponentConnector
    {
        private D3DImageSlimDX m_d3dImageSlimDX;

        private RenderEngine m_renderEngine;

        private GameTimer Timer;

        public SlimDXControl()
        {
            base.Loaded += SlimDXControl_Loaded;
            base.SizeChanged += SlimDXControl_SizeChanged;
            base.Dispatcher.ShutdownStarted += Dispatcher_ShutdownStarted;
            InitializeComponent();
            Timer = new GameTimer
            {
                FrameTime = 0.0166666675f
            };
        }

        private void BeginRenderingScene()
        {
            if (m_renderEngine != null && m_d3dImageSlimDX.IsFrontBufferAvailable)
            {
                Texture2D sharedTexture = m_renderEngine.SharedTexture;
                m_d3dImageSlimDX.SetBackBufferSlimDX(sharedTexture);
                CompositionTarget.Rendering += OnRendering;
            }
        }

        private void Dispatcher_ShutdownStarted(object sender, EventArgs e)
        {
            ShutdownD3D();
        }

        private void OnIsFrontBufferAvailableChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (m_d3dImageSlimDX.IsFrontBufferAvailable)
            {
                BeginRenderingScene();
            }
            else
            {
                StopRenderingScene();
            }
        }

        private void OnRendering(object sender, EventArgs e)
        {
            if (m_renderEngine != null)
            {
                Timer.Tick();
                m_renderEngine.Render(Timer.DeltaTime);
                m_d3dImageSlimDX.InvalidateD3DImage();
            }
        }

        public void RegisterRenderer(RenderEngine engine)
        {
            m_renderEngine = engine;
            if (m_renderEngine != null)
            {
                m_renderEngine.Initialize(this);
            }
        }

        private void ShutdownD3D()
        {
            if (m_d3dImageSlimDX != null)
            {
                m_d3dImageSlimDX.Dispose();
                m_d3dImageSlimDX = null;
            }
            if (m_renderEngine != null)
            {
                m_renderEngine.Dispose();
                RegisterRenderer(null);
            }
        }

        private void SlimDXControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this))
            {
                m_d3dImageSlimDX = new D3DImageSlimDX();
                m_d3dImageSlimDX.IsFrontBufferAvailableChanged += OnIsFrontBufferAvailableChanged;
                x_image.Source = m_d3dImageSlimDX;
                if (m_renderEngine == null)
                {
                    MessageBox.Show("Could not load SlimDX.\nPlease make sure you have SlimDX SDK and DirectX11 installed on your computer.");
                    return;
                }
                Texture2D sharedTexture = m_renderEngine.SharedTexture;
                Timer.Start();
                m_d3dImageSlimDX.SetBackBufferSlimDX(sharedTexture);
                BeginRenderingScene();
            }
        }

        private void SlimDXControl_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            if (!DesignerProperties.GetIsInDesignMode(this) && m_renderEngine != null)
            {
                int width = (int)e.NewSize.Width;
                int height = (int)e.NewSize.Height;
                m_renderEngine.Reinitialize(width, height);
                if (m_d3dImageSlimDX != null)
                {
                    Texture2D sharedTexture = m_renderEngine.SharedTexture;
                    m_d3dImageSlimDX.SetBackBufferSlimDX(sharedTexture);
                }
            }
        }

        private void StopRenderingScene()
        {
            CompositionTarget.Rendering -= OnRendering;
        }
    }
}
