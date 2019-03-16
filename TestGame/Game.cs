using System;
using System.Drawing;
using System.Threading;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace TestGame
{
    public class Game : GameWindow
    {
        private EngineThread UpdateThread;
        private EngineThread RenderThread;

        private Color4 clearColor;

        private IGraphicsContext newContext;

        public Game()
        {
            UpdateThread = new EngineThread(UpdateInit, UpdateFrame, 60);
            RenderThread = new EngineThread(RenderInit, RenderFrame, 2);
        }

        protected override void OnLoad(EventArgs e)
        {
            clearColor = Color4.Aqua;
            Context.MakeCurrent(null);
            UpdateThread.Start();
            RenderThread.Start();

        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            // Nothing to do. Release the CPU to other threads.
            Thread.Sleep(1);
        }

        public void UpdateInit()
        {

        }

        public void RenderInit()
        {
            MakeCurrent();
        }

        public new void UpdateFrame()
        {
            Console.WriteLine("Update " +UpdateThread.Timer.ElapsedFrameTime);
            if (UpdateThread.Timer.CurrentTime > 4000)
            {
                clearColor = Color4.Red;
            }
        }

        public new void RenderFrame()
        {
            //MakeCurrent();
            GL.Viewport(0, 0, 500,500);

            Console.WriteLine("Render");
            GL.ClearColor(clearColor);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);


            SwapBuffers();
        }
    }
}