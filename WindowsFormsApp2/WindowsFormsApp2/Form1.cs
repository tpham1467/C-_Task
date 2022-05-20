using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            using (TienEntities db = new TienEntities())
            {
                GiaTien x = new GiaTien();
                x = db.GiaTiens.Find("1");
                textBox1.Text = x.C_Money.ToString();
            }
            Task t = new Task(Update2);
            t.Start();
        }
        delegate void SetTextCallback(string text);

        private void SetText(string text)
        {
            // InvokeRequired required compares the thread ID of the
            // calling thread to the thread ID of the creating thread.
            // If these threads are different, it returns true.
            if (this.textBox1.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBox1.Text = text;
            }
        }
        public void Update2()
        {
            while(true)
            {
                bool check = false;
                using (TienEntities db = new TienEntities())
                {
                    GiaTien t = new GiaTien();
                    t = db.GiaTiens.Find("1");
                    lock (textBox1)
                    {
                        if (textBox1.Text!=t.C_Money.ToString())
                        {
                           check = true;
                        }
                    }
                    if(check)
                    {
                        SetText(t.C_Money.ToString());
                    }
                    
                }
           //     lock ()
                Task.Delay(500);
            }
        }
    }
   
}
