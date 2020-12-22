using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace taskagitmakasoyunu
{
    public partial class Form1 : Form
    {
        List<hareket> hl = new List<hareket>();
        public Form1()
        {
            InitializeComponent();
            //tas için
            hareket tas = new hareket();
            tas.metin = "tas";
            tas.numara = 0;
            tas.resim = taskagitmakasoyunu.Properties.Resources.tas;
            //kagit için
            hareket kagit = new hareket();
            kagit.metin = "kağıt";
            kagit.numara = 1;
            kagit.resim = taskagitmakasoyunu.Properties.Resources.kagit;
            //makas için
            hareket makas = new hareket();
            makas.metin = "makas";
            makas.numara = 2;
            makas.resim = taskagitmakasoyunu.Properties.Resources.makas;
            //list içine ekle
            hl.Add(tas);
            hl.Add(kagit);
            hl.Add(makas);
        }
        public class hareket
        {
            public int numara { get; set; }
            public string metin { get; set; }
            public Bitmap resim { get; set; }
        }
        private void Ptas_Click_1(object sender, EventArgs e)
        {
            int tag = Convert.ToInt32((sender as PictureBox).Tag);
            var secilen = hl[tag];
            //kullanıcı hareketini ortadaki picturebox a al!!!
            pkullanici.Image = secilen.resim;
            labelsecilenkullanici.Text = secilen.metin;
            //pc hareketini ortadaki pictureboxa al!!!
            Random rnd = new Random();
            int csecilenid = rnd.Next(0, 3);
            var csecilen = hl[csecilenid];
            ppc.Image = csecilen.resim;
            labelsecilenpc.Text = csecilen.metin;
            //kim kazandı berabere mi kaldı?
            if (secilen.numara==csecilen.numara)
            {
                labelsonuc.Text = "BERABERE!";
                labelsonuc.ForeColor = Color.Black;
            }
            else if (secilen.numara==0&&csecilen.numara==3||
                secilen.numara==1&&csecilen.numara==0||
                secilen.numara==2&&csecilen.numara==1
                )
            {
                labelsonuc.Text = "KULLANICI KAZANDI!";
                labelsonuc.ForeColor = Color.Green;
                labelkullaniciskor.Text = (int.Parse(labelkullaniciskor.Text)+1).ToString();
                if (labelkullaniciskor.Text=="5")
                {
                    MessageBox.Show("KULLANICI KAZANDI!");
                    Application.Restart();
                }
            }
            else
            {
                labelsonuc.Text = "BİLGİSAYAR KAZANDI!";
                labelsonuc.ForeColor = Color.Red;
                labelbilgisayarskor.Text = (int.Parse(labelbilgisayarskor.Text)+1).ToString();
                if (labelbilgisayarskor.Text=="5")
                {
                    MessageBox.Show("BİLGİSAYAR KAZANDI!");
                    Application.Restart();
                }
            }
        }
    }
}
