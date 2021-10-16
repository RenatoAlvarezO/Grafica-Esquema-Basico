using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Casa
{
    public class Roof
    {
        public int PrimitiveTypeIndex = 6;

        private float Length, Height, Width;
        private Color BaseColor = Color.Gold;
        private Vector3 Center;

        public Roof(float length, float height, float width, Vector3 center)
        {
            Length = length;
            Height = height;
            Width = width;
            Center = center;
        }

        public void Draw(PrimitiveType primitiveType)
        {
            GL.Enable(EnableCap.DepthTest);

            //  Front
            GL.Begin(primitiveType);
            GL.Color4(BaseColor);
            GL.Vertex3(Center.X, Center.Y + Height, Center.Z + Width);
            // GL.Vertex3(Center.X + Length, Center.Y + Height, Center.Z + Width);
            GL.Vertex3(Center.X + Length, Center.Y - Height, Center.Z + Width);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z + Width);
            GL.End();
            
            //  Back
            GL.Begin(primitiveType);
            GL.Color4(Color.Aqua);
            GL.Vertex3(Center.X, Center.Y + Height, Center.Z - Width);
            // GL.Vertex3(Center.X + Length, Center.Y + Height, Center.Z - Width);
            GL.Vertex3(Center.X + Length, Center.Y - Height, Center.Z - Width);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z - Width);
            GL.End();
            
            //  Left
            GL.Begin(primitiveType);
            GL.Color4(Color.Lime);
            GL.Vertex3(Center.X, Center.Y + Height, Center.Z - Width);
            GL.Vertex3(Center.X, Center.Y + Height, Center.Z + Width);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z + Width);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z - Width);
            GL.End();
            
            
            //  Right
            GL.Begin(primitiveType);
            GL.Color4(Color.Red);
            GL.Vertex3(Center.X, Center.Y + Height, Center.Z - Width);
            GL.Vertex3(Center.X, Center.Y + Height, Center.Z + Width);
            GL.Vertex3(Center.X + Length, Center.Y - Height, Center.Z + Width);
            GL.Vertex3(Center.X + Length, Center.Y - Height, Center.Z - Width);
            GL.End();
            
            //  Bottom
            GL.Begin(primitiveType);
            GL.Color4(Color.Silver);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z - Width);
            GL.Vertex3(Center.X + Length, Center.Y - Height, Center.Z - Width);
            GL.Vertex3(Center.X + Length, Center.Y - Height, Center.Z + Width);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z + Width);
            GL.End();
            
            GL.Flush();
        }
    }
}