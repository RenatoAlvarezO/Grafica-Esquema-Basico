using System;

namespace Casa
{
    class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game(800, 800, "Casa"))
            {
                game.Run(60);
            }
        }
    }
}