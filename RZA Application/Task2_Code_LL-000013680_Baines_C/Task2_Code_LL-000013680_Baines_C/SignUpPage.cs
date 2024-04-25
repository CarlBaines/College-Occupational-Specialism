using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class SignUpPage : Form
    {
        //gets sets the accessibilityHelper instance.
        public AccessibilityHelper accessibilityHelper { get; set; }

        //Takes the instance of the AccessibilityHelper class as a parameter.
        public SignUpPage(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();

            //applies the instance features of the AccessibilityHelper class
            this.accessibilityHelper = accessibilityHelper;

            //Calls the update font size method from the AccessibilityHelper class and takes the collection of controls in the form as a parameter.
            accessibilityHelper.UpdateFontSize(this.Controls);
        }

        private void txtSignIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSignIn_MouseClick(object sender, MouseEventArgs e)
        {
            //Hides the form, loads and displays the form associated with the link that was clicked on.
            navbarPanel.Left = txtSignIn.Left;
            Hide();
            SignInPage signIn = new SignInPage(accessibilityHelper);
            signIn.ShowDialog();
        }

        private void txtBacktoSignIn_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBacktoSignIn_MouseClick(object sender, MouseEventArgs e)
        {   
            //Moves the navbar underline panel under the sign up navbar link text when it has been clicked on.
            //Hides the sign in form and opens the sign up page.
            navbarPanel.Left = txtSignIn.Left;
            Hide();
            SignInPage signIn = new SignInPage(accessibilityHelper);
            signIn.ShowDialog();
        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {   
            //Opens the settings page when the settings icon is clicked on.
            Hide();
            SettingsPage settingsPage = new SettingsPage(accessibilityHelper);
            settingsPage.ShowDialog();
        }

        private void SignUpPage_Load(object sender, EventArgs e)
        {

        }

        private void txtBacktoSignIn_MouseHover(object sender, EventArgs e)
        {   
            //Capitalises the link text upon mouse hover.
            txtBacktoSignIn.Text = txtBacktoSignIn.Text.ToUpper();

        }

        private void txtBacktoSignIn_MouseLeave(object sender, EventArgs e)
        {   
            //Reverts the text back to its original state once the mouse cursor leaves the link text.
            txtBacktoSignIn.Text = "Back to Sign In";
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {   
            //Takes the user-inputted username and password from the form.
            string registeredUsername = txtCreateUsername.Text;
            
            //Hashes the user-inputted password from the form to compare the hash key with the hash keys stored in the userDetails database.
            string hashedRegisteredPassword = BCrypt.Net.BCrypt.HashPassword(txtCreatePassword.Text);

            //Tells the code where the database is.

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH
            //
            //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from userDetails where userName = @userName", sqlConnection);

            sqlConnection.Open();

            cmd.Parameters.AddWithValue("@userName", registeredUsername);

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
                //Username available add record to database
                reader.Close();

                //calls an addrecord sql stored procedure
                cmd.CommandText = ("AddRecord");

                //temporary boolean for search purposes.
                bool detailsCheck = true;

                while (detailsCheck)
                {

                    //Checks to see if the user-inputted username or password are empty. Returns error message if so.
                    if (registeredUsername == string.Empty || hashedRegisteredPassword == string.Empty)
                    {
                        MessageBox.Show("Please enter a valid username and password", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    //Length checks for username and password requirements within database.
                    //Also to ensure inputted usernames and passwords are not too small and are not too large.
                    if (registeredUsername.Length < 5 || hashedRegisteredPassword.Length < 5)
                    {
                        MessageBox.Show("Please enter a username and password that are at least five letters long", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    if (registeredUsername.Length > 25)
                    {
                        MessageBox.Show("Please enter a smaller username", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    if (hashedRegisteredPassword.Length > 100)
                    {
                        MessageBox.Show("Please enter a smaller password", "Error",
        MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }

                    else
                    {
                        //Run stored procedure and save the user-inputted username and password to the userDetails database.

                        //Clears the parameters as the registered username was already taken as a parameter earlier to check if it already existed in the database.
                        cmd.Parameters.Clear();
                            
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@userName", registeredUsername);

                        cmd.Parameters.AddWithValue("@password", hashedRegisteredPassword);

                        cmd.Parameters.AddWithValue("@highContrast", 0);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("You have successfully created an account. Please sign in with your new account.");

                        


                        //Hide the sign up page and redirect the user to the sign in page to sign in with their new account.
                        Hide();
                        SignInPage signInPage = new SignInPage(accessibilityHelper);
                        signInPage.ShowDialog();

                    }

                    sqlConnection.Close();
                }







            }


            }
        private void txtSignIn_MouseHover(object sender, EventArgs e)
        {
            txtSignIn.Text = txtSignIn.Text.ToUpper();
        }

        private void txtSignIn_MouseLeave(object sender, EventArgs e)
        {
            txtSignIn.Text = "Sign In";
        }

        private void txtSignUp_MouseHover(object sender, EventArgs e)
        {
            txtSignUp.Text = txtSignUp.Text.ToUpper();
        }

        private void txtSignUp_MouseLeave(object sender, EventArgs e)
        {
            txtSignUp.Text = "Sign Up";
        }

        private void btnContinueWithoutAccount_Click(object sender, EventArgs e)
        {
            
        }
    }
}
