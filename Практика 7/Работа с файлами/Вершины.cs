using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Работа_с_файлами
{
    abstract class Вершины
    {
        protected static int R;
        protected int X;
        protected int Y;
        protected int sdvigx;
        protected int sdvigy;
        protected bool beingDragged;
        public bool in_prov;
        public static Color FigColor;
        public abstract void DrawFigure(Graphics graf);
        public abstract int Radius { set; get; }
        public bool InsideRrov { get; set; }
        public Color Changecolor
        {
            set
            {
                FigColor = value;
            }
            get
            {
                return FigColor;
            }
        }
        public void OnTick(bool flag)
        {
            Random rand = new Random();
            if (flag)
            {
                X += rand.Next(0, 5);
                Y += rand.Next(0, 5);
            }
            else
            {
                X -= rand.Next(0, 5);
                Y -= rand.Next(0, 5);
            }
        }
        public static bool InFigure(int x, int y, List<Вершины> polygons)
        {
            double d;
            bool Up = false;
            bool Down = false;
            List<Вершины> newList = new List<Вершины>();
            Вершины MOUSE = new Треугольник(x, y);
            polygons.Add(MOUSE);
            for (int i = 0; i < polygons.Count() - 1; i++)
            {
                for (int j = i + 1; j < polygons.Count(); j++)
                {
                    for (int k = 0; k < polygons.Count(); k++)
                    {
                        if (k != j && k != i)
                        {
                            d = (polygons[k].SetCoorY - polygons[j].SetCoorY) * (polygons[i].SetCoorX - polygons[j].SetCoorX) - ((polygons[i].SetCoorY - polygons[j].SetCoorY) * (polygons[k].SetCoorX - polygons[j].SetCoorX));
                            if (d >= 0)
                            {
                                Up = true;
                            }
                            else
                            {
                                Down = true;
                            }
                        }
                    }
                    if (!(Up && Down))
                    {
                        newList.Add(polygons[i]);
                        newList.Add(polygons[j]);
                    }
                    Up = false;
                    Down = false;
                }
            }
            if (!newList.Contains(MOUSE))
            {
                polygons.Remove(MOUSE);
                return true;
            }
            polygons.Remove(MOUSE);
            return false;
        }
        public int Sdvigx
        {
            set { sdvigx = value; }
            get { return sdvigx; }
        }
        public bool BeingDragged
        {
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
            in_prov = false;
        }
        static Вершины()
        {
            R = 20;
            FigColor = Color.Black;
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
            graf.FillRectangle(new SolidBrush(FigColor), X - R / 2, Y - R / 2, R, R);
        }
        public override int Radius
        {
            set { R = value; }
            get { return R; }
        }
        public override bool CheckArea(int x, int y)
        {
            if (X + R / 2 > x && X - R / 2 < x && Y + R / 2 > y && Y - R / 2 < y)
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
            graf.FillPolygon(new SolidBrush(FigColor), p3);
        }
        public override int Radius
        {
            set { R = value; }
            get { return R; }
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
            graf.FillEllipse(new SolidBrush(FigColor), X - R / 2, Y - R / 2, R, R);
        }
        public override int Radius
        {
            set { R = value; }
            get { return R; }
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
