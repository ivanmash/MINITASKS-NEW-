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
using System.Runtime.Serialization.Formatters.Binary;

namespace Мнизадача_4_Машкарин_Иван
{
    public partial class Form1 : Form
    {
        List<Вершины> S;
        int shapenumb;
        bool Draw;
        bool flag;
        Stream stream;
        BinaryFormatter formatter;
        string File_Name;
        bool IsChanged;
        Stack<TIME_Operations> undo;
        Stack<TIME_Operations> redo;
        public int r;

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
            formatter = new BinaryFormatter();
            File_Name = "C:\\Users\\ivmas\\OneDrive\\Documents\\Проекты Вани\\Проекты по программированию 10.5 Visual Studio C#\\Мнизадача_4_Машкарин_Иван\\Мнизадача_4_Машкарин_Иван\\bin\\Debug\\Test.bin";
            IsChanged = false;
            undo = new Stack<TIME_Operations>();
            undo.Push(null);
            redo = new Stack<TIME_Operations>(); 
            redo.Push(null);
            r = 0;
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
            IsChanged = true;
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
            undo.Push(new Color_fixation(Вершины.FigColor));
            undo.Push(null);
            redo.Clear();
            redo.Push(null);
            Вершины.Changecolor = colorDialog1.Color;
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
            r = Вершины.Radius;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form3")
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
            undo.Push(new Radius_fixation(Math.Abs(a.Radius_Change- Вершины.Radius)));
            undo.Push(null);
            redo.Clear();
            redo.Push(null);
            Вершины.Radius = a.Radius_Change;
            Refresh();
        }

        private void таймерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form2")
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
        }

        private void filenewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Do you want to save the changes?";
            string caption = "Caution!";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;
                if(IsChanged == true)
                {
                    result = MessageBox.Show(message, caption, buttons);
                    if (result == System.Windows.Forms.DialogResult.Yes)
                    {
                        stream = File.Create(File_Name);
                        formatter.Serialize(stream, S);
                        stream.Close();
                    }
                    S.Clear();
                Refresh();
                }
        }

        private void filesaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            saveFileDialog1.ShowDialog();
            File_Name = saveFileDialog1.FileName;
            if (File_Name != "")
            {
                stream = File.Create(File_Name);
                formatter.Serialize(stream, S);
                stream.Close();
            }
        }

        private void fileopenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            File_Name = openFileDialog1.FileName;
            if (File_Name != "")
            {
                stream = File.OpenRead(File_Name);
                S = (List<Вершины>)formatter.Deserialize(stream);
                stream.Close();
                Refresh();
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(undo.Count > 1)
            {
                undo.Pop();
                while(undo.Peek() != null)
                {
                    undo.Peek().Undo(S);
                    redo.Push(undo.Pop());
                }
                redo.Push(null);
            }
            this.Refresh();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (redo.Count > 1)
            {
                redo.Pop();
                while (redo.Peek() != null)
                {
                    redo.Peek().Redo(S);
                    undo.Push(redo.Pop());
                }
                undo.Push(null);
                this.Refresh();
            }
        }
    }
}