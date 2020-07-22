using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Security.Cryptography;
using System.Web.Configuration;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Net;
using System.IO;



namespace Sistemeinterneti
{
    public partial class Identifikohu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
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
           

            //enkriptojme inputet nga textboxi
            string fjalekalimkod = konverto(fjalekalim.Text);
            string idkod = konverto(id.Text);


            string var_fjalekalim = fjalekalim.Text;
            string hashfjale = konverto(var_fjalekalim);

            //marrim inputet e perdoruesit nga textbox dhe i enkodojme
            string enkendpass = Server.HtmlEncode(fjalekalimkod);
            string enkendid = Server.HtmlEncode(idkod);


            

            //perdorim nje variabel per te kontrolluar nese ekziston apo jo ky perdorues me keto inputs ne databaze.
            int exist = 0;





            //lidhjen me db
            SqlConnection lidhja = new SqlConnection("Data Source =KLEDA\\MIRROR; Initial Catalog = LoginSignup ; Integrated Security = True");

            //hapim try catch
            try
            {
                //hapet lidhja
                lidhja.Open();

                //inicializohet komanda
                SqlCommand kom = new SqlCommand("kerko", lidhja);

                //lidhja e komandes me lidhjen e databazes
                kom.Connection = lidhja;

                //tipi i komandes
                kom.CommandType = CommandType.StoredProcedure;

                //paramterta e procedures

               
                kom.Parameters.AddWithValue("@vfjalekalim", SqlDbType.NVarChar).Value = enkendpass;
                kom.Parameters.AddWithValue("vid", SqlDbType.NVarChar).Value = enkendid; //nderkohe qe kte e ke string
                
                //ekzekutojme kete komande/procedure dhe nese kthen 1 nese perdoruesi ekziston dhe nje rrjesht eshte afektuar, dhe 0 ne te kundert.
                exist = Convert.ToInt32(kom.ExecuteScalar());


                //nese exekutimi i komandes/procedures kthen 0, exist merr vleren 0, dhe perdoruesi nuk ekziston, afishojme nje Alert box me nje mesazh
                if (exist == 0)
                {


                    Literal literal = new Literal();
                    literal.Text = @"<script>alert(""ID ose Fjakekalim i gabuar!"");</script>";
                    literal.Mode = LiteralMode.PassThrough;
                    form1.Controls.Add(literal);


                }
                //nese exekutimi i komandes/procedures eshte i ndryshem nga 0, exist merr vleren 0,perdoruesi me keto kredinciale ekziston, dhe perdoruesi ridrejtohet ne nje faqe tjt
                else
                {
                    //hapim dhe nje session per te marre id e perdoruesit
                    Session["perdoruesi"] = idkod.ToString();
                    Session.Timeout = 1;


                    //Ridrejtimi ne faqen Kryefaqja
                    Response.Redirect("Kryefaqja.aspx");



                    //ekzekutojme komanden
                    kom.ExecuteScalar();

                    lidhja.Close();



                }
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

        public bool IsReCaptchValid()
        {
            var result = false;
            var captchaResponse = Request.Form["g-recaptcha-response"];
            var secretKey = "6LciwAEVAAAAAOhwj3ysL23dLTnoe4NbYK-1Hs3J";
            var apiUrl = "https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}";
            var requestUri = string.Format(apiUrl, secretKey, captchaResponse);
            var request = (HttpWebRequest)WebRequest.Create(requestUri);

            using (WebResponse response = request.GetResponse())
            {
                using (StreamReader stream = new StreamReader(response.GetResponseStream()))
                {
                    JObject jResponse = JObject.Parse(stream.ReadToEnd());
                    var isSuccess = jResponse.Value<bool>("success");
                    result = (isSuccess) ? true : false;
                }
            }
            return result;
        }

    }
}

