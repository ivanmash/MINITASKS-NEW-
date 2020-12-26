using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Мнизадача_4_Машкарин_Иван
{
    public partial class Form1 : Form
    {
        List<Вершины> S;
        int shapenumb;
        bool Draw;
        public Form1()
        {
            InitializeComponent();
            квадратToolStripMenuItem.CheckOnClick = true;
            треугольникToolStripMenuItem.CheckOnClick = true;
            кругToolStripMenuItem.CheckOnClick = true;
            квадратToolStripMenuItem.Checked = true;
            S = new List<Вершины>();
            Draw = false;
            shapenumb = 0;
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (Draw)
            {
                bool Up = false;
                bool Down = false;
                double d = 0;
                Graphics g = e.Graphics;
                foreach (Вершины Obj in S)
                {
                    Obj.InsideRrov = false;
                    Obj.DrawFigure(g);
                }
                Pen pen = new Pen(Color.Orange);
                if (S.Count() > 2)
                {
                        for (int i = 0; i < S.Count() - 1; i++)
                        { 
                            for (int j = i + 1; j < S.Count(); j++)
                        {
                                for (int k = 0; k < S.Count(); k++)
                                {
                                    if (k != j && k != i)
                                    {
                                        d = (S[k].SetCoorY - S[j].SetCoorY) * (S[i].SetCoorX - S[j].SetCoorX) - ((S[i].SetCoorY - S[j].SetCoorY) * (S[k].SetCoorX - S[j].SetCoorX));
                                    if (d >= 0)
                                        {
                                            Up = true;
                                        }
                                        else Down = true;
                                    }
                                }
                                if(!(Up && Down))
                                {
                                    S[i].InsideRrov = true;
                                    S[j].InsideRrov = true;
                                    e.Graphics.DrawLine(pen, S[i].SetCoorX, S[i].SetCoorY, S[j].SetCoorX, S[j].SetCoorY);
                                }
                            Up = false;
                            Down = false;
                        }
                        }
                }
            }
        }

            private void Form1_MouseDown(object sender, MouseEventArgs e)
            {
                bool specprov;
                if (!S.Any() && e.Button == MouseButtons.Left)
                {
                    switch (shapenumb)
                    {
                        case (0): S.Add(new Квадрат(e.X, e.Y)); break;
                        case (1): S.Add(new Треугольник(e.X, e.Y)); break;
                        case (2): S.Add(new Круг(e.X, e.Y)); break;
                    }
                    Draw = true;
                    Refresh();
                }
                else
                {
                    specprov = false;
                    foreach (Вершины Obj in S)
                    {
                        if (Obj.CheckArea(e.X, e.Y) && Draw)
                        {
                            if (e.Button == MouseButtons.Left)
                            {
                                Obj.Sdvigx = e.X - Obj.SetCoorX;
                                Obj.Sdvigy = e.Y - Obj.SetCoorY;
                                Obj.BeingDragged = true;
                                specprov = true;
                            }
                            if (e.Button == MouseButtons.Right)
                            {
                                S.Remove(Obj); Refresh(); specprov = true; break;
                            }
                        }
                    }
                if (e.Button == MouseButtons.Left && specprov == false)
                {
                    Draw = true;
                    if (S.Count > 2 && Вершины.InFigure(e.X, e.Y, S))
                    {
                        foreach (Вершины Obj in S)
                        {
                            Obj.Sdvigx = e.X - Obj.SetCoorX;
                            Obj.Sdvigy = e.Y - Obj.SetCoorY;
                            Obj.BeingDragged = true;
                        }
                    }
                    else
                    {
                        switch (shapenumb)
                        {
                            case (0): S.Add(new Квадрат(e.X, e.Y)); break;
                            case (1): S.Add(new Треугольник(e.X, e.Y)); break;
                            case (2): S.Add(new Круг(e.X, e.Y)); break;
                        }
                    }
                }
                Refresh();
                }
            }
        private void Form1_Load(object sender, EventArgs e)
            {
                квадратToolStripMenuItem.Checked = true;
                DoubleBuffered = true;
            }
            private void КвадратToolStripMenuItem_Click_1(object sender, EventArgs e)
            {
                shapenumb = 0;
                треугольникToolStripMenuItem.Checked = false;
                кругToolStripMenuItem.Checked = false;
            }

            private void ТреугольникToolStripMenuItem_Click(object sender, EventArgs e)
            {
                shapenumb = 1;
                квадратToolStripMenuItem.Checked = false;
                кругToolStripMenuItem.Checked = false;
            }

            private void КругToolStripMenuItem_Click(object sender, EventArgs e)
            {
                shapenumb = 2;
                треугольникToolStripMenuItem.Checked = false;
                квадратToolStripMenuItem.Checked = false;
            }
            private void Form1_MouseMove(object sender, MouseEventArgs e)
            {
                foreach (Вершины Obj in S)
                {
                    if (Obj.BeingDragged)
                    {
                        Obj.SetCoorX = e.X - Obj.Sdvigx;
                        Obj.SetCoorY = e.Y - Obj.Sdvigy;
                        Refresh();
                    }
                }
            }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (Вершины Obj in S)
            {
                if (Obj.BeingDragged)
                {
                    Obj.BeingDragged = false;
                }
            }
            if(S.Count > 2)
            {
                for (int i = 0; i < S.Count(); i++)
                {
                    if (!S[i].InsideRrov)
                    {
                        S.Remove(S[i]);
                    }
                }
            }
            Refresh();
        }
    }
}