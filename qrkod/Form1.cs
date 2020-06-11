using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Imaging;
using MessagingToolkit.QRCode;
using MessagingToolkit.QRCode.Codec;
using System.Drawing.Printing;
using MessagingToolkit.QRCode.Codec.Data;
using System.Windows.Forms;

namespace qrkod
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private static Image CreateQrCode(string value)
        {
            var qe = new QRCodeEncoder
            {
                QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE,
                QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.L,
                QRCodeVersion = 1
            };
            var btmp = qe.Encode(value);
            return btmp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            //pictureBox1.Image = CreateQrCode(textBox1.Text + textBox2.Text);
            pictureBox1.Image = CreateQrCode( textBox1.Text + Environment.NewLine + textBox2.Text + Environment.NewLine);
            button2.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument1 = new PrintDocument();
            printDocument1.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);
            printDocument1.Print();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 0, 0);
        }
        
       

      
    }
}
