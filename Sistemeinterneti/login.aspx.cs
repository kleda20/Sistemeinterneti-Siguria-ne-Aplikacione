using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using System.Data;




namespace Sistemeinterneti
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs c)
        {

        }

        private static string konverto(string fjalekalim)
        {
            byte[] bytes = System.Text.Encoding.Unicode.GetBytes(fjalekalim);
            byte[] inArray = System.Security.Cryptography.HashAlgorithm.Create("SHA1").ComputeHash(bytes);
            return Convert.ToBase64String(inArray);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string var_email = email.Text;
            string var_id = id.Text;
            string var_fjalekalim = fjalekalim.Text;
            //string hashfjale = konverto(var_fjalekalim);

            //enkripto fjalekalimin
            string var_fjalekalim_konv = konverto(var_fjalekalim);
           string var_id_konv = konverto(var_id);
            string var_email_konv = konverto(var_email);

            //lidhjen me db
            SqlConnection lidhja = new SqlConnection("Data Source =KLEDA\\MIRROR; Initial Catalog = LoginSignup ; Integrated Security = True");

            //hapim try catch
            try
            {
                //hapet lidhja
                lidhja.Open();

                //inicializohet komanda
                SqlCommand kom = new SqlCommand("regjistrohu", lidhja);

                //lidhja e komandes me lidhjen e databazes
                kom.Connection = lidhja;

                //tipi i komandes
                kom.CommandType = CommandType.StoredProcedure;

                //paramterta e procedures

                kom.Parameters.AddWithValue("@vemail", SqlDbType.NVarChar).Value = var_email_konv;
                kom.Parameters.AddWithValue("@vfjalekalim", SqlDbType.NVarChar).Value = var_fjalekalim_konv;
                kom.Parameters.AddWithValue("@vid", SqlDbType.NVarChar).Value = var_id_konv;

                //ekzekutojme komanden
                kom.ExecuteScalar();

                lidhja.Close();

                

            }
            catch (SqlException err)
            {
                Label1.Text = "Gabim " + err.Message;
            }
            finally
            {
                lidhja.Close();
            }
        }


    }
} 

