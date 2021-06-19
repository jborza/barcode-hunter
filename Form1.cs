using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace SmartDeviceProject1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            db = new DB();
            db.Load();
            ShowScore();
        }

        DB db;

        private void ShowScore()
        {
            labelScore.Text = db.Count.ToString();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                string barcode = textBox1.Text;
                AcceptBarcode(textBox1.Text);
                textBox1.Text = "";
            }
            else
                label2.Text = e.KeyChar+"";
        }

        private void AcceptBarcode(string barcode)
        {
            if (db.Contains(barcode))
            {
                ShowSuccess(false); //TODO buzz
                return;
            }
            ShowSuccess(true);
            db.AddBarcode(barcode);
            db.Save();
            ShowScore();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Beep.MessageBeep(Beep.QUESTION);   
        }

        private void ShowSuccess(bool success){
            labelRecent.Text = success ? ":)" : ":(";
            Beep.MessageBeep(success ? Beep.ASTERISK : Beep.OK);
        }
    }
}