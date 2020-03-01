using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using System.Data.SQLite;

namespace Surat_Masuk
{
    public partial class Form1 : MaterialSkin.Controls.MaterialForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnSimpan_Click(object sender, EventArgs e)
        {
            Surat skripsi = new Surat();
            skripsi.nomor_berkas = txtNoBerkas.Text;
            skripsi.alamat = txtAlamat.Text;
            skripsi.tgl = dtpTgl.Text;
            skripsi.perihal = txtPerihal.Text;
            skripsi.nomor_petunjuk = txtNoPetunjuk.Text;
            skripsi.ket = txtKet.Text;
            skripsi.jenis_surat = cmbJenis_Surat.Text;
            DbQuery.InsertSurat(skripsi);
            MessageBox.Show("Data Tersimpan!");

        }

        private void BtnReset_Click(object sender, EventArgs e)
        {
            txtNoBerkas.Text = "";
            txtNoBerkas.Text = "";
            txtAlamat.Text = "";
            txtNoPetunjuk.Text = "";
            txtKet.Text = "";
            txtNoBerkas.Text = "";
        }

        public void RefDataSurat_Masuk()
        {
            mlvDataSkripsi.Items.Clear();
            List<Surat> skripsi = DbQuery.GetDataSurat_Masuk();
            int j = 1;
            foreach (var s in skripsi)
            {
                ListViewItem i = new ListViewItem(j.ToString());
                i.SubItems.Add(s.nomor_berkas.Trim());
                i.SubItems.Add(s.alamat.Trim());
                i.SubItems.Add(s.tgl.Trim());
                i.SubItems.Add(s.perihal.ToString());
                i.SubItems.Add(s.nomor_petunjuk.Trim());
                i.SubItems.Add(s.ket.ToString());
                i.SubItems.Add(s.jenis_surat.Trim());
                mlvDataSkripsi.Items.Add(i);
                j++;
            }
        }

        public void RefAllDataSurat()
        {
            RefDataSurat_Masuk();
            RefDataSurat_Keluar();
        }

        public void RefDataSurat_Keluar()
        {
            mlvpsik.Items.Clear();
            List<Surat> skripsi = DbQuery.GetDataSurat_Keluar();
            int j = 1;
            foreach (var s in skripsi)
            {
                ListViewItem i = new ListViewItem(j.ToString());
                i.SubItems.Add(s.nomor_berkas.Trim());
                i.SubItems.Add(s.alamat.Trim());
                i.SubItems.Add(s.tgl.Trim());
                i.SubItems.Add(s.perihal.ToString());
                i.SubItems.Add(s.nomor_petunjuk.Trim());
                i.SubItems.Add(s.ket.ToString());
                i.SubItems.Add(s.jenis_surat.Trim());
                mlvpsik.Items.Add(i);
                j++;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RefDataSurat_Masuk();
            RefDataSurat_Keluar();
        }

        private void MlvDataSkripsi_DoubleClick(object sender, EventArgs e)
        {
            Form2 dspd = new Form2();
            dspd.id = Int32.Parse(mlvDataSkripsi.SelectedItems[0].SubItems[0].Text);
            dspd.ShowDialog();
        }

        private void MaterialRaisedButton2_Click(object sender, EventArgs e)
        {
            RefDataSurat_Masuk();
        }

        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabpage1");
        }

        private void MaterialRaisedButton3_Click(object sender, EventArgs e)
        {
            RefDataSurat_Keluar();
        }

        private void MaterialRaisedButton4_Click(object sender, EventArgs e)
        {
            materialTabControl1.SelectTab("tabpage1");
        }

        private void TxtPerihal_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtPerihal.Text == "Masukkan Perihal")
            {
                txtPerihal.Text = "";
            }
        }

        private void TxtNoBerkas_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (txtNoBerkas.Text == "Masukkan Nomor Berkas")
            {
                txtNoBerkas.Text = "";
            }
        }

        private void TxtAlamat_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtAlamat.Text == "Masukkan Alamat")
            {
                txtAlamat.Text = "";
            }
        }

        private void TxtNoPetunjuk_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNoPetunjuk.Text == "Masukkan Nomor Petunjuk")
            {
                txtNoPetunjuk.Text = "";
            }
        }

        private void TxtKet_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtKet.Text == "Masukkan Keterangan")
            {
                txtKet.Text = "";
            }
        }

        private void CmbJenis_Surat_MouseClick(object sender, MouseEventArgs e)
        {
            if (cmbJenis_Surat.Text == "Pilih Jenis Surat")
            {
                cmbJenis_Surat.Text = "";
            }
        }

        private void TxtNoBerkas_Leave(object sender, EventArgs e)
        {
            if (txtNoBerkas.Text == "")
            {
                txtNoBerkas.Text = "Masukkan Nomor Berkas";
            }
        }

        private void TxtAlamat_Leave(object sender, EventArgs e)
        {
            if (txtAlamat.Text == "")
            {
                txtAlamat.Text = "Masukkan Alamat";
            }
        }

        private void TxtPerihal_Leave(object sender, EventArgs e)
        {
            if (txtPerihal.Text == "")
            {
                txtPerihal.Text = "Masukkan Perihal";
            }
        }

        private void TxtNoPetunjuk_Leave(object sender, EventArgs e)
        {
            if (txtNoPetunjuk.Text == "")
            {
                txtNoPetunjuk.Text = "Masukkan Nomor Petunjuk";
            }
        }

        private void TxtKet_Leave(object sender, EventArgs e)
        {
            if (txtKet.Text == "")
            {
                txtKet.Text = "Masukkan Keterangan";
            }
        }

        private void CmbJenis_Surat_Leave(object sender, EventArgs e)
        {
            if (cmbJenis_Surat.Text == "")
            {
                cmbJenis_Surat.Text = "Pilih Jenis Surat";
            }
        }

        private void TextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            mlvDataSkripsi.Items.Clear();
            List<Surat> spd = DbQuery.getSurat_Masuk(textBox1.Text);
            int j = 1;
            foreach (var s in spd)
            {
              ListViewItem i = new ListViewItem(j.ToString());
              i.SubItems.Add(s.nomor_berkas.Trim());
              i.SubItems.Add(s.alamat.Trim());
              i.SubItems.Add(s.tgl.Trim());
              i.SubItems.Add(s.perihal.Trim());
              i.SubItems.Add(s.nomor_petunjuk.Trim());
              i.SubItems.Add(s.ket.Trim());
              i.SubItems.Add(s.jenis_surat.Trim());
              mlvDataSkripsi.Items.Add(i);
               j++;
            }
            if (textBox1.Text == "")
            {
                RefDataSurat_Masuk();
            } 
        }

        private void TextBox3_KeyUp(object sender, KeyEventArgs e)
        {
            mlvpsik.Items.Clear();
            List<Surat> spd = DbQuery.getSurat_Keluar(textBox3.Text);
            int j = 1;
            foreach (var s in spd)
            {
                ListViewItem i = new ListViewItem(j.ToString());
                i.SubItems.Add(s.nomor_berkas.Trim());
                i.SubItems.Add(s.alamat.Trim());
                i.SubItems.Add(s.tgl.Trim());
                i.SubItems.Add(s.perihal.Trim());
                i.SubItems.Add(s.nomor_petunjuk.Trim());
                i.SubItems.Add(s.ket.Trim());
                i.SubItems.Add(s.jenis_surat.Trim());
                mlvpsik.Items.Add(i);
                j++;
            }
            if (textBox3.Text == "")
            {
                RefDataSurat_Keluar();
            }
        }

        private void MaterialTabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void MaterialTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
