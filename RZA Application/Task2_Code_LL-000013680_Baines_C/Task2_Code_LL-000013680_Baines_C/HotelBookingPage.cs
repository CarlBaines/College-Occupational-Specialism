using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class HotelBookingPage : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }

       
        public HotelBookingPage(AccessibilityHelper accessibilityHelper)
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

        private void txtAboutUsLink_Click(object sender, EventArgs e)
        {
            navbarPanel.Left = txtAboutUsLink.Left;
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void txtHotelBooking_MouseHover(object sender, EventArgs e)
        {
            txtHotelBooking.Text = txtHotelBooking.Text.ToUpper();
        }

        private void txtHotelBooking_MouseLeave(object sender, EventArgs e)
        {
            txtHotelBooking.Text = "Hotel Booking";
        }

        private void txtAboutUsLink_MouseHover(object sender, EventArgs e)
        {
            txtAboutUsLink.Text = txtAboutUsLink.Text.ToUpper();
        }

        private void txtAboutUsLink_MouseLeave(object sender, EventArgs e)
        {
            txtAboutUsLink.Text = "About Us";
        }

        private void btnConfirmBooking_Click(object sender, EventArgs e)
        {
            try
            {
                //Save booking details to HotelBookingDetails database.
                //Take Check-In Date, Check-Out Date, Number of Residents, Room Type from form

                string checkInDate = lengthOfStay.SelectionStart.ToString("dddd, d MMMM, yyyy");
                string checkOutDate = lengthOfStay.SelectionEnd.ToString("dddd, d MMMM, yyyy");

                //int? to check if it has a null value when input validating.
                int? numofResidents = Convert.ToInt32(txtNumOfResidents.Text);

                string roomType = selectRoomType.Text;

                //Tells the code where the database is.

                //DEFAULT PATH
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
                //

                //BACKUP PATH

                //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";

                SqlConnection sqlConnection = new SqlConnection(connectionString);

                SqlCommand cmd = new SqlCommand("AddHotelRecord", sqlConnection);

                sqlConnection.Open();





                //Input validation to check if all inputs have been entered/selected

                if (checkInDate == string.Empty || checkOutDate == string.Empty || numofResidents == null || roomType == string.Empty)
                {
                    MessageBox.Show("Please provide all booking details", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
                    
                }

                if (numofResidents < 0)
                {   
                    MessageBox.Show("Please enter a valid number of residents", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                else
                {
                    //Run stored procedure and save hotel booking details to database.
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@checkInDate", checkInDate);
                    cmd.Parameters.AddWithValue("@numOfResidents", numofResidents);
                    cmd.Parameters.AddWithValue("@RoomType", roomType);
                    cmd.Parameters.AddWithValue("@checkOutDate", checkOutDate);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("You have successfully reserved a booking to RZA's On-Site Hotel!");

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

        private void lengthOfStay_DateChanged(object sender, DateRangeEventArgs e)
        {   

            //Changes the startDate label text to the check-in date.
            startDate.Text = "Check-In Date: " + lengthOfStay.SelectionStart.ToString("dddd, d MMMM, yyyy");
            //Changes the endDate label text to the check-out date.
            endDate.Text = "Check-Out Date: " + lengthOfStay.SelectionEnd.ToString("dddd, d MMMM, yyyy");
        }

        private void HotelBookingPage_Load(object sender, EventArgs e)
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
