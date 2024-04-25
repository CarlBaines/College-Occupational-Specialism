using System;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static Task2_Code_LL_000013680_Baines_C.Accessibility;

namespace Task2_Code_LL_000013680_Baines_C
{
    public partial class SignInPage : Form
    {   
        //gets sets the accessibilityHelper instance.
        public AccessibilityHelper accessibilityHelper { get; set; }

        //Takes the instance of the AccessibilityHelper class as a parameter.
        public SignInPage(AccessibilityHelper accessibilityHelper)
        {
            InitializeComponent();

            //applies the instance features of the AccessibilityHelper class
            this.accessibilityHelper = accessibilityHelper;
            
            //Calls the update font size method from the AccessibilityHelper class and takes the collection of controls in the form as a parameter.
            accessibilityHelper.UpdateFontSize(this.Controls);
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtGoToSignUp_MouseClick(object sender, MouseEventArgs e)
        {   

            //Hides the form, loads and displays the form associated with the link that was clicked on.
            Hide();
            SignUpPage signUp = new SignUpPage(accessibilityHelper);
            signUp.ShowDialog();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnNoSignIn_Click(object sender, EventArgs e)
        {
            
        }

        private void forgotPassword_Click(object sender, EventArgs e)
        {
            Hide();
            ForgotPasswordPage forgotPassword = new ForgotPasswordPage(accessibilityHelper);
            forgotPassword.ShowDialog();
        }

        private void txtSignUp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtSignUp_MouseClick(object sender, MouseEventArgs e)
        {   
            //Moves the navbar panel under the navbar link that the user has clicked on.
            navbarPanel.Left = txtSignUp.Left;
            Hide();
            SignUpPage signUp = new SignUpPage(accessibilityHelper);
            signUp.ShowDialog();
            
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void settingsIcon_Click(object sender, EventArgs e)
        {
            Hide();
            SettingsPage settingsPage = new SettingsPage(accessibilityHelper);
            settingsPage.ShowDialog();
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {   
            //Gets the user inputted username and password from the form.
            string username = txtEnterUsername.Text;
            //string password = txtEnterPassword.Text;

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtEnterPassword.Text);

            //DEFAULT PATH
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2\\zoo application database.mdf\";Integrated Security=True;Connect Timeout=30; Integrated Security = True";
            //

            //BACKUP PATH
            //
            //string connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = \"C:\\Users\\EXAM1238\\OneDrive - Middlesbrough College\\Documents\\Carl Baines\\Task 2 from backup\\zoo application database.mdf\"; Integrated Security = True; Connect Timeout = 30;";

            //Takes the connection string as a parameter for the SqlConnection class.
            SqlConnection sqlConnection = new SqlConnection(connectionString);


            

            //Create command that selects all usernames and passwords that are equal to user input.
            SqlCommand cmd = new SqlCommand("select * from userDetails where username like @userName and password = @password;");

            cmd.Connection = sqlConnection;
            cmd.Parameters.AddWithValue("@userName", username);
            cmd.Parameters.AddWithValue("@password", hashedPassword);

            sqlConnection.Open();


            DataSet dataset = new DataSet();
            //retrieves and saves data in the dataset using the sql command.
            SqlDataAdapter dataadapter = new SqlDataAdapter(cmd);
            dataadapter.Fill(dataset);

            sqlConnection.Close();


            //Checks to see if the dataset contains the username and password entered by the user.
            bool loginSuccessful = ((dataset.Tables.Count > 0) && (dataset.Tables[0].Rows.Count > 0));

            bool found = BCrypt.Net.BCrypt.Verify(txtEnterPassword.Text, hashedPassword);

            //Checks to see if the username and/or password fields are empty.
            if (username == string.Empty || hashedPassword == string.Empty)
            {
               MessageBox.Show("Invalid username or password", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            if (loginSuccessful)
            {
                
                MessageBox.Show("You have successfully signed in.");
                Hide();
                Home home = new Home(accessibilityHelper);
                home.ShowDialog();
            }

            if (found)
            {
                
                MessageBox.Show("You have successfully signed in.");
                Hide();
                Home home = new Home(accessibilityHelper);
                home.ShowDialog();
            }

            else
            {
                MessageBox.Show("Invalid username or password", "Error",
    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtGoToSignUp_MouseHover(object sender, EventArgs e)
        {
            txtGoToSignUp.Text = txtGoToSignUp.Text.ToUpper();
        }

        private void txtGoToSignUp_MouseLeave(object sender, EventArgs e)
        {
            txtGoToSignUp.Text = "Create an account";
        }

        private void forgotPassword_MouseHover(object sender, EventArgs e)
        {
            txtforgotPassword.Text = txtforgotPassword.Text.ToUpper();
        }

        private void txtforgotPassword_MouseLeave(object sender, EventArgs e)
        {
            txtforgotPassword.Text = "Forgot Password -->";
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
    }
}
