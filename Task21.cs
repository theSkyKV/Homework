using System;

namespace CSLight
{
    class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            int x = 0;
            int y = 0;
            string[] map = { "##############################################",
                             "#      $ #            $  # $              $  #",
                             "#        #               #                   #",
                             "#        #               #                   #",
                             "#   ######     ###########                   #",
                             "#                      $ #                   #",
                             "#                        #     ###############",
                             "#       ##########                           #",
                             "#       # $      #        @        #         #",
                             "#       #        #                 #         #",
                             "#       #        #                 #         #",
                             "#  $    #                 $        #     $   #",
                             "##############################################" };
            char[,] charMap = GetCharArray(map);
            int points = 0;

            Console.CursorVisible = false;
            DrawMap(charMap);
            GetStartPosition(charMap, ref x, ref y);

            while (isPlaying)
            {
                Movement(ref x, ref y, ref charMap, ref points);

                Console.SetCursorPosition(10, 20);
                Console.Write(points);
            }
        }

        static char[,] GetCharArray(string[] stringArray)
        {
            char[,] charArray = new char[stringArray.Length, stringArray[0].Length];
            for(var i = 0; i < charArray.GetLength(0); i++)
            {
                for (var j = 0; j < charArray.GetLength(1); j++)
                {
                    charArray[i, j] = stringArray[i][j];
                }
            }
            return charArray;
        }

        static void DrawMap(char[,] map)
        {
            for (var i = 0; i < map.GetLength(0); i++)
            {
                for (var j = 0; j < map.GetLength(1); j++)
                {
                    Console.Write(map[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void GetStartPosition(char[,] map, ref int x, ref int y)
        {
            for (var i = 0; i < map.GetLength(0); i++)
            {
                for (var j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == '@')
                    {
                        x = j;
                        y = i;
                        return;
                    }
                }
            }
        }

        static void Movement(ref int x, ref int y, ref char[,] map, ref int points)
        {
            Console.SetCursorPosition(x, y);
            Console.Write('@');
            
            if (Console.KeyAvailable)
            {
                int dx = 0;
                int dy = 0;

                ConsoleKeyInfo key = Console.ReadKey(true);

                switch(key.Key)
                {
                    case ConsoleKey.UpArrow:
                        dx = 0;
                        dy = -1;
                        break;
                    case ConsoleKey.DownArrow:
                        dx = 0;
                        dy = 1;
                        break;
                    case ConsoleKey.RightArrow:
                        dx = 1;
                        dy = 0;
                        break;
                    case ConsoleKey.LeftArrow:
                        dx = -1;
                        dy = 0;
                        break;
                }

                if (map[y + dy, x + dx] == '#')
                {
                    return;
                }

                if (map[y + dy, x + dx] == '$')
                {
                    points++;
                    map[y + dy, x + dx] = ' ';
                }

                Console.SetCursorPosition(x, y);
                Console.Write(" ");
                x += dx;
                y += dy;
            }

        }
    }
}

