using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class ChangeAccountDetails : Form
    {
        //Get set accessibilityHelper instance, is taken as a parameter and update font size method is called by taking the collection of controls on the form as a paramete
        public AccessibilityHelper accessibilityHelper { get; set; }
        public ChangeAccountDetails(AccessibilityHelper accessibilityHelper)
        {   
            InitializeComponent();
            this.accessibilityHelper = accessibilityHelper;
            accessibilityHelper.UpdateFontSize(this.Controls);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //Check to see if user-inputted username is in the database using SQL query.

            string oldUsername = txtEnterOldUsername.Text;

            //Tells the code where the database is.

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH
            //
            //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);




            //SQL Query which selects all records from the userDetails database where the user-inputted username is equal to the username stored in the database.
            SqlCommand cmd = new SqlCommand("select * from userDetails where username like @userName;");

            cmd.Connection = sqlConnection;

            cmd.Parameters.AddWithValue("@userName", oldUsername);

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
                if (txtEnterOldUsername.Text == string.Empty)
                {
                    MessageBox.Show("Current username not found. Please try again", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    detailsCheck = false;
                    break;
                }

                //If old username is found it makes the controls visible in the form which allows the user to enter a new username.
                if (currentUsernameFound)
                {
                    MessageBox.Show("You can now create a new username. You can also change your password if wanted.");
                    lblEnterNewUsername.Visible = true;
                    txtEnterNewUsername.Visible = true;
                    btnSubmitNewUsername.Visible = true;

                    lblCreateNewPassword.Visible = true;
                    txtCreateNewPassword.Visible = true;
                    btnSubmitNewPassword.Visible = true;
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

        private void btnSubmitOldPassword_Click(object sender, EventArgs e)
        {

        }

        private void txtAccountDetails_MouseHover(object sender, EventArgs e)
        {
            txtAccountDetails.Text = txtAccountDetails.Text.ToUpper();
        }

        private void txtAccountDetails_MouseLeave(object sender, EventArgs e)
        {
            txtAccountDetails.Text = "Account Details";
        }

        private void txtSignIn_MouseHover(object sender, EventArgs e)
        {
            txtSignIn.Text = txtSignIn.Text.ToUpper();
        }

        private void txtSignIn_MouseLeave(object sender, EventArgs e)
        {
            txtSignIn.Text = "Sign In";
        }

        private void txtSignIn_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtSignIn.Left;
            Hide();
            SignInPage signInPage = new SignInPage(accessibilityHelper);
            signInPage.ShowDialog();
        }

        private void txtSignUp_MouseHover(object sender, EventArgs e)
        {
            txtSignUp.Text = txtSignUp.Text.ToUpper();
        }

        private void txtSignUp_MouseLeave(object sender, EventArgs e)
        {
            txtSignUp.Text = "Sign Up";
        }

        private void txtSignUp_MouseClick(object sender, MouseEventArgs e)
        {
            navbarPanel.Left = txtSignUp.Left;
            Hide();
            SignUpPage signUpPage = new SignUpPage(accessibilityHelper);
            signUpPage.ShowDialog();
        }

        private void ChangeAccountDetails_Load(object sender, EventArgs e)
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

        public void btnSubmitNewUsername_Click(object sender, EventArgs e)
        {
            //Update record in database with the new username.


            string newUsername = txtEnterNewUsername.Text;

            //Tells the code where the database is.

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH

            //string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30";

            SqlConnection sqlConnection = new SqlConnection(connectionString);


            SqlCommand cmd = new SqlCommand("select * from userDetails where userName = @userName", sqlConnection);

            cmd.Connection = sqlConnection;

            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@userName", newUsername);

            //Executes an SQL database reader using the SQL command from above.
            SqlDataReader reader = cmd.ExecuteReader();

            //Checks to see if the reader has returned a row from the database where the user inputted username is equal to a already existing username in the userDetails database.
            if (reader.HasRows)
            {
                //Username is already taken in database
                MessageBox.Show("Username is already taken. Please enter a different one.", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
                reader.Close();
                sqlConnection.Close();
            }

            else
            {
                reader.Close();

                //Changes command to update username in userDetails record.
                cmd.CommandText = ("update userDetails set userName=@userName");

                //Checks to see if a new username has been entered.

                if (txtEnterNewUsername.Text == string.Empty)
                {
                    MessageBox.Show("Please enter a new username");
                }

                //Length check to check if the new username entered meets the requirements for the database.
                //Also to ensure usernames are not too small or too large.
                if (txtEnterNewUsername.Text.Length < 5 || txtEnterNewUsername.Text.Length > 25)
                {
                    MessageBox.Show("Your username is either too small or too large. It should be between 5 characters to 25 characters long.", "Error",
       MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                else
                {


                    cmd.Parameters.Clear();

                    cmd.Parameters.AddWithValue("@userName", newUsername);

                    cmd.ExecuteNonQuery();

                    MessageBox.Show("You have successfully changed your username. Please sign back in");

                    sqlConnection.Close();

                    Hide();
                    SignInPage signInPage = new SignInPage(accessibilityHelper);
                    signInPage.ShowDialog();
                }

                sqlConnection.Close();
            }


        }

        private void btnSubmitNewPassword_Click(object sender, EventArgs e)
        {
            //Create new password and update record in database

            //string newPassword = txtCreateNewPassword.Text;

            string newHashedPassword = BCrypt.Net.BCrypt.HashPassword(txtCreateNewPassword.Text);

            //Tells the code where the database is.

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH
            //
            //string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30";


            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("UpdatePassword", sqlConnection);

            sqlConnection.Open();

            //Checks to see if a new password has been entered.

            if (newHashedPassword == string.Empty)
            {
                MessageBox.Show("Please enter a new password");
            }

            //Length check to check if the new password entered meets the requirements for the database.
            //Also to ensure passwords are not too small or too large.
            if (newHashedPassword.Length < 5 || newHashedPassword.Length > 100)
            {
                MessageBox.Show("Your password is either too small or too large. It should be between 5 characters to 50 characters long.", "Error",
   MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }

            else
            {
                //Run stored procedure and update the record in the database with the new username.
                cmd.CommandType = CommandType.StoredProcedure;




                cmd.Parameters.AddWithValue("@password", newHashedPassword);

                cmd.ExecuteNonQuery();

                MessageBox.Show("You have successfully changed your password. You will be redirected back to the sign in page.");

                sqlConnection.Close();

                Hide();
                SignInPage signInPage = new SignInPage(accessibilityHelper);
                signInPage.ShowDialog();
            }

            sqlConnection.Close();

        }
    }
}
