using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class OrderSummaryPage : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }
        public OrderSummaryPage(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();
            this.accessibilityHelper = accessibilityHelper;
            accessibilityHelper.UpdateFontSize(this.Controls);
        }

        private void rzaNavLogo_Click(object sender, EventArgs e)
        {
            Hide();
            Home home = new Home(accessibilityHelper);
            home.ShowDialog();
        }

        private void txtOrderSummary_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtOrderSummary_MouseHover(object sender, EventArgs e)
        {
            txtOrderSummary.Text = txtOrderSummary.Text.ToUpper();
        }

        private void txtOrderSummary_MouseLeave(object sender, EventArgs e)
        {
            txtOrderSummary.Text = "Order Summary";
        }

        private void txtAboutUs_MouseHover(object sender, EventArgs e)
        {
            txtAboutUs.Text = txtAboutUs.Text.ToUpper();
        }

        private void txtAboutUs_MouseLeave(object sender, EventArgs e)
        {
            txtAboutUs.Text = "About Us";
        }

        private void txtAboutUs_Click(object sender, EventArgs e)
        {
            navbarPanel.Left = txtAboutUs.Left;
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void backToHome_Click(object sender, EventArgs e)
        {
            Hide();
            Home home = new Home(accessibilityHelper);
            home.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnZooOrderSummary_Click(object sender, EventArgs e)
        {
            //Get zoo booking details from database using stored procedure and display on form's controls.
            //Tells the code where the database is.

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH
            //
            //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from ZooBookingDetails;");

            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("Zoo Order Summary successfully found.");

                //Make label controls visible on form
                lblVisitDate.Visible = true;
                lblNumOfChildTickets.Visible = true;
                lblNumOfAdultTickets.Visible=true;

                //Outputs the booking details by outputting the content of the rows in the datatable.
                txtDateOfVisit.Text = dt.Rows[0]["visitDate"].ToString();
                txtNumOfChildTickets.Text = dt.Rows[0]["numOfAdultTickets"].ToString();
                txtNumOfAdultTickets.Text = dt.Rows[0]["numOfChildTickets"].ToString();
            }

            else
            {   
                MessageBox.Show("Zoo Booking Details were not found", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlConnection.Close();



        }

        private void btnHotelOrderSummary_Click(object sender, EventArgs e)
        {
            //Get hotel booking details from database using stored procedure and display on form's controls.
            //Tells the code where the database is.

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH
            //
            //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from HotelBookingDetails;");

            sqlConnection.Open();

            cmd.Connection = sqlConnection;

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            sqlDataAdapter.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                //Make label controls visible on form
                MessageBox.Show("Hotel Order Summary successfully found.");

                lblCheckInDate.Visible = true;
                lblCheckOutDate.Visible = true;
                lblNumOfResidents.Visible = true;
                lblRoomType.Visible = true;

                //Outputs the booking details by outputting the content of the rows in the datatable.
                txtCheckInDate.Text = dt.Rows[0]["checkInDate"].ToString();
                txtCheckOutDate.Text = dt.Rows[0]["checkOutDate"].ToString();
                txtNumOfResidents.Text = dt.Rows[0]["numOfResidents"].ToString();
                txtRoomType.Text = dt.Rows[0]["RoomType"].ToString();
            }

            else
            {
                MessageBox.Show("Hotel Booking Details were not found", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            sqlConnection.Close();

        }

        private void OrderSummaryPage_Load(object sender, EventArgs e)
        {
            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH
            //
            //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand sqlCommand = new SqlCommand("GetHighContrast", sqlConnection);
            sqlCommand.CommandType = CommandType.StoredProcedure;

            sqlCommand.Parameters.AddWithValue("@highContrast", 0);

            sqlConnection.Open();

            //Data reader checks to see the value of the high contrast parameter in the userDetails database.
            SqlDataReader highContrastReturned = sqlCommand.ExecuteReader();
            if (highContrastReturned.Read())
            {
                //If value is 0, return - high contrast not enabled.
                if (highContrastReturned[0].ToString() == "0")
                {
                    return;
                }
                else
                {
                    //enable high contrast
                    BackgroundImage = null;
                    this.BackColor = Color.FromArgb(255,234,0);
                }
            }

            sqlConnection.Close();
        }
    }
}
