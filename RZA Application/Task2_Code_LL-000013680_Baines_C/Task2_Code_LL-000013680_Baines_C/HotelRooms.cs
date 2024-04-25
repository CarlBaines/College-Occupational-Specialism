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
    public partial class HotelRooms : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }
        public HotelRooms()
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

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsPage settingsPage = new SettingsPage(accessibilityHelper);
            settingsPage.ShowDialog();
        }

        private void lblGoToZooMap_Click(object sender, EventArgs e)
        {
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void lblGoToZooMap_MouseHover(object sender, EventArgs e)
        {
            lblGoToZooMap.Text = lblGoToZooMap.Text.ToUpper();
        }

        private void lblGoToZooMap_MouseLeave(object sender, EventArgs e)
        {
            lblGoToZooMap.Text = "ZooLand";
        }

        private void txtHotelRooms_MouseHover(object sender, EventArgs e)
        {
            txtHotelRooms.Text = txtHotelRooms.Text.ToUpper();
        }

        private void txtHotelRooms_MouseLeave(object sender, EventArgs e)
        {
            txtHotelRooms.Text = "Hotel Rooms";
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

        private void btnBookNow_Click(object sender, EventArgs e)
        {
            Hide();
            HotelBookingPage bookingPage = new HotelBookingPage(accessibilityHelper);
            bookingPage.ShowDialog();
        }

        private void btnBookNow2_Click(object sender, EventArgs e)
        {
            Hide();
            HotelBookingPage bookingPage = new HotelBookingPage(accessibilityHelper);
            bookingPage.ShowDialog();
        }

        private void btnBookNow2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void btnBookNow3_Click(object sender, EventArgs e)
        {
            Hide();
            HotelBookingPage bookingPage = new HotelBookingPage(accessibilityHelper);
            bookingPage.ShowDialog();
        }

        private void HotelRooms_Load(object sender, EventArgs e)
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
