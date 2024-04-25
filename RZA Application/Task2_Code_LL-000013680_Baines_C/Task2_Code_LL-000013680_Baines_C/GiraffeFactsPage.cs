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
    public partial class txtGiraffeFactsPage : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }

        public txtGiraffeFactsPage(AccessibilityHelper accessibilityHelper)
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

        private void backToFactsPage_Click(object sender, EventArgs e)
        {
            Hide();
            AnimalFactsPage animalFactsPage = new AnimalFactsPage(accessibilityHelper);
            animalFactsPage.ShowDialog();
        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsPage settingsPage = new SettingsPage(accessibilityHelper);
            settingsPage.ShowDialog();
        }

        private void txtGiraffeFacts_MouseHover(object sender, EventArgs e)
        {
            txtGiraffeFacts.Text = txtGiraffeFacts.Text.ToUpper();
        }

        private void txtGiraffeFacts_MouseLeave(object sender, EventArgs e)
        {
            txtGiraffeFacts.Text = "Giraffe Facts";
        }

        private void txtMoreFacts_MouseHover(object sender, EventArgs e)
        {
            txtMoreFacts.Text = txtMoreFacts.Text.ToUpper();
        }

        private void txtMoreFacts_MouseLeave(object sender, EventArgs e)
        {
            txtMoreFacts.Text = "More Facts";
        }

        private void txtMoreFacts_Click(object sender, EventArgs e)
        {
            navbarPanel.Left = txtMoreFacts.Left;
            Hide();
            AnimalFactsPage animalFactsPage = new AnimalFactsPage(accessibilityHelper);
            animalFactsPage.ShowDialog();
        }

        private void txtGiraffeFactsPage_Load(object sender, EventArgs e)
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

            //Data reader checks to see the value of the high contrast parameter in the userDetails database.
            sqlCommand.Parameters.AddWithValue("@highContrast", 0);

            sqlConnection.Open();

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
