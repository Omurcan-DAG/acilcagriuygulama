using acilcagrimerkeziveritabanıBL;

namespace acilcagrimerkeziveritabanı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Load += delegate
            {
                BL.tumcagrilerilistele();

                Listele();
            };
        }

        void Listele()
        {
            foreach (var k in BL.cagriler)
            {
                cagriyilisteyeekle(k);
            }
        }

        void KisiyiListeyeEkle(cagri k)
        {
            ListViewItem cagri = new ListViewItem(new string[]
                {
                    k.saattarih,
                    k.adı,
                    k.soyadı,
                    k.telefon,
                    k.adres,
                    k.birim,
                    k.olay
                });

            cagri.Tag = k;

            listView1.Items.Add(cagri);
        }

        private void cagri_ara(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            BL.cagribul(toolStripTextBox1.Text);

            Listele();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frmcagri frm = new Frmcagri()
            {
                Text = "cagri ekle",
                FormBorderStyle = FormBorderStyle.FixedToolWindow,
                StartPosition = FormStartPosition.CenterParent
            };

            if (frm.ShowDialog() == DialogResult.OK)
            {
                var res = BL.cagriekle(frm.saatarih, frm.adı, frm.soyadı, frm.telefon, frm.adres, frmbirim., frm.olay);
                if (res == false)
                    HataGöster();
                else
                    cagriyilisteyeekle(BL.cagriler[BL.cagriler.Count - 1]);
            }
        }
        void HataGöster()
        {
            MessageBox.Show("Hata ayrıntıları:\n" + BL.error, "Hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}