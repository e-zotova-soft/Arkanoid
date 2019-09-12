namespace Arkanoid
{
    partial class FormTableRecs
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
            this.dgRecords = new System.Windows.Forms.DataGridView();
            this.button1Close = new System.Windows.Forms.Button();
            this.PlayerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlayePoints = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgRecords)).BeginInit();
            this.SuspendLayout();
            // 
            // dgRecords
            // 
            this.dgRecords.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgRecords.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PlayerName,
            this.PlayePoints});
            this.dgRecords.Location = new System.Drawing.Point(3, 2);
            this.dgRecords.Name = "dgRecords";
            this.dgRecords.ReadOnly = true;
            this.dgRecords.Size = new System.Drawing.Size(244, 316);
            this.dgRecords.TabIndex = 0;
            // 
            // button1Close
            // 
            this.button1Close.Location = new System.Drawing.Point(66, 325);
            this.button1Close.Name = "button1Close";
            this.button1Close.Size = new System.Drawing.Size(112, 36);
            this.button1Close.TabIndex = 1;
            this.button1Close.Text = "Закрыть";
            this.button1Close.UseVisualStyleBackColor = true;
            this.button1Close.Click += new System.EventHandler(this.button1Close_Click);
            // 
            // PlayerName
            // 
            this.PlayerName.HeaderText = "Имя";
            this.PlayerName.Name = "PlayerName";
            this.PlayerName.ReadOnly = true;
            this.PlayerName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // PlayePoints
            // 
            this.PlayePoints.HeaderText = "Набранных очков:";
            this.PlayePoints.Name = "PlayePoints";
            this.PlayePoints.ReadOnly = true;
            // 
            // FormTableRecs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(249, 370);
            this.Controls.Add(this.button1Close);
            this.Controls.Add(this.dgRecords);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormTableRecs";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Лучшие результаты";
            this.Load += new System.EventHandler(this.FormTableRecs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgRecords)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgRecords;
        private System.Windows.Forms.Button button1Close;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlayePoints;
    }
}