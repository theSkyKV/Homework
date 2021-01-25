using System;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(20, 10);
            Player player2 = new Player(10, 20);
            Renderer renderer = new Renderer();
            renderer.Draw(player1);
            renderer.Draw(player2, '#');
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Renderer
    {
        public void Draw(Player player, char symbol = '@')
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(symbol);
        }
    }
}
