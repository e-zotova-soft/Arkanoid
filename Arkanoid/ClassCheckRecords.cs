using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections;

namespace Arkanoid
{
    class ClassCheckRecords
    {
        FormRecord Fr = new FormRecord();
        string UserName = "Anonymous";

        public ClassCheckRecords()
        {
            //CheckRecords(ClassConstants.Count_Points);
        }

        public void CheckRecords(int Po)
        {
            
            StreamReader sr = File.OpenText("Records.txt");
            string input = null;
            ArrayList records = new ArrayList();

            while ((input = sr.ReadLine()) != null)
            {
                ClassResult CR = new ClassResult(ClassMoving.ToWords(input, 2)[0], Convert.ToInt32(ClassMoving.ToWords(input, 2)[1]));
                records.Add(CR);

            }

            sr.Close();

            records.Sort(ClassResult.SortByPoint);
            // самый младший рекорд в таблице
            ClassResult Cr = (ClassResult)records[0];
            // если его удалось победить
            if (Po > Cr.ResPoint)
            {
                //MessageBox.Show("Ваш результат - это новый рекорд!");
                Fr.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Fr_FormClosing);
                Fr.tbName.Focus();
                Fr.ShowDialog();
                FileInfo fi = new FileInfo("Records.txt");
                StreamWriter writer;
                // если результат влезает в десятку
                if (records.Count < 10)
                {
                    records.Add(new ClassResult(UserName, Po));
                    // и дописать файл новым рекордом
                    writer = fi.AppendText();
                    writer.WriteLine(UserName + " " + Po.ToString());
                    writer.Close();
                }
                // иначе - удалить последнего
                else
                //if (Po > Cr.ResPoint)
                {
                    records.Remove(records[0]);
                    records.Add(new ClassResult(UserName, Po));
                    // и дописать файл новым рекордом
                    writer = fi.CreateText();
                    for (int i = 0; i < records.Count; i++)
                    {
                        Cr = (ClassResult)records[i];
                        writer.WriteLine(Cr.ResName + " " + Cr.ResPoint.ToString());
                    }
                    writer.Close();
                }
            }
        }

        void Fr_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (Fr.tbName.Text != "")
            {
                UserName = Fr.tbName.Text;
            }
        }
        //---------------------------
    }
}
