using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace samSnake
{
    public enum Direction {Up,Down, Left, Right};
    class settings
    {
        //detects width and height of circle 
        //static so that we can access them in other classes
        public static int Width  { get; set; }
        public static int Height { get; set; }
        //detects speed of circles
        public static int Speed  { get; set; }
        //
        public static int Score  { get; set; }
        public static int Points { get; set; }
        public static bool gameOver { get; set; }
        public static Direction direction { get; set; }
        //constructor
        public settings()
        {
            Width = 16;
            Height = 16;
            Speed = 16;
            Score = 0;
            Points = 100;
            gameOver = false;
            direction = Direction.Down;
        }

    }
}
