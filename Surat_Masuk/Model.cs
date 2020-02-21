using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Surat_Masuk
{
    public class Surat
    {
        public int id { get; set; }
        public string nomor_berkas { get; set; }
        public string alamat { get; set; }
        public string tgl { get; set; }
        public string perihal { get; set; }
        public string nomor_petunjuk { get; set; }
        public string ket { get; set; }
        public string jenis_surat { get; set; }
    }
}
