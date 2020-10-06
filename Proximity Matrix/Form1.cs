﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.FileIO;

namespace Proximity_Matrix
{
    public partial class Form1 : Form
    {
        OpenFileDialog open;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            open = new OpenFileDialog
            {
                InitialDirectory = Directory.GetCurrentDirectory(),
                Filter = "Comma Separated|*.csv"
            };

            open.ShowDialog();
        
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ArrayList list = new ArrayList();
            try
            {

                if (open.FileName != "")
                {
                    using (TextFieldParser csvParser = new TextFieldParser(open.FileName))
                    {
                        csvParser.CommentTokens = new string[] { "#" };
                        csvParser.SetDelimiters(new string[] { "," });
                        csvParser.HasFieldsEnclosedInQuotes = true;

                        csvParser.ReadLine();



                        while (!csvParser.EndOfData)
                        {
                            string[] fields = csvParser.ReadFields();
                            Person person = new Person(fields[0], fields[1], int.Parse(fields[2]), fields[3]);
                            list.Add(person);
                        }


                    }

                    if (list.Count > 0)
                    {
                        dataGridViewCSV.DataSource = list;
                    }



                }
                else
                {
                    MessageBox.Show("File Kosong", "Error");
                }
            }
            catch(Exception error)
            {
                MessageBox.Show("Tidak Bisa Menampilkan FIle", "Error");
            }
            
           
        }
    }
}
