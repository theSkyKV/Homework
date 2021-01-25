using System;

namespace Properties
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player(20, 10);
            Renderer renderer = new Renderer(player);
            renderer.Draw();
        }
    }

    class Player
    {
        public int X { get; private set; }
        public int Y{ get; private set; }

        public Player(int x, int y)
        {
            X = x;
            Y = y;
        }
    }

    class Renderer
    {
        private Player _player;

        public Renderer(Player player)
        {
            _player = player;
        }

        public void Draw(char symbol = '@')
        {
            Console.SetCursorPosition(_player.X, _player.Y);
            Console.Write(symbol);
        }
    }
}
