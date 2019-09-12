namespace Arkanoid
{
    partial class FormArkanoid
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.играToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.начатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.паузаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.рекордыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.уровеньToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.случайноToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.поПорядкуtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timerArkanoid = new System.Windows.Forms.Timer(this.components);
            this.openLevel = new System.Windows.Forms.OpenFileDialog();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusGame = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusBallCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusPoints = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.играToolStripMenuItem,
            this.уровеньToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(576, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // играToolStripMenuItem
            // 
            this.играToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяtoolStripMenuItem,
            this.начатьToolStripMenuItem,
            this.паузаToolStripMenuItem,
            this.рекордыToolStripMenuItem,
            this.выходToolStripMenuItem});
            this.играToolStripMenuItem.Name = "играToolStripMenuItem";
            this.играToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.играToolStripMenuItem.Text = "Игра";
            // 
            // новаяtoolStripMenuItem
            // 
            this.новаяtoolStripMenuItem.Name = "новаяtoolStripMenuItem";
            this.новаяtoolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.новаяtoolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.новаяtoolStripMenuItem.Text = "Новая";
            this.новаяtoolStripMenuItem.Click += new System.EventHandler(this.новаяtoolStripMenuItem_Click);
            // 
            // начатьToolStripMenuItem
            // 
            this.начатьToolStripMenuItem.Name = "начатьToolStripMenuItem";
            this.начатьToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.начатьToolStripMenuItem.Text = "Начать (Enter)";
            this.начатьToolStripMenuItem.Click += new System.EventHandler(this.начатьToolStripMenuItem_Click);
            // 
            // паузаToolStripMenuItem
            // 
            this.паузаToolStripMenuItem.Name = "паузаToolStripMenuItem";
            this.паузаToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.паузаToolStripMenuItem.Text = "Пауза (P)";
            this.паузаToolStripMenuItem.Click += new System.EventHandler(this.паузаToolStripMenuItem_Click);
            // 
            // рекордыToolStripMenuItem
            // 
            this.рекордыToolStripMenuItem.Name = "рекордыToolStripMenuItem";
            this.рекордыToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.рекордыToolStripMenuItem.Text = "Рекорды";
            this.рекордыToolStripMenuItem.Click += new System.EventHandler(this.рекордыToolStripMenuItem_Click);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // уровеньToolStripMenuItem
            // 
            this.уровеньToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.случайноToolStripMenuItem,
            this.поПорядкуtoolStripMenuItem});
            this.уровеньToolStripMenuItem.Name = "уровеньToolStripMenuItem";
            this.уровеньToolStripMenuItem.Size = new System.Drawing.Size(62, 20);
            this.уровеньToolStripMenuItem.Text = "Уровень";
            // 
            // случайноToolStripMenuItem
            // 
            this.случайноToolStripMenuItem.Name = "случайноToolStripMenuItem";
            this.случайноToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.случайноToolStripMenuItem.Text = "Случайно";
            this.случайноToolStripMenuItem.Click += new System.EventHandler(this.случайноToolStripMenuItem_Click);
            // 
            // поПорядкуtoolStripMenuItem
            // 
            this.поПорядкуtoolStripMenuItem.Name = "поПорядкуtoolStripMenuItem";
            this.поПорядкуtoolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.поПорядкуtoolStripMenuItem.Text = "По порядку";
            this.поПорядкуtoolStripMenuItem.Click += new System.EventHandler(this.поПорядкуtoolStripMenuItem_Click);
            // 
            // timerArkanoid
            // 
            this.timerArkanoid.Tick += new System.EventHandler(this.timerArkanoid_Tick);
            // 
            // openLevel
            // 
            this.openLevel.FileName = "openFileDialog1";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 24);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(576, 293);
            this.panel1.TabIndex = 2;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // statusGame
            // 
            this.statusGame.Name = "statusGame";
            this.statusGame.Size = new System.Drawing.Size(81, 17);
            this.statusGame.Text = "Нажмите Enter";
            // 
            // statusBallCount
            // 
            this.statusBallCount.Name = "statusBallCount";
            this.statusBallCount.Size = new System.Drawing.Size(52, 17);
            this.statusBallCount.Text = "Мячей: 3";
            // 
            // statusPoints
            // 
            this.statusPoints.Name = "statusPoints";
            this.statusPoints.Size = new System.Drawing.Size(52, 17);
            this.statusPoints.Text = "  Очки: 0";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusBallCount,
            this.statusPoints,
            this.statusGame});
            this.statusStrip1.Location = new System.Drawing.Point(0, 317);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(576, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // FormArkanoid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(576, 339);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormArkanoid";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Арканоид";
            this.Load += new System.EventHandler(this.FormArkanoid_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormArkanoid_KeyUp);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormArkanoid_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer timerArkanoid;
        private System.Windows.Forms.ToolStripMenuItem играToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem начатьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem паузаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem рекордыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem уровеньToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem случайноToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openLevel;
        private System.Windows.Forms.ToolStripMenuItem поПорядкуtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяtoolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripStatusLabel statusGame;
        private System.Windows.Forms.ToolStripStatusLabel statusBallCount;
        private System.Windows.Forms.ToolStripStatusLabel statusPoints;
        private System.Windows.Forms.StatusStrip statusStrip1;

    }
}

