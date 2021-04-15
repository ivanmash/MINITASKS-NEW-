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


namespace Сериализация
{
    public partial class Form1 : Form
    {
        Rectangle Obj;
        string path;
        BinaryFormatter formatter;
        Stream stream;
        public Form1()
        {
            InitializeComponent();
        }
            
        private void Form1_Load(object sender, EventArgs e)
        {
            formatter = new BinaryFormatter();
            Obj = new Rectangle();
            path = "C:\\Users\\ivmas\\OneDrive\\Documents\\Проекты Вани\\Проекты по программированию 10.5 Visual Studio C#\\Практика 8\\Сериализация\\bin\\Debug\\Test.txt";
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Obj.DrawFigure(g);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter(path);
                sw.WriteLine("R1");
                sw.WriteLine(Obj.Rchange);
                sw.WriteLine("R2");
                sw.WriteLine(Obj.Rchange + 20);
                sw.WriteLine("");
                sw.WriteLine("({0}, {1})", Obj.Xchange, Obj.Ychange);
                sw.Close();
            }
            catch (Exception a)
            {
                Console.WriteLine("Exception: " + a.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
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
            catch (Exception er)
            {
                MessageBox.Show(er.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            formatter = new BinaryFormatter();
            stream = File.OpenRead("C:\\Users\\ivmas\\OneDrive\\Documents\\Проекты Вани\\Проекты по программированию 10.5 Visual Studio C#\\Практика 8\\Сериализация\\bin\\Debug\\Test.bin");
            Obj = (Rectangle)formatter.Deserialize(stream);
            stream.Close();
            Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                stream = File.Create("C:\\Users\\ivmas\\OneDrive\\Documents\\Проекты Вани\\Проекты по программированию 10.5 Visual Studio C#\\Практика 8\\Сериализация\\bin\\Debug\\Test.bin");
                formatter.Serialize(stream, Obj);
                stream.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (Form f in Application.OpenForms)
            {
                if (f.Name == "Form2")
                {
                    return;
                }
            }
            Form2 CHRAD = new Form2();
            CHRAD.Show();
            CHRAD.eventus += Radius_Delegate;
        }
        private void Radius_Delegate(object sender, RadiusEventArgs a)
        {
            Obj.Rchange = a.Radius_Change;
            Refresh();
        }
    }
}
