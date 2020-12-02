using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Машкарин_Иван_Минизадача3
{
    abstract class Вершины
    {
        protected static int R;
        protected int X;
        protected int Y;
        protected int sdvigx;
        protected int sdvigy;
        protected bool beingDragged;
        public abstract void DrawFigure(Graphics graf);
        public abstract int Radius { set; }
        public int Sdvigx {
            set { sdvigx = value; }
            get { return sdvigx; }
        }
        public bool BeingDragged {
            set
            {
                beingDragged = value;
            }
            get
            {
                return beingDragged;
            }
        }
        public int Sdvigy
        {
            set { sdvigy = value; }
            get { return sdvigy; }
        }
        public Вершины(int x, int y)
        {
            X = x;
            Y = y;
            beingDragged = false;
            sdvigx = 0;
            sdvigy = 0;
        }
        static Вершины()
        {
            R = 40;
        }
        public int SetCoorX
        {
            set { X = value; }
            get { return X; }
        }
        public int SetCoorY
        {
            set { Y = value; }
            get { return Y; }
        }
        public abstract bool CheckArea(int x, int y);
    }
    class Квадрат : Вершины
    {
        public Квадрат(int x, int y) : base(x, y) { }

        public override void DrawFigure(Graphics graf)
        {
            graf.FillRectangle(new SolidBrush(Color.Yellow), X - R / 2, Y - R / 2, R, R);
        }
        public override int Radius
        {
            set { R = value; }
        }
        public override bool CheckArea(int x, int y)
        {
            if (X + R/2 > x && X - R/2 < x && Y + R / 2 > y && Y - R / 2 < y)
            {
                return true;
            }
            else return false;
        }
    }
    class Треугольник : Вершины
    {
        public Треугольник(int x, int y) : base(x, y) { }
        public override void DrawFigure(Graphics graf)
        {
            Point[] p3 = new Point[3];
            p3[0] = new Point(X + R / 2 - R / 2, Y - R / 2);
            p3[1] = new Point(X - R / 2, Y + R - R / 2);
            p3[2] = new Point(X + R - R / 2, Y + R - R / 2);
            graf.FillPolygon(new SolidBrush(Color.Yellow), p3);
        }
        public override int Radius
        {
            set { R = value; }
        }
        public override bool CheckArea(int x, int y)
        {
            int a = (X + R / 2 - R / 2 - x) * (Y + R - R / 2 - (Y - R / 2)) - (X - R / 2 - (X + R / 2 - R / 2)) * (Y - R / 2 - y);
            int b = (X - R / 2 - x) * (Y + R - R / 2 - (Y + R - R / 2)) - (X + R - R / 2 - (X - R / 2)) * (Y + R - R / 2 - y);
            int c = (X + R - R / 2 - x) * (Y - R / 2 - (Y + R - R / 2)) - (X + R / 2 - R / 2 - (X + R - R / 2)) * (Y + R - R / 2 - y);

            if ((a >= 0 && b >= 0 && c >= 0) || (a <= 0 && b <= 0 && c <= 0))
            {
                return true;
            }
            else return false;
        }
    }
    class Круг : Вершины
    {
        public Круг(int x, int y) : base(x, y) { }
        public override void DrawFigure(Graphics graf)
        {
            graf.FillEllipse(new SolidBrush(Color.Yellow), X - R / 2, Y - R / 2, R, R);
        }
        public override int Radius
        {
            set { R = value; }
        }
        public override bool CheckArea(int x, int y)
        {
            if (Math.Pow(X - x, 2) + Math.Pow(Y - y, 2) <= Math.Pow(R / 2, 2))
            {
                return true;
            }
            else return false;
        }
    }
}
