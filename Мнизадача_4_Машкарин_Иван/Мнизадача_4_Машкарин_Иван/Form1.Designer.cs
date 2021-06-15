namespace Мнизадача_4_Машкарин_Иван
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filenewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filesaveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileopenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вершиныToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.квадратToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.треугольникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.кругToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поменятьЦветToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.анимацияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLAYToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sTOPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.изменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.таймерToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.undoredoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлыToolStripMenuItem,
            this.вершиныToolStripMenuItem,
            this.поменятьЦветToolStripMenuItem,
            this.анимацияToolStripMenuItem,
            this.изменитьToolStripMenuItem,
            this.таймерToolStripMenuItem,
            this.undoredoToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлыToolStripMenuItem
            // 
            this.файлыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filenewToolStripMenuItem,
            this.filesaveToolStripMenuItem,
            this.fileopenToolStripMenuItem});
            this.файлыToolStripMenuItem.Name = "файлыToolStripMenuItem";
            this.файлыToolStripMenuItem.Size = new System.Drawing.Size(70, 24);
            this.файлыToolStripMenuItem.Text = "Файлы";
            // 
            // filenewToolStripMenuItem
            // 
            this.filenewToolStripMenuItem.Name = "filenewToolStripMenuItem";
            this.filenewToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.filenewToolStripMenuItem.Text = "file-new";
            this.filenewToolStripMenuItem.Click += new System.EventHandler(this.filenewToolStripMenuItem_Click);
            // 
            // filesaveToolStripMenuItem
            // 
            this.filesaveToolStripMenuItem.Name = "filesaveToolStripMenuItem";
            this.filesaveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.filesaveToolStripMenuItem.Text = "file-save";
            this.filesaveToolStripMenuItem.Click += new System.EventHandler(this.filesaveToolStripMenuItem_Click);
            // 
            // fileopenToolStripMenuItem
            // 
            this.fileopenToolStripMenuItem.Name = "fileopenToolStripMenuItem";
            this.fileopenToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.fileopenToolStripMenuItem.Text = "file-open";
            this.fileopenToolStripMenuItem.Click += new System.EventHandler(this.fileopenToolStripMenuItem_Click);
            // 
            // вершиныToolStripMenuItem
            // 
            this.вершиныToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.квадратToolStripMenuItem,
            this.треугольникToolStripMenuItem,
            this.кругToolStripMenuItem});
            this.вершиныToolStripMenuItem.Name = "вершиныToolStripMenuItem";
            this.вершиныToolStripMenuItem.Size = new System.Drawing.Size(90, 24);
            this.вершиныToolStripMenuItem.Text = "Вершины";
            // 
            // квадратToolStripMenuItem
            // 
            this.квадратToolStripMenuItem.Name = "квадратToolStripMenuItem";
            this.квадратToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.квадратToolStripMenuItem.Text = "Квадрат";
            this.квадратToolStripMenuItem.Click += new System.EventHandler(this.квадратToolStripMenuItem_Click);
            // 
            // треугольникToolStripMenuItem
            // 
            this.треугольникToolStripMenuItem.Name = "треугольникToolStripMenuItem";
            this.треугольникToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.треугольникToolStripMenuItem.Text = "Треугольник";
            this.треугольникToolStripMenuItem.Click += new System.EventHandler(this.ТреугольникToolStripMenuItem_Click);
            // 
            // кругToolStripMenuItem
            // 
            this.кругToolStripMenuItem.Name = "кругToolStripMenuItem";
            this.кругToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.кругToolStripMenuItem.Text = "Круг";
            this.кругToolStripMenuItem.Click += new System.EventHandler(this.КругToolStripMenuItem_Click);
            // 
            // поменятьЦветToolStripMenuItem
            // 
            this.поменятьЦветToolStripMenuItem.Name = "поменятьЦветToolStripMenuItem";
            this.поменятьЦветToolStripMenuItem.Size = new System.Drawing.Size(128, 24);
            this.поменятьЦветToolStripMenuItem.Text = "Поменять цвет";
            this.поменятьЦветToolStripMenuItem.Click += new System.EventHandler(this.поменятьЦветToolStripMenuItem_Click);
            // 
            // анимацияToolStripMenuItem
            // 
            this.анимацияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pLAYToolStripMenuItem,
            this.sTOPToolStripMenuItem});
            this.анимацияToolStripMenuItem.Name = "анимацияToolStripMenuItem";
            this.анимацияToolStripMenuItem.Size = new System.Drawing.Size(96, 24);
            this.анимацияToolStripMenuItem.Text = "Анимация";
            // 
            // pLAYToolStripMenuItem
            // 
            this.pLAYToolStripMenuItem.Name = "pLAYToolStripMenuItem";
            this.pLAYToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.pLAYToolStripMenuItem.Text = "PLAY";
            this.pLAYToolStripMenuItem.Click += new System.EventHandler(this.pLAYToolStripMenuItem_Click);
            // 
            // sTOPToolStripMenuItem
            // 
            this.sTOPToolStripMenuItem.Name = "sTOPToolStripMenuItem";
            this.sTOPToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.sTOPToolStripMenuItem.Text = "STOP";
            this.sTOPToolStripMenuItem.Click += new System.EventHandler(this.sTOPToolStripMenuItem_Click);
            // 
            // изменитьToolStripMenuItem
            // 
            this.изменитьToolStripMenuItem.Name = "изменитьToolStripMenuItem";
            this.изменитьToolStripMenuItem.Size = new System.Drawing.Size(148, 24);
            this.изменитьToolStripMenuItem.Text = "Изменить размер";
            this.изменитьToolStripMenuItem.Click += new System.EventHandler(this.изменитьToolStripMenuItem_Click);
            // 
            // таймерToolStripMenuItem
            // 
            this.таймерToolStripMenuItem.Name = "таймерToolStripMenuItem";
            this.таймерToolStripMenuItem.Size = new System.Drawing.Size(76, 24);
            this.таймерToolStripMenuItem.Text = "Таймер";
            this.таймерToolStripMenuItem.Click += new System.EventHandler(this.таймерToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.InitialDirectory = "C:\\\\Users\\\\ivmas\\\\OneDrive\\\\Documents\\\\Проекты Вани\\\\Проекты по программированию " +
    "10.5 Visual Studio C#\\\\Мнизадача_4_Машкарин_Иван\\\\Мнизадача_4_Машкарин_Иван\\\\bin" +
    "\\\\Debug";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.InitialDirectory = "C:\\\\Users\\\\ivmas\\\\OneDrive\\\\Documents\\\\Проекты Вани\\\\Проекты по программированию " +
    "10.5 Visual Studio C#\\\\Мнизадача_4_Машкарин_Иван\\\\Мнизадача_4_Машкарин_Иван\\\\bin" +
    "\\\\Debug";
            // 
            // undoredoToolStripMenuItem
            // 
            this.undoredoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem});
            this.undoredoToolStripMenuItem.Name = "undoredoToolStripMenuItem";
            this.undoredoToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.undoredoToolStripMenuItem.Text = "undo/redo";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Главная форма";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem вершиныToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem квадратToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem треугольникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem кругToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem поменятьЦветToolStripMenuItem;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem анимацияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pLAYToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sTOPToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripMenuItem изменитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem таймерToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem файлыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filenewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filesaveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileopenToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem undoredoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
    }
}

