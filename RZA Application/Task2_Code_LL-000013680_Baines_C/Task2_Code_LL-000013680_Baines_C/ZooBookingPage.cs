using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class txtZooBookingPage : Form
    {   

        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }

        public txtZooBookingPage(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();
            this.accessibilityHelper = accessibilityHelper;
            accessibilityHelper.UpdateFontSize(this.Controls);
        }

        private void BackToBookingSelect_Click(object sender, EventArgs e)
        {
            Hide();
            BookingTypePage bookingTypePage = new BookingTypePage(accessibilityHelper);
            bookingTypePage.ShowDialog();
        }

        private void rzaNavLogo_Click(object sender, EventArgs e)
        {
            Hide();
            Home home = new Home(accessibilityHelper);
            home.ShowDialog();
        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsPage settingsPage = new SettingsPage(accessibilityHelper);
            settingsPage.ShowDialog();
        }

        private void txtHotelBooking_MouseHover(object sender, EventArgs e)
        {
            txtZooBooking.Text = txtZooBooking.Text.ToUpper();
        }

        private void txtHotelBooking_MouseLeave(object sender, EventArgs e)
        {
            txtZooBooking.Text = "Zoo Booking";
        }

        private void txtHotelBooking_Click(object sender, EventArgs e)
        {

        }

        private void txtAboutUsLink_MouseHover(object sender, EventArgs e)
        {
            txtAboutUsLink.Text = txtAboutUsLink.Text.ToUpper();
        }

        private void txtAboutUsLink_MouseLeave(object sender, EventArgs e)
        {
            txtAboutUsLink.Text = "About Us";
        }

        private void txtAboutUsLink_Click(object sender, EventArgs e)
        {
            navbarPanel.Left = txtAboutUsLink.Left;
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void visitDate_DateChanged(object sender, DateRangeEventArgs e)
        {   
            //Outputs the visit date selected onto a label on the form.
            lblVisitDate.Text = "Date of Visit: " + visitDate.SelectionEnd.ToString("dddd, d MMMM, yyyy");
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            //Save zoo booking details to ZooBookingDetails database
            //Take visitDate, numOfChildTickets, numOfAdultTickets
            try
            {
                string dateOfVisit = visitDate.SelectionEnd.ToString("dddd, d MMMM, yyyy");
                //? is used to check if the variables are null.
                int? numofChildTickets = Convert.ToInt32(txtNumOfChildTickets.Text);
                int? numofAdultTickets = Convert.ToInt32(txtNumOfAdultTickets.Text);

                //Tells the code where the database is.

                //DEFAULT PATH
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
                //

                //BACKUP PATH
                //
                //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";

                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand("AddZooRecord", sqlConnection);

                sqlConnection.Open();

                //Input validation to check if all user inputs have been entered.

                //Prescence check to see if any of the input fields are empty.
                if (dateOfVisit == string.Empty || numofChildTickets == null || numofAdultTickets == null)
                {
                    MessageBox.Show("Please provide all booking details", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                if (numofChildTickets < 0)
                {   

                    MessageBox.Show("Please enter a valid number of child tickets", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                if (numofAdultTickets < 0)
                {
                    MessageBox.Show("Please enter a valid number of adult tickets", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {


                    //Run stored procedure and save zoo booking details to database.
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@visitDate", dateOfVisit);
                    cmd.Parameters.AddWithValue("@numOfChildTickets", numofChildTickets);
                    cmd.Parameters.AddWithValue("@numOfAdultTickets", numofAdultTickets);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("You have successfully reserved ticket(s) for Riget Zoo Adventures. You can collect your ticket(s) on-visit.");
                    sqlConnection.Close();

                    Hide();
                    OrderSummaryPage orderSummaryPage = new OrderSummaryPage(accessibilityHelper);
                    orderSummaryPage.ShowDialog();

                }

                sqlConnection.Close();
            }

            catch (Exception)
            {   

                MessageBox.Show("Please provide all booking details", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void txtZooBookingPage_Load(object sender, EventArgs e)
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
