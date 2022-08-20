using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleSnake.GameObjects
{
    public class Point
    {
        public Point(int leftX, int topY)
        {
            this.LeftX = leftX;
            this.TopY = topY;
        }
        public int LeftX { get; set; }
        public int TopY { get; set; }

        public void Draw(char symbol)
        {
            Console.SetCursorPosition(this.LeftX,this.TopY);
            Console.Write(symbol);
        }

        //TODO : Refactor
        public void Draw(int leftX,int topY, char symbol)
        {
            Console.SetCursorPosition(leftX,topY);
            Console.Write(symbol);
        }
    }
}
