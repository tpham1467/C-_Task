using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            TienEntities db = new TienEntities();

            GiaTien gt = db.GiaTiens.Find("1");
            textBox1.Text = gt.C_Money.ToString();
        }
        public async Task CongTien()
        {
            Task t = new Task( () =>
            {
                TienEntities db = new TienEntities();

                GiaTien gt = db.GiaTiens.Find("1");
                gt.C_Money += 2;
                 db.SaveChanges();
            });
            t.Start();
            await t;
         
        }
    
         private async void Button1_Click(object sender, EventArgs e)
        {
           await CongTien();

            TienEntities db = new TienEntities();

            GiaTien gt = db.GiaTiens.Find("1");
            textBox1.Text = gt.C_Money.ToString();
        }
    }
}
