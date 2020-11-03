using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace AdmitereC {
    public partial class Form1 : Form {
        
        SqlConnection myConnection;
        SqlDataAdapter myAdapter = new SqlDataAdapter();
        DataTable myTable = new DataTable();
        SqlCommand q; 

        public Form1() {
            InitializeComponent();            
        }

        public void openConnexion() {
            String myConnectionString = ConfigurationManager.ConnectionStrings["myConnectionString"].ConnectionString;
            myConnection = new SqlConnection(myConnectionString);            
            myConnection.Open();
        }



        private void select(String qs) {
            myTable.Clear();
            myTable.Columns.Clear();
            admitereDataGridView.Columns.Clear();
            q = new SqlCommand(qs, myConnection);            
            myAdapter.SelectCommand = q;
            myAdapter.Fill(myTable);
            admitereDataGridView.DataSource = myTable;        
        }

        private void Form1_Load(object sender, EventArgs e) {                      
            openConnexion();
            select("select * from admitere");            
        }

        private void iesiToolStripMenuItem_Click(object sender, EventArgs e) {
            myConnection.Close();
            myConnection.Dispose();
            Close();
        }

        private void zeroToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        
        private void zeroToolStripMenuItem1_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 0;
        }

        private void admitereBindingNavigatorSaveItem_Click(object sender, EventArgs e) {            

        }

        private void button1_Click(object sender, EventArgs e) {
            
        }

        private void unuToolStripMenuItem_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 1;
        }

        private void Zero_Click(object sender, EventArgs e) {
            
                   
        }

        private void Fete_Click(object sender, EventArgs e) {
            select("select nume, prenume, rezultat, media from admitere where sex = 'F' order by media desc");                        
        }

        private void Baieti_Click(object sender, EventArgs e) {
            select("select nume, prenume, rezultat, media from admitere where sex = 'M' order by media desc");                        
        }

        private void Zero_Click_1(object sender, EventArgs e) {
            q = new SqlCommand("update admitere set rezultat = 'RESPINS', media = (proba1 + proba2 -0.01)/2.", myConnection);
            q.ExecuteNonQuery();

            q = new SqlCommand("update admitere set rezultat = 'ADMIS' where id in (select top 20 id from admitere where (proba1>=5) and (proba2>=5) order by media desc)", myConnection);
            q.ExecuteNonQuery();

            select("select nume, prenume, proba1, proba2, media, datan, rezultat, oras from admitere order by media desc");     
        }

        private void doiToolStripMenuItem_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 2;
        }

        private void treToolStripMenuItem_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 3;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 4;   
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 5;   
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 6;   
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 7;   
        }

        private void toolStripMenuItem6_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 8;   
        }

        private void toolStripMenuItem7_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 9;   
        }

        private void toolStripMenuItem8_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 10;   
        }

        private void toolStripMenuItem9_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 11;   
        }

        private void toolStripMenuItem10_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 12;   
        }

        private void toolStripMenuItem11_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 13;   
        }

        private void toolStripMenuItem12_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 14;        
        }

        private void toolStripMenuItem13_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 15;        
        }

        private void toolStripMenuItem14_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 16;        
        }

        private void toolStripMenuItem15_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 17;        
        }

        private void toolStripMenuItem16_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 18;        
        }

        private void toolStripMenuItem17_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 19;        
        }

        private void toolStripMenuItem18_Click(object sender, EventArgs e) {
            tabControl1.SelectedIndex = 20;
        }

        private void Primii_Click(object sender, EventArgs e) {
            select("SELECT TOP (5) Nume, Prenume, Media, Datan, Oras FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS') ORDER BY Media DESC ");                        
        }

        private void Ultimii_Click(object sender, EventArgs e) {
            select("SELECT TOP (5) Nume, Prenume, Media, Datan, Oras FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS') ORDER BY Media");                        
        }

        private void Varsta_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Oras, Datan, Media FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS') AND (DATEADD(month, 12 * 18, Datan) <= GETDATE()) AND (DATEADD(month, 12 * 20, Datan)>= GETDATE())ORDER BY Datan, Nume");                        
        }

        private void Proba1_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Proba1, Rezultat FROM  Admitere ORDER BY proba1 desc ");                        
        }

        private void Proba2_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Proba2, Rezultat FROM  Admitere ORDER BY proba2 desc ");                        
        }

        private void Rezultate_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Media, Rezultat FROM  Admitere ORDER BY nume, prenume");                        
        }

        

        private void Medii_Click(object sender, EventArgs e) {
            myTable.Clear();
            myTable.Columns.Clear();
            admitereDataGridView.Columns.Clear();
            select("select * from admitere order by media");     
            
            String qs;

            //qs = "SELECT count(*), sum(case when Media <=5 then 1 else null end), sum(case when Media > 5 and media <= 7 then 1 else null end), sum(case when Media > 7 and media <= 9 then 1 else null end), sum(case when Media > 9 then 1 esle null end)  FROM  Admitere";
            //q = new SqlCommand(qs, myConnection);
            //int []total = Convert.ToInt16(q.ExecuteReader());
            
            qs = "SELECT count(*) FROM  Admitere";
            q = new SqlCommand(qs, myConnection);
            int total = Convert.ToInt16(q.ExecuteScalar());
            
            qs = "SELECT count(*) FROM  Admitere Where Media <=5";                        
            q = new SqlCommand(qs, myConnection);
            int x = Convert.ToInt16(q.ExecuteScalar());
            l1_5.Text = "Intre 1.00 si 5.00: : " + (x * 100 / total) + " %";

            qs = "SELECT count(*) FROM  Admitere Where Media > 5 and media <= 7";
            q = new SqlCommand(qs, myConnection);
            x = Convert.ToInt16(q.ExecuteScalar());
            l5_7.Text = "Intre 5.01 si 7.00: : " + (x * 100 / total) + " %";
            

            qs = "SELECT count(*) FROM  Admitere Where Media > 7 and media <= 9";
            q = new SqlCommand(qs, myConnection);
            x = Convert.ToInt16(q.ExecuteScalar());
            l7_9.Text = "Intre 7.01 si 9.00: " + (x * 100 / total) + " %";                    

            qs = "SELECT count(*) FROM  Admitere Where Media > 9";
            q = new SqlCommand(qs, myConnection);
            x = Convert.ToInt16(q.ExecuteScalar());
            l9_10.Text = "Intre 9.01 si 10: " + (x * 100 / total) + " %";                                            
        }

        private void PeOrase_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Media, Rezultat, Oras FROM  Admitere ORDER BY Oras, Nume, Prenume");                        
        }

        private void AfisareOras_Click(object sender, EventArgs e) {
            myTable.Clear();
            myTable.Columns.Clear();
            admitereDataGridView.Columns.Clear();
            q = new SqlCommand("SELECT Nume, Prenume, Media, Rezultat, Oras FROM  Admitere where ltrim(rtrim(upper(oras))) = ltrim(rtrim(upper(@o))) ORDER BY Oras, Nume, Prenume", myConnection);
            q.Parameters.AddWithValue("@o",tbOras.Text);
            myAdapter.SelectCommand = q;
            myAdapter.Fill(myTable);
            admitereDataGridView.DataSource = myTable;                    
        }

        private void Orase_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Media, Oras FROM  Admitere WHERE (Media = (SELECT MAX(Media) FROM   Admitere as x WHERE (x.Oras = admitere.Oras))) ORDER BY Oras");                        
        }

        private void AdCluj_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Proba1, Proba2, Media, Datan, Rezultat FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Oras))) = 'ClUJ'and RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS') ORDER BY Media DESC, Nume, Prenume ");                        
        }

        private void ResCluj_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Proba1, Proba2, Media, Datan, Rezultat FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Oras))) = 'ClUJ'and RTRIM(LTRIM(UPPER(Rezultat))) = 'RESPINS') ORDER BY Media DESC, Nume, Prenume ");                        
        }

        private void button1_Click_1(object sender, EventArgs e) {
            String qs = "SELECT min(media) FROM  Admitere where ltrim(rtrim(upper(rezultat))) = 'ADMIS'";            
            q = new SqlCommand(qs, myConnection);
            int med_min = Convert.ToInt16(q.ExecuteScalar());
            
            // primul candidat
            int n1 = Convert.ToInt16(tbNota1.Text);
            qs = "update admitere set proba1 = @nota1,  media = (@nota1 + proba2 -0.01)/2., rezultat = case when (@nota1 >= 5 and media >= @med_min ) then 'ADMIS' else 'RESPINS' end where nume = @nume1 and prenume = @prenume1";
            q = new SqlCommand(qs, myConnection);
            q.Parameters.AddWithValue("@nota1", n1);
            q.Parameters.AddWithValue("@nume1", tbNume1.Text);
            q.Parameters.AddWithValue("@prenume1",tbPrenume1.Text);
            q.Parameters.AddWithValue("@med_min", med_min);
            q.ExecuteNonQuery();

            // al doilea candidat
            int n2 = Convert.ToInt16(tbNota2.Text);
            qs = "update admitere set proba2 = @nota2,  media = (@nota2 + proba1 - 0.01)/2., rezultat = case when (@nota2 >= 5 and proba1 >=5 and media >= @med_min ) then 'ADMIS' else 'RESPINS' end where nume = @nume2 and prenume = @prenume2";
            q = new SqlCommand(qs, myConnection);
            q.Parameters.AddWithValue("@nota2", n2);
            q.Parameters.AddWithValue("@nume2", tbNume2.Text);
            q.Parameters.AddWithValue("@prenume2",tbPrenume2.Text);
            q.Parameters.AddWithValue("@med_min", med_min);
            q.ExecuteNonQuery();
            
            select("select * from admitere order by media desc");                 

        }

        private void Camin_Click(object sender, EventArgs e) {
            select("SELECT TOP (4) Nume, Prenume,Oras, Media FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS' and RTRIM(LTRIM(UPPER(Oras))) !='BRASOV')  ORDER BY Media DESC, proba1 desc ");                        
        }

        private void CaminFete_Click(object sender, EventArgs e) {
            select("SELECT TOP (2) Nume, Prenume,Oras, Media FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS' and RTRIM(LTRIM(UPPER(Oras))) !='BRASOV' and upper(sex) = 'F')  ORDER BY Media DESC, proba1 desc ");                        
        }

        private void CaminBaieti_Click(object sender, EventArgs e) {
            select("SELECT TOP (2) Nume, Prenume,Oras, Media FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS' and RTRIM(LTRIM(UPPER(Oras))) !='BRASOV' and upper(sex) = 'M')  ORDER BY Media DESC, proba1 desc ");                        
        }

        private void Merit_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Media FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS' and media >=9.75 )  ORDER BY nume , prenume");                        
        }

        private void Studii_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume, Media FROM  Admitere WHERE (RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS' and media < 9.75  and media < 8.5)  ORDER BY nume , prenume");                        
        }

        private void Incorporabili_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume,  Datan, Oras FROM  Admitere WHERE (upper(sex) = 'M')and (RTRIM(LTRIM(UPPER(Rezultat))) = 'RESPINS') AND (DATEADD(month, 20 * 12, Datan) <= CAST('1998-05-20' AS datetime)) ORDER BY Datan, Nume");                        
        }

        private void NeIncorporabili_Click(object sender, EventArgs e) {
            select("SELECT Nume, Prenume,  Datan, Oras FROM  Admitere WHERE (upper(sex) = 'M')and ((RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS') or (DATEADD(month, 20 * 12, Datan) > CAST('1998-05-20' AS datetime))) ORDER BY Datan, Nume");
        }

        private void bOrasStat_Click(object sender, EventArgs e) {
            myTable.Clear();
            myTable.Columns.Clear();
            admitereDataGridView.Columns.Clear();
            select("select * from admitere order by media");

            String qs;

            qs = "SELECT count(*) FROM  Admitere where ltrim(rtrim(upper(oras))) = ltrim(rtrim(upper(@o)))";
            q = new SqlCommand(qs, myConnection);
            q.Parameters.AddWithValue("@o", tbOrasStat.Text);            
            int total = Convert.ToInt16(q.ExecuteScalar());
            lNrCandidati.Text = "Numarul de candidati: " + total;

            qs = "SELECT count(*) FROM  Admitere where ltrim(rtrim(upper(oras))) = ltrim(rtrim(upper(@o))) and ltrim(rtrim(upper(rezultat))) ='ADMIS' ";
            q = new SqlCommand(qs, myConnection);
            q.Parameters.AddWithValue("@o", tbOrasStat.Text); 
            int x = Convert.ToInt16(q.ExecuteScalar());
            lProcentAdmisi.Text = "Procentul de admisi: " + (x * 100 / total) + " %";
        }

        private void bCalculMedii_Click(object sender, EventArgs e) {
            myTable.Clear();
            myTable.Columns.Clear();
            admitereDataGridView.Columns.Clear();
            select("select * from admitere order by media");

            String qs;

            qs = "SELECT avg(proba1) FROM  Admitere where ltrim(rtrim(upper(rezultat))) = 'ADMIS'";
            q = new SqlCommand(qs, myConnection);
            q.Parameters.AddWithValue("@o", tbOrasStat.Text);
            double med = Convert.ToDouble(q.ExecuteScalar());
            lm1.Text += Math.Round(med,2) + "" ;

            qs = "SELECT avg(proba2) FROM  Admitere where ltrim(rtrim(upper(rezultat))) = 'ADMIS'";
            q = new SqlCommand(qs, myConnection);
            q.Parameters.AddWithValue("@o", tbOrasStat.Text);
            med = Convert.ToDouble(q.ExecuteScalar());
            ln2.Text += Math.Round(med,2) + "" ;

            qs = "SELECT avg(media) FROM  Admitere where ltrim(rtrim(upper(rezultat))) = 'ADMIS'";
            q = new SqlCommand(qs, myConnection);
            q.Parameters.AddWithValue("@o", tbOrasStat.Text);
            med = Convert.ToDouble(q.ExecuteScalar());
            lm.Text += Math.Round(med,2) + "" ;



        }

        private void Relativ_Click(object sender, EventArgs e) {
            String qs = "SELECT min(media) FROM  Admitere where ltrim(rtrim(upper(rezultat))) = 'ADMIS'";
            q = new SqlCommand(qs, myConnection);
            int med_min = Convert.ToInt16(q.ExecuteScalar());

            myTable.Clear();
            myTable.Columns.Clear();
            admitereDataGridView.Columns.Clear();
            q = new SqlCommand("SELECT Nume, Prenume, Media, Oras FROM  Admitere where ltrim(rtrim(upper(rezultat))) = 'RESPINS' and media > @med ORDER BY media desc", myConnection);
            q.Parameters.AddWithValue("@med", med_min);
            myAdapter.SelectCommand = q;
            myAdapter.Fill(myTable);
            admitereDataGridView.DataSource = myTable;                 
        }

        private void tabPage1_Click(object sender, EventArgs e) {

        }

        private void button1_Click_2(object sender, EventArgs e) {
            myTable.Clear();
            myTable.Columns.Clear();
            admitereDataGridView.Columns.Clear();
            select("select * from admitere order by media");

            String qs;

            qs = "SELECT avg(media) FROM  Admitere where ltrim(rtrim(upper(rezultat))) = 'ADMIS'";
            q = new SqlCommand(qs, myConnection);            
            double med = Convert.ToDouble(q.ExecuteScalar());
            lMedAdm.Text += Math.Round(med, 2) + "";

            qs = "SELECT avg(media) FROM  Admitere where ltrim(rtrim(upper(rezultat))) = 'RESPINS'";
            q = new SqlCommand(qs, myConnection);            
            med = Convert.ToDouble(q.ExecuteScalar());
            lMedResp.Text += Math.Round(med, 2) + "";            
        }

        private void bg1_Click(object sender, EventArgs e) {
            select("SELECT nume, prenume, proba1, proba2, media, oras, datan, rezultat FROM  (SELECT rank() OVER (ORDER BY media DESC, id) AS nr, * FROM  Admitere) AS x WHERE RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS' AND (nr % 2 != 0) ORDER BY Media DESC ");                        
        }

        private void bg2_Click(object sender, EventArgs e) {
            select("SELECT nume, prenume, proba1, proba2, media, oras, datan, rezultat FROM  (SELECT rank() OVER (ORDER BY media DESC, id) AS nr, * FROM  Admitere) AS x WHERE RTRIM(LTRIM(UPPER(Rezultat))) = 'ADMIS' AND (nr % 2 = 0) ORDER BY Media DESC ");                        
        }

        private void Vechi_Click(object sender, EventArgs e) {
            select("SELECT nume, prenume, proba1, proba2, media, oras, datan, rezultat FROM  admitere ORDER BY Media DESC ");                        
        }

        private void Nou_Click(object sender, EventArgs e) {
            q = new SqlCommand("update admitere set rezultat = 'ADMIS' where id in (select top 3 id from admitere where (proba1>=5) and (proba2>=5 and (ltrim(rtrim(upper(rezultat))) = 'RESPINS')) order by media desc)", myConnection);
            q.ExecuteNonQuery();
            
            select("SELECT nume, prenume, proba1, proba2, media, oras, datan, rezultat FROM  admitere ORDER BY Media DESC ");                        
        }  

    }

}
