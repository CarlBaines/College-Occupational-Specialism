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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class SettingsPage : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }

        public SettingsPage(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();
            this.accessibilityHelper = accessibilityHelper;
            accessibilityHelper.UpdateFontSize(this.Controls);
        }

        private void backToHome_Click(object sender, EventArgs e)
        {
          
        }

        private void SettingsPage_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSignInLink_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtSignInLink.Left;
            Hide();
            SignInPage signInPage = new SignInPage(accessibilityHelper);
            signInPage.ShowDialog();
        }

        private void txtSignUpLink_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSignUpLink_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtSignUpLink.Left;
            Hide();
            SignUpPage signUpPage = new SignUpPage(accessibilityHelper);
            signUpPage.ShowDialog();

        }

        private void txtSignInLink_MouseHover(object sender, EventArgs e)
        {
            txtSignInLink.Text = txtSignInLink.Text.ToUpper();
        }

        private void txtSignInLink_MouseLeave(object sender, EventArgs e)
        {
            txtSignInLink.Text = "Sign In";
        }

        private void txtSignUpLink_MouseHover(object sender, EventArgs e)
        {
            txtSignUpLink.Text = txtSignUpLink.Text.ToUpper();
        }

        private void txtSignUpLink_MouseLeave(object sender, EventArgs e)
        {
            txtSignUpLink.Text = "Sign Up";
        }

        private void txtSignInLink_TextChanged(object sender, EventArgs e)
        {

        }

        private void rzaNavLogo_Click(object sender, EventArgs e)
        {

        }

        private void txtSignIn_MouseHover(object sender, EventArgs e)
        {
            txtSettings.Text = txtSettings.Text.ToUpper();
        }

        private void txtSettings_MouseLeave(object sender, EventArgs e)
        {
            txtSettings.Text = "Settings";
        }

        private void continueArrow_Click(object sender, EventArgs e)
        {
            Hide();
            ChangeAccountDetails changeAccountDetails = new ChangeAccountDetails(accessibilityHelper);
            changeAccountDetails.ShowDialog();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
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
                    MessageBox.Show("High contrast mode enabled");
                }
                else
                {
                    //Enable high contrast
                    BackgroundImage = null;
                    MessageBox.Show("High contrast mode enabled");
                    this.BackColor = Color.FromArgb(255,234,0);
                    
                }
            }

            sqlConnection.Close();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            
        }

        private void btnChangeFontSize_Click(object sender, EventArgs e)
        {
            
            
            int fontSize;

            //Checks to see if the user input is an integer.
            try
            {
                fontSize = int.Parse(txtFontSize.Text);
            }

            //If the user input is not an integer, an error message box is displayed and the text box is reset.
            catch
            {
                MessageBox.Show("Please enter a valid font size");
                txtFontSize.Text = "";
                return;
            }

            //Else sets the user input entered as the font size and runs the method from the accessibiltiyHelper class.
            accessibilityHelper.fontSize = int.Parse(txtFontSize.Text);
            accessibilityHelper.UpdateFontSize(this.Controls);

            
        }

        private void txtFontSize_MouseHover(object sender, EventArgs e)
        {

        }

        private void txtFontSize_MouseClick(object sender, MouseEventArgs e)
        {
            txtFontSize.Text = string.Empty;
        }
    }
}
