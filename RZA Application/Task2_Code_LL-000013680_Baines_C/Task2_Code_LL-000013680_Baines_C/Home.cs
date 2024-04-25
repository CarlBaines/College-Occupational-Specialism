using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class Home : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }

        
        public Home(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();
            this.accessibilityHelper = accessibilityHelper;
            
            accessibilityHelper.UpdateFontSize(this.Controls);

            
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
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

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsPage settingsPage = new SettingsPage(accessibilityHelper);
            settingsPage.ShowDialog();
        }

        private void infoIcon_Click(object sender, EventArgs e)
        {
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void calendarIcon_Click(object sender, EventArgs e)
        {
            //Check to see if user is signed in before allowing the user to go to the booking page.
            //

            Hide();
            BookingTypePage bookingTypePage = new BookingTypePage(accessibilityHelper);
            bookingTypePage.ShowDialog();
        }

        private void bookIcon_Click(object sender, EventArgs e)
        {
            Hide();
            AnimalFactsPage animalFactsPage = new AnimalFactsPage(accessibilityHelper);
            animalFactsPage.ShowDialog();
        }

        private void lblBookZoo1_MouseHover(object sender, EventArgs e)
        {
            lblBookZoo1.Text = lblBookZoo1.Text.ToUpper();
        }

        private void btnReadMore_Click(object sender, EventArgs e)
        {
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void btnFunFacts_Click(object sender, EventArgs e)
        {
            Hide();
            AnimalFactsPage animalFactsPage = new AnimalFactsPage(accessibilityHelper);
            animalFactsPage.ShowDialog();
        }

        private void label2_MouseClick(object sender, MouseEventArgs e)
        {
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void label2_MouseHover(object sender, EventArgs e)
        {
            label2.Text = label2.Text.ToUpper();
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Text = "ZooLand";
        }

        private void lblBookZoo1_MouseLeave(object sender, EventArgs e)
        {
            lblBookZoo1.Text = "Book";
        }

        private void lblBookZoo2_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void lblBookZoo2_MouseHover(object sender, EventArgs e)
        {
            lblBookZoo2.Text = lblBookZoo2.Text.ToUpper();    
        }

        private void lblBookZoo2_MouseLeave(object sender, EventArgs e)
        {
            lblBookZoo2.Text = "the Zoo";
        }

        private void lblBookHotel1_MouseHover(object sender, EventArgs e)
        {
            lblBookHotel1.Text = lblBookHotel1.Text.ToUpper();
        }

        private void lblBookHotel1_MouseLeave(object sender, EventArgs e)
        {
            lblBookHotel1.Text = "Book a";
        }

        private void lblBookZoo1_Click(object sender, EventArgs e)
        {   

            //Check to see if user is signed in before allowing the user to go to the booking page.
            //

            Hide();
            txtZooBookingPage zooBookingPage = new txtZooBookingPage(accessibilityHelper);
            zooBookingPage.ShowDialog();

        }

        private void lblBookZoo2_Click(object sender, EventArgs e)
        {

        }
        private void lblBookHotel1_Click(object sender, EventArgs e)
        {

            //Check to see if user is signed in before allowing the user to go to the booking page.
            //

            Hide();
            HotelBookingPage hotelBookingPage = new HotelBookingPage(accessibilityHelper);
            hotelBookingPage.ShowDialog();
        }

        private void lblBookHotel2_Click(object sender, EventArgs e)
        {

            //Check to see if user is signed in before allowing the user to go to the booking page.
            //

            Hide();
            HotelBookingPage hotelBookingPage = new HotelBookingPage(accessibilityHelper);
            hotelBookingPage.ShowDialog();
        }

        private void lblBookHotel2_MouseHover(object sender, EventArgs e)
        {
            lblBookHotel2.Text = lblBookHotel2.Text.ToUpper();
        }

        private void lblBookHotel2_MouseLeave(object sender, EventArgs e)
        {
            lblBookHotel2.Text = "Hotel Stay";
        }
    }
}
