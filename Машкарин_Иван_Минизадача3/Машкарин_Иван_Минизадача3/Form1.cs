using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Машкарин_Иван_Минизадача3
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
                Graphics g = e.Graphics;
                foreach (Вершины Obj in S)
                {
                    Obj.DrawFigure(g);
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
                            S.Remove(Obj); Refresh(); break;
                        }
                    }
                }
                        if (e.Button == MouseButtons.Left && specprov == false)
                        {
                            Draw = true;
                            switch (shapenumb)
                            {
                                case (0): S.Add(new Квадрат(e.X, e.Y)); break;
                                case (1): S.Add(new Треугольник(e.X, e.Y)); break;
                                case (2): S.Add(new Круг(e.X, e.Y)); break;
                            }

                            Refresh();
                        }
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
            foreach(Вершины Obj in S)
            {
                if (Obj.BeingDragged)
                {
                    Obj.BeingDragged = false;
                }
            }
        }
    }
}