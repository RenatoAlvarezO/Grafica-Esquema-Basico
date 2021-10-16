using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Casa
{
    public class House
    {
        public int PrimitiveTypeIndex = 2;

        private float Length, Height, Width;
        private Vector3 Center;

        private Walls _walls;
        private Roof _roof;

        public House(float length, float height, float width, Vector3 center)
        {
            Length = length;
            Height = height;
            Width = width;
            Center = center;

            _roof = new Roof(Length, Height / 2, Width, new Vector3(Center.X, Center.Y + Height / 2, Center.Z));
            _walls = new Walls(Length * 0.9f, Height / 2, Width * 0.8f,
                new Vector3(Center.X, Center.Y - Height / 2, Center.Z));
        }

        public void Draw()
        {
            _walls.Draw((PrimitiveType) PrimitiveTypeIndex);
            _roof.Draw((PrimitiveType) PrimitiveTypeIndex);
        }
    }
}