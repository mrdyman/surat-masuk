using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Surat_Masuk
{
   public static class DbQuery
    {
        private static string connectionString;
        static DbQuery()
        {
            string executable = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string path = (System.IO.Path.GetDirectoryName(executable));
            AppDomain.CurrentDomain.SetData("DataDirectory", path);
            connectionString = @"Data Source=|DataDirectory|\Databases\surat_masuk.db; Version=3; FailIfMissing=True; Foreign Keys=True;";
        }

        static SQLiteConnection _Connection = null;
        public static SQLiteConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    _Connection = new SQLiteConnection(connectionString);
                    _Connection.Open();

                    return _Connection;
                }
                else if (_Connection.State != System.Data.ConnectionState.Open)
                {
                    _Connection.Open();

                    return _Connection;
                }
                else
                {
                    return _Connection;
                }
            }
        }

        public static int InsertSurat(Surat surat)
        {
            int r = -1;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO data_surat (nomor_berkas, alamat, tgl, perihal, nomor_petunjuk, ket, jenis_surat) VALUES (@nomor_berkas, @alamat, @tgl, @perihal, @nomor_petunjuk, @ket, @jenis_surat)";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@nomor_berkas", surat.nomor_berkas);
                    cmd.Parameters.AddWithValue("@alamat", surat.alamat);
                    cmd.Parameters.AddWithValue("@tgl", surat.tgl);
                    cmd.Parameters.AddWithValue("@perihal", surat.perihal);
                    cmd.Parameters.AddWithValue("@nomor_petunjuk", surat.nomor_petunjuk);
                    cmd.Parameters.AddWithValue("@ket", surat.ket);
                    cmd.Parameters.AddWithValue("@jenis_surat", surat.jenis_surat);

                    try
                    {
                        r = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        throw;
                    }
                }
                conn.Close();
            }
            return r;
        }

        public static List<Surat> GetDataSurat_Masuk()
        {
            List<Surat> Surat = new List<Surat>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM data_surat WHERE jenis_surat = 'Surat Masuk'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Surat p = new Surat();
                                p.nomor_berkas = reader["nomor_berkas"].ToString();
                                p.alamat = reader["alamat"].ToString();
                                p.tgl = reader["tgl"].ToString();
                                p.perihal = reader["perihal"].ToString();
                                p.nomor_petunjuk = reader["nomor_petunjuk"].ToString();
                                p.ket = reader["ket"].ToString();
                                p.jenis_surat = reader["jenis_surat"].ToString();
                                Surat.Add(p);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
            return Surat;
        }

        public static List<Surat> GetDataSurat_Keluar()
        {
            List<Surat> Surat = new List<Surat>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM data_surat WHERE jenis_surat = 'Surat Keluar'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Surat p = new Surat();
                                p.nomor_berkas = reader["nomor_berkas"].ToString();
                                p.alamat = reader["alamat"].ToString();
                                p.tgl = reader["tgl"].ToString();
                                p.perihal = reader["perihal"].ToString();
                                p.nomor_petunjuk = reader["nomor_petunjuk"].ToString();
                                p.ket = reader["ket"].ToString();
                                p.jenis_surat = reader["jenis_surat"].ToString();
                                Surat.Add(p);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
            return Surat;
        }

        public static List<Surat> getDataSkripsiById(int id)
        {
            List<Surat> skripsi = new List<Surat>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM data_surat WHERE id=@id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Surat s = new Surat();
                                s.id = Int32.Parse(reader["id"].ToString());
                                s.nomor_berkas = reader["nomor_berkas"].ToString();
                                s.alamat = reader["alamat"].ToString();
                                s.tgl = reader["tgl"].ToString();
                                s.perihal = reader["perihal"].ToString();
                                s.nomor_petunjuk = reader["nomor_petunjuk"].ToString();
                                s.ket = reader["ket"].ToString();
                                s.jenis_surat = reader["jenis_surat"].ToString();
                                skripsi.Add(s);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
            return skripsi;
        }

        public static List<Surat> getSurat_Masuk(string cari)
        {
            List<Surat> spd = new List<Surat>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM data_surat WHERE alamat LIKE @alamat OR nomor_berkas LIKE @nomor_berkas AND jenis_surat = 'Surat Masuk'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@alamat", "%" + cari + "%");
                        cmd.Parameters.AddWithValue("@nomor_berkas", "%" + cari + "%");
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Surat p = new Surat();
                                p.id = Int32.Parse(reader["id"].ToString());
                                p.nomor_berkas = reader["nomor_berkas"].ToString();
                                p.alamat = reader["alamat"].ToString();
                                p.tgl = reader["tgl"].ToString();
                                p.perihal = reader["perihal"].ToString();
                                p.nomor_petunjuk = reader["nomor_petunjuk"].ToString();
                                p.ket = reader["ket"].ToString();
                                p.jenis_surat = reader["jenis_surat"].ToString();
                                spd.Add(p);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
            return spd;
        }

        public static List<Surat> getSurat_Keluar(string cari)
        {
            List<Surat> spd = new List<Surat>();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM data_surat WHERE alamat LIKE @alamat OR nomor_berkas LIKE @nomor_berkas AND jenis_surat = 'Surat Keluar'";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@alamat", "%" + cari + "%");
                        cmd.Parameters.AddWithValue("@nomor_berkas", "%" + cari + "%");
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Surat p = new Surat();
                                p.id = Int32.Parse(reader["id"].ToString());
                                p.nomor_berkas = reader["nomor_berkas"].ToString();
                                p.alamat = reader["alamat"].ToString();
                                p.tgl = reader["tgl"].ToString();
                                p.perihal = reader["perihal"].ToString();
                                p.nomor_petunjuk = reader["nomor_petunjuk"].ToString();
                                p.ket = reader["ket"].ToString();
                                p.jenis_surat = reader["jenis_surat"].ToString();
                                spd.Add(p);
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
            return spd;
        }


        public static int DeleteSurat(int id)
        {
            int r = -1;
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();
                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "DELETE FROM data_surat WHERE id = @id";
                    cmd.Prepare();
                    cmd.Parameters.AddWithValue("@id", id.ToString());
                    try
                    {
                        r = cmd.ExecuteNonQuery();
                    }
                    catch (SQLiteException e)
                    {
                        throw;
                    }
                }
                conn.Close();
            }
            return r;
        }

        public static Surat GetSuratById(int id)
        {
            Surat p = new Surat();
            try
            {
                using (SQLiteConnection conn = new SQLiteConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM data_surat WHERE id = @id";
                    using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
                    {
                        cmd.Prepare();
                        cmd.Parameters.AddWithValue("@id", id);
                        using (SQLiteDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                p.id = Int32.Parse(reader["id"].ToString());
                                p.nomor_berkas = reader["nomor_berkas"].ToString();
                                p.alamat = reader["alamat"].ToString();
                                p.tgl = reader["tgl"].ToString();
                                p.perihal = reader["perihal"].ToString();
                                p.nomor_petunjuk = reader["nomor_petunjuk"].ToString();
                                p.ket = reader["ket"].ToString();
                                p.jenis_surat = reader["jenis_surat"].ToString();
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (SQLiteException e)
            {
                throw;
            }
            return p;
        }

    }
}
