using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class ForgotPasswordPage : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a parameter.
        public AccessibilityHelper accessibilityHelper { get; set; }
        public ForgotPasswordPage(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();
            this.accessibilityHelper = accessibilityHelper;
            accessibilityHelper.UpdateFontSize(this.Controls);
        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            //Hides the form, loads and displays the form associated with the link that was clicked on.
            Hide();
            SettingsPage settingsPage = new SettingsPage(accessibilityHelper);
            settingsPage.ShowDialog();
        }

        private void txtSignIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSignIn_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtSignIn.Left;
            Hide();
            SignInPage signInPage = new SignInPage(accessibilityHelper);
            signInPage.ShowDialog();

        }

        private void txtSignUp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSignUp_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtSignIn.Left;
            Hide();
            SignUpPage signUpPage = new SignUpPage(accessibilityHelper);
            signUpPage.ShowDialog();
        }

        private void ForgotPasswordPage_Load(object sender, EventArgs e)
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

        private void rzaNavLogo_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Check to see if the user has entered their current username which is stored in the userDetails database using an SQL query.

            string currentUsername = txtEnterCurrentUsername.Text;

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH

            //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            //SQL Query which selects all records from the userDetails database where the user-inputted username is equal to the username stored in the database.
            SqlCommand cmd = new SqlCommand("select * from userDetails where username like @userName;");

            cmd.Connection = sqlConnection;

            cmd.Parameters.AddWithValue("@userName", currentUsername);

            sqlConnection.Open();

            DataSet dataset = new DataSet();
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
            dataadapter.Fill(dataset);

            sqlConnection.Close();

            bool currentUsernameFound = ((dataset.Tables.Count > 0) && (dataset.Tables[0].Rows.Count > 0));

            bool detailsCheck = true;

            
                while (detailsCheck)
                {
                    //Checks to see if the user has made an input.
                    if (txtEnterCurrentUsername.Text == string.Empty)
                    {
                        MessageBox.Show("Please enter your current username.", "Error",
       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        detailsCheck = false;
                        break;
                    }

                    //If current username is found it makes the controls visible in the form which allows the user to enter a new password.
                    if (currentUsernameFound)
                    {
                        MessageBox.Show("Your current username was found. Please create a new password");
                        lblResetPassword.Visible = true;
                        txtCreatePassword.Visible = true;
                        btnResetPassword.Visible = true;
                        break;

                    }

                    else
                    {

                        detailsCheck = false; 
                        break;
                    }


                }

                if (detailsCheck == false)
                {
                    MessageBox.Show("Your current username has not been found. Please try entering it again.", "Error",
       MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }
        
            
            
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            //string newPassword = txtCreatePassword.Text;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtCreatePassword.Text);

            //Tells the code where the database is.

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH

            //string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("update userDetails set password=@password");

            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            //Check to see if a new password has been entered

            if (hashedPassword == string.Empty)
            {
                MessageBox.Show("Please enter a new password to reset your old one.", "Error",
       MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            //Length check to check if the new password entered meets the requirements for the database.
            //Also to ensure usernames are not too small or too large.
            if (hashedPassword.Length < 5 || hashedPassword.Length > 100)
            {
                MessageBox.Show("Your password is either too small or too large. It should be between 5 characters to 50 characters long.", "Error",
      MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            else
            {

                cmd.Parameters.AddWithValue("@password", hashedPassword);

                cmd.ExecuteNonQuery();

                MessageBox.Show("You have successfully reset your password. Please sign back in.");

                sqlConnection.Close();

                Hide();
                SignInPage signInPage = new SignInPage(accessibilityHelper);
                signInPage.ShowDialog();
            }

            sqlConnection.Close();



        }
    }
}