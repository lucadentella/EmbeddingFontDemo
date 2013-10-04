using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Text;

namespace EmbeddingFontDemo
{
    public partial class Form1 : Form
    {

        private PrivateFontCollection pfc = new PrivateFontCollection();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Stream fontStream = this.GetType().Assembly.GetManifestResourceStream("EmbeddingFontDemo.always_forever.ttf");
            byte[] fontdata = new byte[fontStream.Length];
            fontStream.Read(fontdata, 0, (int)fontStream.Length);
            fontStream.Close();

            unsafe
            {
                fixed (byte* pFontData = fontdata)
                {
                    pfc.AddMemoryFont((System.IntPtr)pFontData, fontdata.Length);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Font = new Font(pfc.Families[0], 30, FontStyle.Regular);
            label1.Text = "Hello World!";
        }
    }
}
