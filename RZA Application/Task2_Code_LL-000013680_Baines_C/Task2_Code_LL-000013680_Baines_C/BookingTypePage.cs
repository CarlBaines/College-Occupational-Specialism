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
    public partial class BookingTypePage : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }

        public BookingTypePage(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();
            this.accessibilityHelper = accessibilityHelper;
        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsPage settingsPage = new SettingsPage(accessibilityHelper);
            settingsPage.ShowDialog();
        }

        private void rzaNavLogo_Click(object sender, EventArgs e)
        {
            Hide();
            Home home = new Home(accessibilityHelper);
            home.ShowDialog();
        }

        private void txtAboutUs_MouseHover(object sender, EventArgs e)
        {
            txtAboutUs.Text = txtAboutUs.Text.ToUpper();
        }

        private void BookingTypePage_MouseLeave(object sender, EventArgs e)
        {
            txtAboutUs.Text = "About Us";
        }

        private void txtAboutUs_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAboutUs_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtAboutUs.Left;
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void txtAnimalFactsPage_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtAnimalFactsPage.Left;
            Hide();
            AnimalFactsPage animalFactsPage = new AnimalFactsPage(accessibilityHelper);
            animalFactsPage.ShowDialog();
        }

        private void txtAboutUs_MouseLeave(object sender, EventArgs e)
        {

        }

        private void btnZooBooking_Click(object sender, EventArgs e)
        {
            Hide();
            txtZooBookingPage zooBookingPage = new txtZooBookingPage(accessibilityHelper);
            zooBookingPage.ShowDialog();
        }

        private void txtAnimalFactsPage_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnHotelBooking_Click(object sender, EventArgs e)
        {
            Hide();
            HotelBookingPage hotelBookingPage = new HotelBookingPage(accessibilityHelper);
            hotelBookingPage.ShowDialog();
        }

        private void backtoHomeIcon_Click(object sender, EventArgs e)
        {
            Hide();
            Home home = new Home(accessibilityHelper);
            home.ShowDialog();
        }

        private void txtAnimalFactsPage_MouseHover(object sender, EventArgs e)
        {
            txtAnimalFactsPage.Text = txtAnimalFactsPage.Text.ToUpper();
        }

        private void txtAnimalFactsPage_MouseLeave(object sender, EventArgs e)
        {
            txtAnimalFactsPage.Text = "Animal Facts";
        }

        private void textBox1_MouseHover(object sender, EventArgs e)
        {
            txtBookingSelect.Text = txtBookingSelect.Text.ToUpper();
        }

        private void txtBookingSelect_MouseLeave(object sender, EventArgs e)
        {
            txtBookingSelect.Text = "Booking Select";
        }

        private void btnViewHotelRooms_Click(object sender, EventArgs e)
        {
            Hide();
            HotelRooms hotelRooms = new HotelRooms();
            hotelRooms.ShowDialog();
        }

        private void BookingTypePage_Load(object sender, EventArgs e)
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
