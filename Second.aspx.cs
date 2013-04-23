    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Data.SqlClient;
    using System.Data;
    using System.Configuration;

    public partial class Second : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["StrCon"].ConnectionString);
  
        protected void Page_Load(object sender, EventArgs e)
        {
            
            string TxtName = Convert.ToString(Session["Sessionname"]);
            string TxtDob=Convert.ToString(Session["SessionDOB"]);
            string TxtGender = Convert.ToString(Session["SessionGender"]);
            string Txtreligion=Convert.ToString(Session["SessionReligion"]);
            string TxtMotherTon=Convert.ToString(Session["SessionMotherTon"]);
            string TxtCaste=Convert.ToString(Session["SessionCaste"]);
            string TxtCountry=Convert.ToString(Session["SessionCountry"]);
            string TxtMobile=Convert.ToString(Session["SessionMobile"]);
            string TxtEmail=Convert.ToString(Session["SessionEmail"]);
            string TxtPwd = Convert.ToString(Session["SessionPSW"]);
            Lbl_CountryName.Text = TxtCountry;
            Lbl_CasteName.Text=TxtCaste;
            Education();
            Occupation();
            Currancy();
            SubCaste();
            RegionalSitesn();

            if (!IsPostBack)
            {
                Star();
                State();
            }

       
        



        }


        //RegionalSitesn

        protected void RegionalSitesn()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "Select * from RegionalSitesn";
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();
            da.Fill(ds);
            DDL_RegSites.DataSource = ds;
            DDL_RegSites.DataTextField = "RegionalSitesName";
            DDL_RegSites.DataValueField = "RegionalSitesId";
           DDL_RegSites.DataBind();
           DDL_RegSites.Items.Insert(0, new ListItem("--Select--", "0"));
           con.Close();




        }


        //Education

        protected void Education()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "Select * from Education";
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();      
            da.Fill(ds);
            DDL_HighestEdu.DataSource = ds;
            DDL_HighestEdu.DataTextField  = "EducationName";
            DDL_HighestEdu.DataValueField = "EducationId";
            DDL_HighestEdu.DataBind();
            DDL_HighestEdu.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();



        }

        //Occupation

        protected void Occupation()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "Select * from Occupation";
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();        
            da.Fill(ds);
            DDL_Occupation.DataSource = ds;
            DDL_Occupation.DataTextField = "OccName";
            DDL_Occupation.DataValueField = "OccId";
            DDL_Occupation.DataBind();
            DDL_Occupation.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();


        }

        //Currancy

        protected void Currancy()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "Select * from currency";
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();        
            da.Fill(ds);
            DDL_IncomeType.DataSource = ds;
            DDL_IncomeType.DataTextField = "currName";
            DDL_IncomeType.DataValueField = "CurrId";
            DDL_IncomeType.DataBind();
            DDL_IncomeType.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();

        }

        //State

        protected void State()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "Select * from State";
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();               
            da.Fill(ds);
            DDL_State.DataSource = ds;
            DDL_State.DataTextField = "StateName";
            DDL_State.DataValueField = "StateId";
            DDL_State.DataBind();
            DDL_State.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();


        }

        protected void DDL_State_SelectedIndexChanged1(object sender, EventArgs e)
        {


        
            City();


        }

        //City

        protected void City()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "select CityName,CityId from City where StateId =" + DDL_State.SelectedValue;
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();        
            da.Fill(ds);
            DDL_City.DataSource = ds;
            DDL_City.DataTextField = "CityName";
            DDL_City.DataValueField = "CityId";
            DDL_City.DataBind();
            DDL_City.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();




        }

    

        //SubCaste

        protected void SubCaste()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "Select * from SubCaste";
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();        
            da.Fill(ds);
            DDL_SubCaste.DataSource = ds;
            DDL_SubCaste.DataTextField = "SubCasteName";
            DDL_SubCaste.DataValueField = "SubCasteId";
            DDL_SubCaste.DataBind();
            DDL_SubCaste.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();



        }

        //Star

        protected void Star()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "Select * from Star";
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();                
            da.Fill(ds);
            DDL_Star.DataSource = ds;
            DDL_Star.DataTextField = "StarName";
            DDL_Star.DataValueField = "StarId";
            DDL_Star.DataBind();
            DDL_Star.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();



        }

        protected void DDL_Star_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rassi();

        }

        //Rassi

        protected void Rassi()
        {
            con.Open();
            DataSet ds = null;
            String str_query = "Select RaasiName,Raasiid from Raasi where StarId=" + DDL_Star.SelectedValue;
            SqlCommand cmd = new SqlCommand(str_query, con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            ds = new DataSet();       
            da.Fill(ds);
            DDL_Moon.DataSource = ds;
            DDL_Moon.DataTextField = "RaasiName";
            DDL_Moon.DataValueField = "Raasiid";
            DDL_Moon.DataBind();
            DDL_Moon.Items.Insert(0, new ListItem("--Select--", "0"));
            con.Close();



        }
       
    
        protected void btn_Submit_Click(object sender, EventArgs e)
        {
              

                //string ggg = "Data Source=SEENU-PC\\SQLEXPRESS;Initial Catalog=Matrimoney;Integrated Security=True";

                //SqlConnection db = new SqlConnection(ggg);
                SqlTransaction Transaction;
                con.Open();
                Transaction = con.BeginTransaction();
                try
                {
                    new SqlCommand("INSERT INTO Transact VALUES ('" + Convert.ToString(Session["Sessionname"]) + "','" + Convert.ToString(Session["SessionDOB"]) + "','" + Convert.ToString(Session["SessionGender"]) + "','" + Convert.ToString(Session["SessionMobile"]) + "','" + Convert.ToString(Session["SessionCountry"]) + "','" + DDL_State.SelectedItem + "','" + DDL_City.SelectedItem + "','" + Convert.ToString(Session["SessionReligion"]) + "','" + Convert.ToString(Session["SessionCaste"]) + "','" + DDL_SubCaste.SelectedItem + "','" + Txt_Gothram.Text + "','" + Convert.ToString(Session["SessionEmail"]) + "','" + Rbtn_PhysicalStatus.SelectedValue + "','" + Txt_Desc.Text + "');", con , Transaction).ExecuteNonQuery();

                    new SqlCommand("INSERT INTO EduDetails values ('" + Txt_Height.Text + "','" + DDL_Occupation.SelectedItem + "','" + Rbtn_EmpIn.SelectedValue + "','" + Rbtn_IncomeType.SelectedValue + "','" + DDL_IncomeType.SelectedItem + "','" + Txt_Amount.Text + "');", con, Transaction).ExecuteNonQuery();

                    new SqlCommand("INSERT INTO Habit values('" + Rbtn_Food.SelectedValue + "','" + Rbtn_Smoking.SelectedValue + "','" + Rbtn_Drinking.SelectedValue + "');", con, Transaction).ExecuteNonQuery();

                    new SqlCommand("INSERT INTO AstrologicalInfo values('" + Rbtn_Dhosam.SelectedValue + "','" + DDL_Star.SelectedItem + "','" + DDL_Moon.SelectedItem + "');", con, Transaction).ExecuteNonQuery();

                    new SqlCommand("insert into Family values('" + Rbtn_familystatus.SelectedValue + "','" + Rbtn_FamType.SelectedValue + "','" + Rbtn_FamValue.SelectedValue + "');", con, Transaction).ExecuteNonQuery();

                    Transaction.Commit();

                }


                catch

                {
                    Transaction.Rollback();
                }
               con.Close();
            }


    
        }
