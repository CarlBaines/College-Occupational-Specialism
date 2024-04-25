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
    public partial class AnimalFactsPage : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }

        public AnimalFactsPage(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();
            this.accessibilityHelper = accessibilityHelper;
            accessibilityHelper.UpdateFontSize(this.Controls);
        }

        private void btnReadMoreLions_Click(object sender, EventArgs e)
        {
            Hide();
            LionFactsPage lionFactsPage = new LionFactsPage();
            lionFactsPage.ShowDialog();
        }

        private void btnReadMoreBears_Click(object sender, EventArgs e)
        {
            Hide();
            BearFactsPage bearsFactsPage = new BearFactsPage(accessibilityHelper);
            bearsFactsPage.ShowDialog();
        }

        private void btnReadMoreGiraffes_Click(object sender, EventArgs e)
        {
            Hide();
            txtGiraffeFactsPage giraffeFactsPage = new txtGiraffeFactsPage(accessibilityHelper);
            giraffeFactsPage.ShowDialog();
        }

        private void btnReadMoreMonkeys_Click(object sender, EventArgs e)
        {
            Hide();
            MonkeyFactsPage monkeyFactsPage = new MonkeyFactsPage(accessibilityHelper);
            monkeyFactsPage.ShowDialog();   
        }

        private void txtAboutUs_MouseHover(object sender, EventArgs e)
        {
            txtAboutUs.Text = txtAboutUs.Text.ToUpper();

        }

        private void txtAboutUs_MouseLeave(object sender, EventArgs e)
        {
            txtAboutUs.Text = "About Us";
        }

        private void txtAboutUs_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtAboutUs.Left;
            Hide();
            ZooInfo zooInfo = new ZooInfo(accessibilityHelper);
            zooInfo.ShowDialog();
        }

        private void txtBookingTypePage_MouseHover(object sender, EventArgs e)
        {
            txtBookingTypePage.Text = txtBookingTypePage.Text.ToUpper();
        }

        private void txtBookingTypePage_MouseLeave(object sender, EventArgs e)
        {
            txtBookingTypePage.Text = "Booking";
        }

        private void txtBookingTypePage_Click(object sender, EventArgs e)
        {
            navbarPanel.Left = txtBookingTypePage.Left;
            Hide();
            BookingTypePage bookingTypePage = new BookingTypePage(accessibilityHelper);
            bookingTypePage.ShowDialog();
        }

        private void txtAnimalFacts_MouseHover(object sender, EventArgs e)
        {
            txtAnimalFacts.Text = txtAnimalFacts.Text.ToUpper();
        }

        private void txtAnimalFacts_MouseLeave(object sender, EventArgs e)
        {
            txtAnimalFacts.Text = "Animal Facts";
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

        private void AnimalFactsPage_Load(object sender, EventArgs e)
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
