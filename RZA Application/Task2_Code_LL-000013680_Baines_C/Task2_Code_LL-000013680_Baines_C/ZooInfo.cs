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
using Task2_Code_LL_000013680_Baines_C.Properties;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class ZooInfo : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }
        public ZooInfo(AccessibilityHelper accessibilityHelper)
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

        private void txtBookingTypePage_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookingTypePage_MouseClick(object sender, MouseEventArgs e)
        {   
            navbarPanel.Left = txtBookingTypePage.Left;
            Hide();
            BookingTypePage bookingTypePage = new BookingTypePage(accessibilityHelper);
            bookingTypePage.ShowDialog();
        }

        private void txtAboutUs_MouseHover(object sender, EventArgs e)
        {
            txtAboutUs.Text = txtAboutUs.Text.ToUpper();
        }

        private void txtAboutUs_MouseLeave(object sender, EventArgs e)
        {
            txtAboutUs.Text = "About Us";
        }

        private void txtBookingTypePage_MouseHover(object sender, EventArgs e)
        {
            txtBookingTypePage.Text = txtBookingTypePage.Text.ToUpper();
        }

        private void txtBookingTypePage_MouseLeave(object sender, EventArgs e)
        {
            txtBookingTypePage.Text = "Booking";
        }

        private void textBox8_MouseHover(object sender, EventArgs e)
        {
            textBox8.Text = textBox8.Text.ToUpper();
        }

        private void textBox8_MouseLeave(object sender, EventArgs e)
        {
            textBox8.Text = "Hotel";
        }

        private void textBox2_MouseHover(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text.ToUpper();
        }

        private void textBox2_MouseLeave(object sender, EventArgs e)
        {
            textBox2.Text = "Toilets";
        }

        private void textBox3_MouseHover(object sender, EventArgs e)
        {
            textBox3.Text = textBox3.Text.ToUpper();
        }

        private void textBox3_MouseLeave(object sender, EventArgs e)
        {
            textBox3.Text = "Toilets";
        }

        private void textBox6_MouseHover(object sender, EventArgs e)
        {
            textBox6.Text = textBox6.Text.ToUpper();
        }

        private void textBox6_MouseLeave(object sender, EventArgs e)
        {
            textBox6.Text = "Monkeys";
        }

        private void textBox4_MouseHover(object sender, EventArgs e)
        {
            textBox4.Text = textBox4.Text.ToUpper();
        }

        private void textBox4_MouseLeave(object sender, EventArgs e)
        {
            textBox4.Text = "Bears";
        }

        private void textBox5_MouseHover(object sender, EventArgs e)
        {
            textBox5.Text = textBox5.Text.ToUpper();
        }

        private void textBox5_MouseLeave(object sender, EventArgs e)
        {
            textBox5.Text = "Lions";
        }

        private void textBox7_MouseHover(object sender, EventArgs e)
        {
            textBox7.Text = textBox7.Text.ToUpper();
        }

        private void textBox7_MouseLeave(object sender, EventArgs e)
        {
            textBox7.Text = "Giraffes";
        }

        private void textBox9_MouseHover(object sender, EventArgs e)
        {
            textBox9.Text = textBox9.Text.ToUpper();    
        }

        private void textBox9_MouseLeave(object sender, EventArgs e)
        {
            textBox9.Text = "Event Center";
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            Hide();
            MonkeyFactsPage monkeyFactsPage = new MonkeyFactsPage(accessibilityHelper);
            monkeyFactsPage.ShowDialog();
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            Hide();
            BearFactsPage bearFactsPage = new BearFactsPage(accessibilityHelper);
            bearFactsPage.ShowDialog();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            Hide();
            LionFactsPage lionFactsPage = new LionFactsPage();
            lionFactsPage.ShowDialog();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            Hide();
            txtGiraffeFactsPage giraffeFactsPage = new txtGiraffeFactsPage(accessibilityHelper);
            giraffeFactsPage.ShowDialog();
        }

        private void ZooInfo_Load(object sender, EventArgs e)
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
