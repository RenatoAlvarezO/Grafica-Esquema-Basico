using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Casa
{
    public class Game : GameWindow
    {
        private House _house;

        public Game(int width, int height, string title) : base(width, height, GraphicsMode.Default, title)
        {
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            KeyboardState inputKey = Keyboard.GetState();
            GL.Rotate(1, 0.0f, 1f, 0.0f);
            if (inputKey.IsKeyDown(Key.W))
            {
                while (Keyboard.GetState().IsKeyDown(Key.W)) ;
                int CurrentPrimitiveTypeIndex = _house.PrimitiveTypeIndex;
                _house.PrimitiveTypeIndex = CurrentPrimitiveTypeIndex == 2 ? 9 : 2;
            }

            base.OnUpdateFrame(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            _house = new House(60f, 80f, 90f, new Vector3(0.0f, 0.0f, 0.0f));
            Color backgroundColor = Color.FromArgb(255, 65, 87, 63);
            GL.ClearColor(backgroundColor);
            int orthoSize = 200;
            GL.Ortho(-orthoSize, orthoSize, -orthoSize, orthoSize, -orthoSize, orthoSize);
            GL.Rotate(10, 0.2f, 0.1f, 0.1f);
            base.OnLoad(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            _house.Draw();
            Context.SwapBuffers();
            base.OnRenderFrame(e);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);
            base.OnResize(e);
        }
    }
}