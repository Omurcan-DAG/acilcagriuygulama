using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace acilcagrimerkeziveritabanı.UI
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public string saattarih
        {
            get => maskedTextBox2.Text;
            set => maskedTextBox2.Text = value;
        }
        public string adı
        {
            get => textBox1.Text;
            set => textBox1.Text = value;
        }
        public string soyadı
        {
            get => textBox2.Text;
            set => textBox2.Text = value;
        }

        public string telefon
        {
            get => maskedTextBox1.Text;
            set => maskedTextBox1.Text = value;
        }

        public string adres
        {
            get => textBox3.Text;
            set => textBox3.Text = value;
        }
        public string birim
        {
            get => textBox4.Text;
            set => textBox4.Text = value;
        }
        public string olay
        {
            get => textBox5.Text;
            set => textBox5.Text = value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
