using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Arkanoid
{
    public partial class FormTableRecs : Form
    {
        public FormTableRecs()
        {
            InitializeComponent();
        }

        private void FormTableRecs_Load(object sender, EventArgs e)
        {
            StreamReader sr = File.OpenText("Records.txt");
            string input = null;
            System.Collections.ArrayList records = new System.Collections.ArrayList();

            while ((input = sr.ReadLine()) != null)
            {
                ClassResult CR = new ClassResult(ClassMoving.ToWords(input, 2)[0], Convert.ToInt32(ClassMoving.ToWords(input, 2)[1]));
                records.Add(CR);
            }
            sr.Close();
            records.Sort(ClassResult.SortByPoint);
            records.Reverse();

            for (int i = 0; i < records.Count; i++)
            {
                ClassResult CR = (ClassResult)records[i];
                dgRecords.Rows.Add(CR.ResName, CR.ResPoint);
            }
        }

        private void button1Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        //------------
    }
}
