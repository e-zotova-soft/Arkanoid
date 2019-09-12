using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arkanoid
{
    public partial class FormRecord : Form
    {
        private Button buttonOK;
        private Label label1;
        public TextBox tbName;
    
        public FormRecord()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(34, 64);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(101, 33);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(18, 38);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(137, 20);
            this.tbName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ваше имя:";
            // 
            // FormRecord
            // 
            this.ClientSize = new System.Drawing.Size(177, 111);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormRecord";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Новый рекорд!";
            this.Load += new System.EventHandler(this.FormRecord_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FormRecord_Load(object sender, EventArgs e)
        {
            
        }

        
    }
}
