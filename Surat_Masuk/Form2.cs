using System;
using System.Collections.Generic;
using System.Globalization;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Surat_Masuk
{
    public partial class Form2 : MaterialSkin.Controls.MaterialForm
    {
        public int id { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

       List<Surat> skripsi;

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 frm1 = new Form1();
            skripsi = DbQuery.getDataSkripsiById(id);
            foreach (var s in skripsi)
            {
                lblnoberkas.Text = s.nomor_berkas;
                lblalamat.Text = s.alamat;
                lbltgl.Text = s.tgl;
                lblperihal.Text = s.perihal;
                lblpetunjuk.Text = s.nomor_petunjuk;
                lblket.Text = s.ket;
                lbljenis.Text = s.jenis_surat;
            }
        }

        private void BtnTutup_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnHapus_Click(object sender, EventArgs e)
        {
                Surat p = DbQuery.GetSuratById(id);
                var msgResult = MessageBox.Show("Data Dengan No. Berkas " + p.nomor_berkas + " Akan Dihapus!!!", "Confirm Delete!!", MessageBoxButtons.YesNo);
                if (msgResult == DialogResult.Yes)
                {
                int result = DbQuery.DeleteSurat(id);
                    string msg = "Terjadi Kesalahan Pada Saat Menghapus Data";
                    if (result > 0)
                    {
                        msg = "Berhasil! Data Telah Terhapus";
                    }
                    MessageBox.Show(msg);
                    if (Application.OpenForms["Form1"] != null)
                    {
                    (Application.OpenForms["Form1"] as Form1).RefAllDataSurat();
                    }
                    this.Close();
                }
            
        }
    }
}
