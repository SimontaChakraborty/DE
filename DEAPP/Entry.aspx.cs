using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DEAPP
{
    public partial class About : Page
    {
        string ConnectionStr = @"Data Source = SIMONTO-LAPTOP\SIMONTA; Initial Catalog = DataEdgeAPP; User ID = sa; Password = 123";
        
        public static DropDownList FillClass(DropDownList ddl)
        {
            DataTable dt = new DataTable();
            String query = @"select ID, Class from Class";
            dt = loaddt(query);
            ddl.DataSource = dt;
            ddl.DataTextField = "Class";
            ddl.DataValueField = "ID";
            ddl.DataBind();

            ListItem li = new ListItem("Select.....", "0");
            ddl.Items.Insert(0, li);
            return ddl;
        }
        public static DropDownList FillSubject(DropDownList ddl)
        {

            DataTable dt = new DataTable();
            String query = @"select ID, Subjects from Subjects";
            dt = loaddt(query);
            ddl.DataSource = dt;
            ddl.DataTextField = "Subjects";
            ddl.DataValueField = "ID";
            ddl.DataBind();

            ListItem li = new ListItem("Select.....", "0");
            ddl.Items.Insert(0, li);
            return ddl;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillClass(ddlClass);
                FillSubject(ddlSub);
                LoadGridData();
            }

        }
        private static DataTable loaddt(string query)
        {
            string ConnectionStr = @"Data Source = SIMONTO-LAPTOP\SIMONTA; Initial Catalog = DataEdgeAPP; User ID = sa; Password = 123";

            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);


            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cnn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }
            return dt;
        }

        private int saveinfo()
        {
            int save = 0;
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);

            string query = @"INSERT INTO Student
           ([Class],[Subjects],[Name],[Marks])
                VALUES
           (@Class,@Subjects,@Name,@Marks)";

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cmd.Parameters.AddWithValue("@Class", ddlClass.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Subjects", ddlSub.SelectedItem.Text);
                cmd.Parameters.AddWithValue("@Name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@Marks", txtMark.Text.Trim());
                cnn.Open();
                save = cmd.ExecuteNonQuery();
            }

            return save;
        }

        protected void txtbtn_Click(object sender, EventArgs e)
        {
            int save = saveinfo();
            if (save > 0)
            {
                ClearFieldValue();
                LoadGridData();
            }
        }

        private void ClearFieldValue()
        {
            ddlClass.SelectedValue = "0";
            ddlSub.SelectedValue = "0";
            txtName.Text = "";
            txtMark.Text = "";

        }
        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);


            string query = @"SELECT Class,Subjects,Name,Marks from Student";


            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();

            using (SqlCommand cmd = new SqlCommand(query, cnn))
            {
                cnn.Open();
                sda.SelectCommand = cmd;
                sda.Fill(ds);
                dt = ds.Tables[0];
            }

            if (dt.Rows.Count > 0)
            {
                gvStuInfo.DataSource = dt;
                gvStuInfo.DataBind();
            }
        }
    }
}