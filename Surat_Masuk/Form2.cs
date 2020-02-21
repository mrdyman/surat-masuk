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
                lblnpm.Text = s.nomor_berkas;
                lblnama.Text = s.alamat;
                lbljudul.Text = s.tgl;
                lbljumlah.Text = s.perihal;
                lblpembimbing1.Text = s.nomor_petunjuk;
                lblpembimbing2.Text = s.ket;
                lblpembimbing2.Text = s.jenis_surat;
            }
        }
    }
}
