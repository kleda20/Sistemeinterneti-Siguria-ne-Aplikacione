using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Sistemeinterneti
{
    public partial class Kryefaqja : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            string idkod = Server.HtmlEncode(Session["perdoruesi"].ToString());

            if (Session["perdoruesi"] == null)
            {
                Response.Redirect("Identifikohu.aspx");
            }
            else
            { Label1.Text = Session["perdoruesi"].ToString(); 
            }


        }
    }
}