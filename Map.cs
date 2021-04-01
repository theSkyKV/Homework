using System;
using System.Collections.Generic;

namespace Map
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] field =
            {
                {1, 0, 1, 1 },
                {1, 1, 1, 0 },
                {0, 1, 1, 1 },
                {1, 1, 1, 0 },
                {0, 1, 0, 1 },
            };

            Map map = new Map(field);
            Console.WriteLine(map.CountIslands());
        }
    }

    class Map
    {
        private int[,] _map;
        private int _rows;
        private int _columns;

        public Map(int[,] map)
        {
            _map = map;
            _rows = map.GetLength(0);
            _columns = map.GetLength(1);
        }

        public int CountIslands()
        {
            int nonZeroNearestPointsCount;
            Point currentPoint;

            var islandsCount = 0;
            var nonZeroNearestPointsList = new List<Point>();
            var targetPoints = new List<Point>();

            for (var i = 0; i < _rows; i++)
            {
                for (var j = 0; j < _columns; j++)
                {
                    if (_map[i, j] == 1)
                    {
                        currentPoint = new Point(i, j);

                        do
                        {
                            nonZeroNearestPointsCount = 0;

                            for (var k = -1; k <= 1; k++)
                            {
                                for (var l = -1; l <= 1; l++)
                                {
                                    if (Math.Abs(k) == Math.Abs(l))
                                        continue;

                                    try
                                    {
                                        if (_map[currentPoint.X + k, currentPoint.Y + l] == 1)
                                        {
                                            nonZeroNearestPointsCount++;
                                            nonZeroNearestPointsList.Add(new Point(currentPoint.X + k, currentPoint.Y + l));
                                        }
                                    }
                                    catch (IndexOutOfRangeException)
                                    {
                                        continue;
                                    }
                                }
                            }

                            if (nonZeroNearestPointsCount == 1)
                            {
                                currentPoint = GetNextPoint(currentPoint, nonZeroNearestPointsList);
                            }
                            else if (nonZeroNearestPointsCount == 0)
                            {
                                _map[currentPoint.X, currentPoint.Y] = 0;

                                if (targetPoints.Count > 0)
                                {
                                    currentPoint = new Point(targetPoints[0].X, targetPoints[0].Y);
                                    nonZeroNearestPointsCount = 1;

                                    targetPoints.RemoveAt(0);
                                }
                            }
                            else
                            {
                                targetPoints.Add(new Point(currentPoint.X, currentPoint.Y));
                                currentPoint = GetNextPoint(currentPoint, nonZeroNearestPointsList);
                            }
                        } while (nonZeroNearestPointsCount > 0 | targetPoints.Count > 0);

                        islandsCount++;
                    }
                }
            }

            return islandsCount;
        }

        private Point GetNextPoint(Point currentPoint, List<Point> points)
        {
            _map[currentPoint.X, currentPoint.Y] = 0;
            currentPoint = new Point(points[0].X, points[0].Y);
            points.Clear();

            return currentPoint;
        }
    }

    class Point
    {
        public int X { get; }
        public int Y { get; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
