using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Работа_с_файлами
{
    public partial class Form1 : Form
    {
        List<Вершины> S;
        int shapenumb;
        bool Draw;
        bool flag;
        string path;
        int time_value;
        int rad_value;
        public Form1()
        {
            InitializeComponent();
            квадратToolStripMenuItem.CheckOnClick = true;
            треугольникToolStripMenuItem.CheckOnClick = true;
            кругToolStripMenuItem.CheckOnClick = true;
            квадратToolStripMenuItem.Checked = true;
            sTOPToolStripMenuItem.Checked = false;
            pLAYToolStripMenuItem.Checked = false;
            S = new List<Вершины>();
            Draw = false;
            shapenumb = 0;
            flag = false;
            path = "C:\\Users\\ivmas\\OneDrive\\Documents\\Проекты Вани\\Проекты по программированию 10.5 Visual Studio C#\\Практика 7\\Работа с файлами\\bin\\Debug\\Test.txt";
            rad_value = 20;
            time_value = 5;
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
                Pen pen = new Pen(Вершины.FigColor);
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
                            if (!(Up && Down))
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
            if (S.Count > 2)
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

        private void квадратToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shapenumb = 0;
            треугольникToolStripMenuItem.Checked = false;
            кругToolStripMenuItem.Checked = false;
        }

        private void поменятьЦветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            foreach (Вершины Obj in S)
            {
                Obj.Changecolor = colorDialog1.Color;
            }
            Refresh();
        }

        private void pLAYToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            flag = true;
        }

        private void sTOPToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            foreach (Вершины Obj in S)
            {
                Obj.OnTick(flag);
            }
            flag = !flag;
            Refresh();
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {

            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Изменение радиуса")
                {
                    return;
                }
            }
            Form3 CHRAD = new Form3();
            CHRAD.Show();
            CHRAD.eventus += Radius_Delegate;
        }

        private void Radius_Delegate(object sender, RadiusEventArgs a)
        {
            foreach (Вершины Obj in S)
            {
                Obj.Radius = a.Radius_Change;
            }
            Return_the_radius = a.Radius_Change;
            Refresh();
        }

        private void таймерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Изменение промежутка времени")
                {
                    return;
                }
            }
            Form2 CHRAD2 = new Form2();
            CHRAD2.Show();
            CHRAD2.time += Timer_Delegate;
        }
        private void Timer_Delegate(object sender, TimeEventArgs a)
        {
            timer1.Interval = a.Pause_Change * 10;
            Return_the_time = a.Pause_Change;
        }
        public int Return_the_radius
        {
            set
            {
                rad_value = value;
            }
            get
            {
                return rad_value;
            }
        }
        public int Return_the_time
        {
            set
            {
                time_value = value;
            }
            get
            {
                return time_value;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
            //if (!File.Exists(path))
            {
                try
                {
                    StreamWriter sw = new StreamWriter(path);
                    sw.WriteLine("Статика:");
                    sw.WriteLine("R");
                    sw.WriteLine(S[1].Radius);
                    sw.WriteLine("Цвет:");
                    sw.WriteLine(S[1].Changecolor);
                    sw.WriteLine("");
                    int i = 0;
                    foreach (Вершины Obj in S)
                    {
                        sw.WriteLine("{0}:", i);
                        sw.WriteLine("({0}, {1})", Obj.SetCoorX, Obj.SetCoorY);
                        i++;
                    }
                    sw.Close();
                }
                catch (Exception a)
                {
                    Console.WriteLine("Exception: " + a.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(path))
                {
                    StreamReader readFile = new StreamReader(path);
                    String A = readFile.ReadToEnd();
                    readFile.Close();
                    StreamWriter writeFile = new StreamWriter(path, true, System.Text.Encoding.Unicode);
                    writeFile.Close();
                    MessageBox.Show(A);
                }
                else throw new Exception("Файл не создан");
            }
            catch(Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }
    }
}