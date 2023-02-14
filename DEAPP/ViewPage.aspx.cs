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
    public partial class Contact : Page
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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillClass(ddlClass);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadGridData();
        }
        private void LoadGridData()
        {
            DataTable dt = new DataTable();
            SqlConnection cnn;
            cnn = new SqlConnection(ConnectionStr);

            string query = @"SELECT Name, Class, convert(nvarchar(50), avg(Marks)) as Grade
                            from Student
                            where Class = '" + ddlClass.SelectedItem.Text + "' group by Name,CLass order by Grade desc";

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

                foreach (DataRow row in dt.Rows)
                {
                    if (int.Parse(row["Grade"].ToString()) > 80)
                    {
                        row["Grade"] = "A";
                    }
                    else if (int.Parse(row["Grade"].ToString()) > 70)
                    {
                        row["Grade"] = "B";
                    }
                    else if (int.Parse(row["Grade"].ToString()) > 60)
                    {
                        row["Grade"] = "C";
                    }
                    else if (int.Parse(row["Grade"].ToString()) > 50)
                    {
                        row["Grade"] = "D";
                    }
                    else if (int.Parse(row["Grade"].ToString()) > 40)
                    {
                        row["Grade"] = "E";
                    }
                    else if (int.Parse(row["Grade"].ToString()) < 40)
                    {
                        row["Grade"] = "F";
                    }
                }
                gvSTInfo.DataSource = dt;
                gvSTInfo.DataBind();


            }
            else
            {
                gvSTInfo.DataSource = null;
                gvSTInfo.DataBind();
            }
        }
    }
}