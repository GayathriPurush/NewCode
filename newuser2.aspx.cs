using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class newuser2 : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString);
      
    protected void Page_Load(object sender, EventArgs e)
    {

         profileFor();
         
         MotherTounge();
        
         
         //CountryCode();
         //Religion();


         if (!IsPostBack)
         {
             Religion();
             Country();
         }
        

         
    }

    // populate profileFor
     protected void profileFor()
    {
         
         con.Open();
         DataSet ds = null;
         String str_query = "select * from ProfileFor";
         SqlCommand cmd = new SqlCommand(str_query, con);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         ds = new DataSet();
         da.Fill(ds);
         DDl_ProfileFor.DataSource = ds;
         DDl_ProfileFor.DataTextField = "ProfileName";
         DDl_ProfileFor.DataValueField = "ProfileId";
         DDl_ProfileFor.DataBind();
         DDl_ProfileFor.Items.Insert(0, new ListItem("--Select--", "0"));
         con.Close();
                 
     }

    //Populate Religion

     protected void Religion()
     {
         con.Open();
         DataSet ds = null;
         String str_query = "select * from Religion";
         SqlCommand cmd = new SqlCommand(str_query, con);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         ds = new DataSet();
         da.Fill(ds);
         DDL_Religion.DataSource = ds;
         DDL_Religion.DataTextField = "ReligionName";
         DDL_Religion.DataValueField = "ReligionId";
         DDL_Religion.DataBind();
         DDL_Religion.Items.Insert(0, new ListItem("--Select--", "0"));
         con.Close();


     }


    


    //Mother Tounge

     protected void MotherTounge()
     {
         con.Open();
         DataSet ds = null;
         String str_query = "select * from MotherTongue";
         SqlCommand cmd = new SqlCommand(str_query, con);
         SqlDataAdapter da = new SqlDataAdapter(cmd);
         ds = new DataSet();
              
         da.Fill(ds);
         DDL_MotherTongue.DataSource = ds;
         DDL_MotherTongue.DataTextField = "TongueName";
         DDL_MotherTongue.DataValueField = "TongueId";
         DDL_MotherTongue.DataBind();
         DDL_MotherTongue.Items.Insert(0, new ListItem("--Select--", "0"));
         con.Close();


     }
    //Caste

    protected void Caste()
    {
        con.Open();
        DataSet ds = null;
        String str_query = "select  CasteName,CasteId from Caste where CasteReligionId=" + DDL_Religion.SelectedValue;
        SqlCommand cmd = new SqlCommand(str_query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ds = new DataSet();       
        da.Fill(ds);
        DDL_Caste.DataSource = ds;
        DDL_Caste.DataTextField = "CasteName";
        DDL_Caste.DataValueField = "CasteId";
        DDL_Caste.DataBind();
        DDL_Caste.Items.Insert(0, new ListItem("--Select--", "0"));
        con.Close();



    }

    //Country

    protected void Country()
    {
        con.Open();
        DataSet ds = null;
        String str_query = "select * from Country";
        SqlCommand cmd = new SqlCommand(str_query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ds = new DataSet();        
        da.Fill(ds);
        DDL_Country.DataSource = ds;
        DDL_Country.DataTextField = "CountryName";
        DDL_Country.DataValueField = "CountryId";
        DDL_Country.DataBind();
        DDL_Country.Items.Insert(0, new ListItem("--Select--", "0"));
        con.Close();
        
    }

    //CountryCode


    protected void CountryCode()
    {
        con.Open();
        DataSet ds = null;
        String str_query = "select * from CountryCode where countryId=" + DDL_Country.SelectedValue;
        SqlCommand cmd = new SqlCommand(str_query, con);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        ds = new DataSet();        
        da.Fill(ds);
        DDL_MobileCode.DataSource = ds;
        DDL_MobileCode.DataTextField = "CountryCode";
        DDL_MobileCode.DataValueField = "CountryName";
        DDL_MobileCode.DataBind();
        con.Close();

    }


    protected void DDL_Religion_SelectedIndexChanged(object sender, EventArgs e)
    {
        Caste();

    }
    protected void Btn_Submit_Click(object sender, EventArgs e)
    {
        

        Session["Sessionname"] = Txt_Name.Text.ToString();
        Session["SessionGender"] = Rbtn_Gender.SelectedValue;
        Session["SessionDOB"] = Txt_DOB.Text.ToString();
        Session["SessionReligion"] = DDL_Religion.SelectedItem;
        Session["SessionMotherTon"] = DDL_MotherTongue.SelectedItem;
        Session["SessionCaste"] = DDL_Caste.SelectedItem;
        Session["SessionCountry"] = DDL_Country.SelectedItem;
        Session["SessionMobile"] = Txt_Phoneno.Text;
        Session["SessionEmail"] = Txt_Mail.Text;
        Session["SessionPSW"] = Txt_Pwd.Text;
        Response.Redirect("Second.aspx");
        


    }




    protected void DDL_Country_SelectedIndexChanged(object sender, EventArgs e)
    {
        CountryCode();
    }
}