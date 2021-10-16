using System;
using System.Collections.Generic;
using System.Drawing;
using Microsoft.VisualBasic.CompilerServices;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Casa
{
    public class Walls
    {
        public int PrimitiveTypeIndex = 6;

        private float Length, Height, Width;
        private Color BaseColor = Color.Gold;
        private Vector3 Center;

        private List<Vector3> ListOfVerticesRight;
        private List<Vector3> ListOfVerticesFront;

        public Walls(float length, float height, float width, Vector3 center)
        {
            Length = length;
            Height = height;
            Width = width;
            Center = center;

            ListOfVerticesRight = new List<Vector3>();
            ListOfVerticesRight.Add(new Vector3(Center.X + Length, Center.Y + Height, Center.Z - Width));
            ListOfVerticesRight.Add(new Vector3(Center.X + Length, Center.Y + Height, Center.Z + Width));
            ListOfVerticesRight.Add(new Vector3(Center.X + Length, Center.Y - Height, Center.Z + Width));
            ListOfVerticesRight.Add(new Vector3(Center.X + Length, Center.Y - Height, Center.Z - Width));
            ListOfVerticesRight.Add(new Vector3(Center.X + Length, Center.Y + Height / 2, Center.Z - Width / 2));
            ListOfVerticesRight.Add(new Vector3(Center.X + Length, Center.Y + Height / 2, Center.Z + Width / 2));
            ListOfVerticesRight.Add(new Vector3(Center.X + Length, Center.Y - Height / 2, Center.Z + Width / 2));
            ListOfVerticesRight.Add(new Vector3(Center.X + Length, Center.Y - Height / 2, Center.Z - Width / 2));

            ListOfVerticesFront = new List<Vector3>();

            ListOfVerticesFront.Add(new Vector3(Center.X - Length, Center.Y + Height, Center.Z + Width));
            ListOfVerticesFront.Add(new Vector3(Center.X + Length, Center.Y + Height, Center.Z + Width));
            ListOfVerticesFront.Add(new Vector3(Center.X + Length, Center.Y - Height, Center.Z + Width));
            ListOfVerticesFront.Add(new Vector3(Center.X - Length, Center.Y - Height, Center.Z + Width));
            ListOfVerticesFront.Add(new Vector3(Center.X - Length / 2, Center.Y + Height / 2, Center.Z + Width));
            ListOfVerticesFront.Add(new Vector3(Center.X + Length / 2, Center.Y + Height / 2, Center.Z + Width));
            ListOfVerticesFront.Add(new Vector3(Center.X + Length / 2, Center.Y - Height, Center.Z + Width));
            ListOfVerticesFront.Add(new Vector3(Center.X - Length / 2, Center.Y - Height, Center.Z + Width));
        }

        public void Draw(PrimitiveType primitiveType)
        {
            int[,] vertices = {{1, 5, 8, 4}, {1, 2, 6, 5}, {2, 3, 7, 6}, {3, 4, 8, 7}};
            GL.Enable(EnableCap.DepthTest);
            
            //  Front
            GL.Color4(BaseColor);
            GL.Begin(primitiveType);

            for (int i = 0; i < vertices.GetLength(0); i++)
            {
                GL.Begin(primitiveType);

                for (int j = 0; j < vertices.GetLength(1); j++)
                    GL.Vertex3(ListOfVerticesFront[vertices[i, j] - 1]);

                GL.End();
            }

            GL.End();

            //  Back
            GL.Begin(primitiveType);
            GL.Color4(Color.Aqua);
            GL.Vertex3(Center.X - Length, Center.Y + Height, Center.Z - Width);
            GL.Vertex3(Center.X + Length, Center.Y + Height, Center.Z - Width);
            GL.Vertex3(Center.X + Length, Center.Y - Height, Center.Z - Width);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z - Width);
            GL.End();

            //  Left
            GL.Begin(primitiveType);
            GL.Color4(Color.Lime);
            GL.Vertex3(Center.X - Length, Center.Y + Height, Center.Z - Width);
            GL.Vertex3(Center.X - Length, Center.Y + Height, Center.Z + Width);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z + Width);
            GL.Vertex3(Center.X - Length, Center.Y - Height, Center.Z - Width);
            GL.End();


            //  Right

            GL.Color4(Color.Red);

            for (int i = 0; i < vertices.GetLength(0); i++)
            {
                GL.Begin(primitiveType);

                for (int j = 0; j < vertices.GetLength(1); j++)
                    GL.Vertex3(ListOfVerticesRight[vertices[i, j] - 1]);

                GL.End();
            }

            //  Top
            GL.Begin(primitiveType);
            GL.Color4(Color.DeepPink);
            GL.Vertex3(Center.X - Length, Center.Y + Height, Center.Z - Width);
            GL.Vertex3(Center.X + Length, Center.Y + Height, Center.Z - Width);
            GL.Vertex3(Center.X + Length, Center.Y + Height, Center.Z + Width);
            GL.Vertex3(Center.X - Length, Center.Y + Height, Center.Z + Width);
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