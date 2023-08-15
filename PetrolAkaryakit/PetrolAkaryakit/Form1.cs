using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel.Design;

namespace PetrolAkaryakit
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        SqlConnection bag = new SqlConnection("Data Source=DESKTOP-KACV7HQ\\SQLEXPRESS;Initial Catalog=PetrolAkaryakit;Integrated Security=True"); 
        void listele()
        {
            bag.Open();
            SqlCommand komut = new SqlCommand("select * from TBLBENZIN where petroltur='Kurşunsuz95'", bag);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LblKursunsuz95.Text = dr[3].ToString();
                progressBar1.Value = int.Parse(dr[4].ToString());
                Lbl95Litre.Text = dr[4].ToString();
                Lbl95Alis.Text = dr[2].ToString();
            }
            bag.Close();

            bag.Open();
            SqlCommand komut1 = new SqlCommand("select * from TBLBENZIN where petroltur='Kurşunsuz97'", bag);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                LblKursunsuz97.Text = dr1[3].ToString();
                progressBar2.Value = int.Parse(dr1[4].ToString());
                Lbl97Litre.Text = dr1[4].ToString();
                Lbl97Alis.Text = dr1[2].ToString();
            }
            bag.Close();

            bag.Open();
            SqlCommand komut2 = new SqlCommand("select * from TBLBENZIN where petroltur='EuroDizel10'", bag);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblEuroDizel.Text = dr2[3].ToString();
                progressBar3.Value = int.Parse(dr2[4].ToString());
                LblEuroLitre.Text = dr2[4].ToString();
                LblEuroAlis.Text = dr2[2].ToString();
            }
            bag.Close();

            bag.Open();
            SqlCommand komut3 = new SqlCommand("select * from TBLBENZIN where petroltur='YeniProDizel'", bag);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LblYeniPro.Text = dr3[3].ToString();
                progressBar4.Value = int.Parse(dr3[4].ToString());
                LblYeniProLitre.Text = dr3[4].ToString();
                LblYeniProAlis.Text = dr3[2].ToString();
            }
            bag.Close();

            bag.Open();
            SqlCommand komut4 = new SqlCommand("select * from TBLBENZIN where petroltur='Gaz'", bag);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                LblGaz.Text = dr4[3].ToString();
                progressBar5.Value = int.Parse(dr4[4].ToString());
                LblGazLitre.Text = dr4[4].ToString();
                LblGazAlis.Text = dr4[2].ToString();
            }
            bag.Close();

            bag.Open();
            SqlCommand komut5 = new SqlCommand("select * from tblkasa",bag);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while(dr5.Read())
            {
                LblKasa.Text = dr5[0].ToString();
            }
            bag.Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            listele();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(LblKursunsuz95.Text);
            litre = Convert.ToDouble(numericUpDown1.Value);
            tutar = kursunsuz95*litre;
            Txt95Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(LblKursunsuz97.Text);
            litre = Convert.ToDouble(numericUpDown2.Value);
            tutar = kursunsuz97 * litre;
            Txt97Fiyat.Text = tutar.ToString();
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(LblEuroDizel.Text);
            litre = Convert.ToDouble(numericUpDown3.Value);
            tutar = eurodizel * litre;
            TxtEuroFiyat.Text = tutar.ToString();
        }

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            double yenipro, litre, tutar;
            yenipro = Convert.ToDouble(LblYeniPro.Text);
            litre = Convert.ToDouble(numericUpDown4.Value);
            tutar = yenipro * litre;
            TxtYeniProFiyat.Text = tutar.ToString();
        }

        private void numericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGaz.Text);
            litre = Convert.ToDouble(numericUpDown5.Value);
            tutar = gaz * litre;
            TxtGazFiyat.Text = tutar.ToString();
        }

        private void BtnDepoDoldur_Click(object sender, EventArgs e)
        {
            if(numericUpDown1.Value != 0) 
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)",bag);
                komut.Parameters.AddWithValue("@p1",TxtPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz 95");
                komut.Parameters.AddWithValue("@p3", numericUpDown1.Value);
                komut.Parameters.AddWithValue("@p4",decimal.Parse(Txt95Fiyat.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Satış Yapıldı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1",bag);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(Txt95Fiyat.Text));
                komut2.ExecuteNonQuery();
                bag.Close();

                bag.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='Kurşunsuz95'",bag);
                komut3.Parameters.AddWithValue("@p1", numericUpDown1.Value);
                komut3.ExecuteNonQuery();
                bag.Close();
                listele();
            }
            if(numericUpDown2.Value != 0)
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", bag);
                komut.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "Kurşunsuz 97");
                komut.Parameters.AddWithValue("@p3", numericUpDown2.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(Txt97Fiyat.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Satış Yapıldı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", bag);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(Txt97Fiyat.Text));
                komut2.ExecuteNonQuery();
                bag.Close();

                bag.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='Kurşunsuz97'", bag);
                komut3.Parameters.AddWithValue("@p1", numericUpDown2.Value);
                komut3.ExecuteNonQuery();
                bag.Close();
                listele();
            }
            if(numericUpDown3.Value != 0) 
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", bag);
                komut.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "EuroDizel10");
                komut.Parameters.AddWithValue("@p3", numericUpDown3.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtEuroFiyat.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Satış Yapıldı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", bag);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(TxtEuroFiyat.Text));
                komut2.ExecuteNonQuery();
                bag.Close();

                bag.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='EuroDizel10'", bag);
                komut3.Parameters.AddWithValue("@p1", numericUpDown3.Value);
                komut3.ExecuteNonQuery();
                bag.Close();
                listele();
            }
            if(numericUpDown4.Value != 0) 
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", bag);
                komut.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "YeniProDizel");
                komut.Parameters.AddWithValue("@p3", numericUpDown4.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtYeniProFiyat.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Satış Yapıldı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", bag);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(TxtYeniProFiyat.Text));
                komut2.ExecuteNonQuery();
                bag.Close();

                bag.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='YeniProDizel'", bag);
                komut3.Parameters.AddWithValue("@p1", numericUpDown4.Value);
                komut3.ExecuteNonQuery();
                bag.Close();
                listele();
            }
            if(numericUpDown5.Value != 0) 
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("insert into tblhareket (plaka,benzınturu,lıtre,fıyat) values (@p1,@p2,@p3,@p4)", bag);
                komut.Parameters.AddWithValue("@p1", TxtPlaka.Text);
                komut.Parameters.AddWithValue("@p2", "Gaz");
                komut.Parameters.AddWithValue("@p3", numericUpDown5.Value);
                komut.Parameters.AddWithValue("@p4", decimal.Parse(TxtGazFiyat.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Satış Yapıldı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblkasa set mıktar=mıktar+@p1", bag);
                komut2.Parameters.AddWithValue("@p1", decimal.Parse(TxtGazFiyat.Text));
                komut2.ExecuteNonQuery();
                bag.Close();

                bag.Open();
                SqlCommand komut3 = new SqlCommand("update tblbenzın set stok=stok-@p1 where petroltur='Gaz'", bag);
                komut3.Parameters.AddWithValue("@p1", numericUpDown5.Value);
                komut3.ExecuteNonQuery();
                bag.Close();
                listele();
            }
        }

        private void BtnYakitAl_Click(object sender, EventArgs e)
        {
            if(numericUpDown10.Value != 0)
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("update tblkasa set mıktar=mıktar-@p1",bag);
                komut.Parameters.AddWithValue("@p1",decimal.Parse(Txt95Alis.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Yakıt Alındı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblbenzın set stok=stok+@a1 where petroltur='Kurşunsuz95'",bag);
                komut2.Parameters.AddWithValue("@a1", numericUpDown10.Value);
                komut2.ExecuteNonQuery();
                bag.Close();
                listele();
            }
            if(numericUpDown9.Value != 0) 
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", bag);
                komut.Parameters.AddWithValue("@p1", decimal.Parse(Txt97Alis.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Yakıt Alındı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblbenzın set stok=stok+@a1 where petroltur='Kurşunsuz97'", bag);
                komut2.Parameters.AddWithValue("@a1", numericUpDown9.Value);
                komut2.ExecuteNonQuery();
                bag.Close();
                listele();
            }
            if(numericUpDown8.Value != 0) 
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", bag);
                komut.Parameters.AddWithValue("@p1", decimal.Parse(TxtEurDizelAlis.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Yakıt Alındı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblbenzın set stok=stok+@a1 where petroltur='EuroDizel10'", bag);
                komut2.Parameters.AddWithValue("@a1", numericUpDown8.Value);
                komut2.ExecuteNonQuery();
                bag.Close();
                listele();
            }
            if(numericUpDown7.Value != 0) 
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", bag);
                komut.Parameters.AddWithValue("@p1", decimal.Parse(TxtYeniProAlis.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Yakıt Alındı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblbenzın set stok=stok+@a1 where petroltur='YeniProDizel'", bag);
                komut2.Parameters.AddWithValue("@a1", numericUpDown7.Value);
                komut2.ExecuteNonQuery();
                bag.Close();
                listele();
            }
            if(numericUpDown6.Value != 0) 
            {
                bag.Open();
                SqlCommand komut = new SqlCommand("update tblkasa set mıktar=mıktar-@p1", bag);
                komut.Parameters.AddWithValue("@p1", decimal.Parse(TxtGazAlis.Text));
                komut.ExecuteNonQuery();
                bag.Close();
                MessageBox.Show("Yakıt Alındı");

                bag.Open();
                SqlCommand komut2 = new SqlCommand("update tblbenzın set stok=stok+@a1 where petroltur='Gaz'", bag);
                komut2.Parameters.AddWithValue("@a1", numericUpDown6.Value);
                komut2.ExecuteNonQuery();
                bag.Close();
                listele();
            }
        }

        private void numericUpDown10_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz95, litre, tutar;
            kursunsuz95 = Convert.ToDouble(Lbl95Alis.Text);
            litre = Convert.ToDouble(numericUpDown10.Value);
            tutar = kursunsuz95 * litre;
            Txt95Alis.Text = tutar.ToString();
        }

        private void numericUpDown9_ValueChanged(object sender, EventArgs e)
        {
            double kursunsuz97, litre, tutar;
            kursunsuz97 = Convert.ToDouble(Lbl97Alis.Text);
            litre = Convert.ToDouble(numericUpDown9.Value);
            tutar = kursunsuz97 * litre;
            Txt97Alis.Text = tutar.ToString();
        }

        private void numericUpDown8_ValueChanged(object sender, EventArgs e)
        {
            double eurodizel, litre, tutar;
            eurodizel = Convert.ToDouble(LblEuroAlis.Text);
            litre = Convert.ToDouble(numericUpDown8.Value);
            tutar = eurodizel * litre;
            TxtEurDizelAlis.Text = tutar.ToString();
        }

        private void numericUpDown7_ValueChanged(object sender, EventArgs e)
        {
            double yenipro, litre, tutar;
            yenipro = Convert.ToDouble(LblYeniProAlis.Text);
            litre = Convert.ToDouble(numericUpDown7.Value);
            tutar = yenipro * litre;
            TxtYeniProAlis.Text = tutar.ToString();
        }

        private void numericUpDown6_ValueChanged(object sender, EventArgs e)
        {
            double gaz, litre, tutar;
            gaz = Convert.ToDouble(LblGazAlis.Text);
            litre = Convert.ToDouble(numericUpDown6.Value);
            tutar = gaz * litre;
            TxtGazAlis.Text = tutar.ToString();
        }
    }
}
        
        
    

