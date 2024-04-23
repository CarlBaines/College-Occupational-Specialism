
# Task 2 Prototype (To Do List)
•	For the code  
o	Use a consistent naming convention.  
o	Indent properly.  
o	Comment all the section.  
•	For tracking  
•	Document and explain your development process.  
• Create a table that explains your versioning ([Version, date, Changes Made and Reason])
•	Add dates and use a versioning system.
• After you change the version, Identify what the problems were and how you acted and fixed them
•	For asset log use a table and  
o	Show the image if necessary.  
o	The source of the image  
o	Why you used this. Not how you got it but why you are using it regarding to the application.  
o	A table to link to external sites if necessary.  
•	For submission show and explain the interface of all your code  
• In the assets section, explain the images and links you have choosen regarding to legal, ethical and moral issues
• For testing use a test Heuritics sheet  
•	The interface and labels that explains what “what” does.  
•	A document that shows your code and explain blocks and what you were doing.  
• A breif explanation on the type of testing you want to do like unit testing...  
•	[Create a test plan for each part of the application] this would be classified as unit testing.  
•	[Test the application]  test the whole application  
•	A table testing each part of the code.  
•	Show the outcome of the fixes you made after testing and explain how they are now better. 

* Task 2 Development Documentation Layout
  APIs, Modules, Classes, Code, Description of Code, Changes During Development


### Guidance  
•	Make sure you use more than one programming language.
• Ensure to collectt user input no matter how little so you can have something to test 
• Make sure to add commments to the code that explains the logic of what you are doing

# Task 3A Feedback Gathering  
•	Get technical and non-technical users.    
• In the planning stage make sure to plan   
  o Who is your technical and non-technical user  
  o How will they give me feedback and how will I get the feedback forms, verbally ?  
  o What kind of questions to ask them ?  
  o What is my motive and what type of data am I hoping to get e.g about the functionality or about the interface  
  o Interview or observation... on what and on who?  
• Explain in details how you plan to gather high quality unbiased feedback  
• Add observational feedback, like what you noticed during interviews and stuff  
• Highlight the technical and none technical questions you will be asking each group  
•	Ask questions that you can act on [Apart from general questions]    
• For collectiing data you can use a table of [Name, type of audience, problem encountered, solution  
• You could have a rating of what they rate each section and like a google play store type format  
•	At the end of every individual feedback evaluate it and make sure you understand what they meant    
•	Have a list of things you need to improve due to the feedback that you received.  
### Guidance  
• The materials should allow for the gathering of high quality feedback for different aspect of the developed prototype  
• The use of the tools has resulted in feedback that consistently provides the opportunity for evidence- informed further iteration  
• Quality of communication is effective for both technical and non-technical audiences as a result of consistent use of appropriate techniques, methods and formats  
• The use of technical language that is consistently appropriate for the intended audience

# Task 3B Evaluation  
•	Talk about the key performance indicator in the essence of what the stake holder wanted and what you were able to deliver.  
• If possible lsit each KPI and state how you have met the requirement  
• While evaluating give examples and show proof like how that point as applied in the development  
•	Evaluate if all this have been met and how they have been met.  
• Talk about the legal implications of decisions you have made regarding  
  o Storing user data  
  o Assets used  
• Think about concepts like the GDPR, DPA, copyright and accessibility  
•	Talk about future developments which might have been highlighted during development or after development. Talk about how this will improve the application.  
### Guidance  
•	Consider how your solution meets these requirements rather than describing what you did.  
•	Make a valued judgment in relation to each of the bullets listed on the marking grid which are.  
  o	Functional and non-functional requirements of the system
  o	KPI’s  
  o	User acceptance criteria   
  o	Consideration of feedback  
•	Talk about the legal issues and why you feel your source is reliable regarding to assets.  
•	Evaluate how much have met the KPIs that you have set.  
•	Don’t lie.   



## Timings and Marks
Task 1: 20 hours [Proposal – 24, Design and test plan – 34] <br>
Task 2: 30 hours [Prototype – 48] <br>
Task 3a: 15 hours [Feedback – 24] <br>
Task 3b: 2 hours [Evaluation – 15] <br>

### C# Programming Concepts

Async Keyword

	The async keyword turns a method into an async method which allows you to use the await keyword. The await keyword 	suspends the calling method and gives control back to the caller until the awaited task is complete.

Lists

Fixed Length List

 	int[] intArray = new int {1,2,3,4,5}

Dynamic List

	List<data type> list = new List<int>()
 	list.add(value)
  	list.remove(value)

Loop through list

	foreach (int i in list){
 		Console.WriteLine(i);
   	]

For Loop

 	for (int i = 0; i <list.Count; i++)
  	#iterator variable, condition for loop, increments iterator
  	
  
  		

## Code Snippets

//Tells the code where the database is
            
	    string connectionString = "Data Source = mdf file path; Integrated Security = True; Connect Timeout = 30";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

//Sets up stored procedure
            
	    SqlCommand cmd = new SqlCommand("StoredProcedure", sqlConnection);

            cmd.CommandType = CommandType.StoredProcedure;

//Executes stored procedure

	sqlConnection.Open();

 	command.ExecuteNonQuery();
  
	sqlConnection.Close();

## API setup

	public HttpClient httpClient { get; set; }
	public string APIKey = "apikey";

	httpClient = new HttpClient();

## Pulling data from API example using NewtonSoft

	HttpResponseMessage response = await httpClient.GetAsync($"fullUrl{APIKey}");
	string payload = await response.Content.ReadAsStringAsync();

	JObject payloadObject = JObject.Parse(payload);

 	#returns 
 	return new List<float>()
 	{
     		(float)payloadObject[0]["lat"],
     		(float)payloadObject[0]["lon"]
 	};


## Database and Class File Definitions
	ID IDENTITY
 	HIGHCONTRAST BIT

//Get set method

        public int Id { get; set; }

 

## Stored Procedures

ADD RECORD

	CREATE PROCEDURE [dbo].[AddRecord]

	(
	
 	@username nvarchar(50),
	@password nvarchar(200)

	)

	as

	begin

	Insert into UserDetails values (@username, @password)

	End


Select all details from database

	CREATE PROCEDURE [dbo].[GetUserDetails]

	as

	begin

	select * from UserDetails

	End




UPDATE RECORD IN DATABASE

	CREATE PROCEDURE [dbo].[UpdateRecord]

	(	
	
 	@StdId int, 
	@username nvarchar(50),
	@password nvarchar(200)

	)
	as

	begin

	update UserDetails
	set username=@username,
	password=@password
	where Id=@StdId

	end

GET HIGH CONTRAST

	CREATE PROCEDURE GetHighContrast
 	(
	@Username NVARCHAR(50)
	)
	AS
 
	BEGIN
	    
    	SELECT @HighContrast = HighContrast
    	FROM Users
    	WHERE Username = @Username
	
	SELECT @HighContrast AS HighContrastValue
 
	END

## Methods of input validation

	string.IsNullOrWhiteSpace
	string.Empty

## Application Features

CALENDAR DROPDOWN MENU FOR RESERVATION SYSTEM

MonthCalendar Control

	txtDateSelect.Text = monthCalendar.SelectionRange.Start.ToShortDateString();
 	# outputs a user-selected date in a text box and converts it to a short date.

Labels to display length of stay

	fromlabel.Text = monthCalendar1.SelectionStart.ToString();
 	tolabel.Text = monthCalendar1.SelectionEnd.ToString();

  	#format date to day, number, month, year

   	("dddd, d MMMM, yyyy");

PASS DATA FROM ONE FORM TO ANOTHER (HELPFUL FOR ORDER SUMMARY PAGE)

 	public string stdpieceOfData {get; set;}
  	form.stdpieceOfData = textBox.Text
	----Form you want to pass data to----
 	textBox.Text = std.pieceOfData;
  
SAVE USER SETTINGS AT RUN TIME

Project Properties -> Settings -> Enter default name, type, scope and value of variables -> Save Settings file

Public void GetSettings() Method (Call this method on form load)

 	lblName.Text = Properties.Settings.Default.Name;


Public void SaveSettings() Method

 	Properties.Settings.Default.Name = txtName.Text;

  	Properties.Settings.Default.Save();

Onbutton Click

 	SaveSettings();
	GetSettings();

PANEL/NAVBAR LINK UNDERLINE

On label click

	private void label1_Click(object sender, EventArgs e)
	{
    		panel.Left = label1.Left;
	}

DRAWING TOOL (Possible use for educational materials)

 	Set panel background image to chosen image (so it can be drawn over)

   	gp = panel1.CreateGraphics();

     	int x = 0
       	int y = 0
	Graphics gp;

 	MOUSE CLICK EVENTS

   	MouseUp

     	start = false;

      	MouseMove

       	if (start)
	{
 		if (x > 0 && y > 0)
   		{
			Pen p = new Pen (Brushes.Color, brushSize);
   			gp.DrawLine(p , x, y, e.X, e.Y);
      		}

  		x = e.X;
    		y = e.Y;
      	}

       	MouseDown

 	start = true;

 

## Accessibility Features

## Get high contrast using stored procedure (returning data from database)
	SqlCommand sqlCommand = new SqlCommand("GetHighContrast", sqlConnection);
	sqlCommand.CommandType = CommandType.StoredProcedure;
	
	sqlCommand.Parameters.AddWithValue("Username", username);
	
	sqlConnection.Open();
	    
	SqlDataReader highContrastReturned = sqlCommand.ExecuteReader();
	if (highContrastReturned.Read())
	{
		if (highContrastReturned[0].ToString() == "1")
		{
		this.BackColor = Color.FromArgb(0, 0, 15);
		} 
		else
		{
		this.BackColor = Color.FromArgb(35,35,80);
	    	}
	    }
	    
	sqlConnection.Close();


REMOVE BACKGROUND IMAGE ON CLICK

	BackgroundImage = null;


 
## Increase font size of common controls

Accessibility Class

	public class AccessibilityHelper
	{
	    public float? fontSize { get; set; }
	
	    public User currentUser { get; set; } = null;
	
	    public AccessibilityHelper() { }
	    public AccessibilityHelper(float fontSize)
	    {
	        this.fontSize = fontSize;
	    }
	
	    public void UpdateFontSize(Control.ControlCollection controls)
	    {
	        if (fontSize == null) return;
	
	        foreach (Control control in controls)
	        {
	            control.Font = new System.Drawing.Font(control.Font.Name, (float)fontSize);
	        }
	    }
	
	
	}

IN EVERY FORM YOU WANT THE FONT SIZE TO APPLY TO

	public AccessibilityHelper accessibilityHelper { get; set; }

 	public Form1(AccessibilityHelper accessibilityHelper)

    		this.accessibilityHelper = accessibilityHelper;
		accessibilityHelper.UpdateFontSize(this.Controls);

FONT SIZE BUTTON CLICK

	 int fontSize;

	 //Checks to see if the user input is an integer.
	 try
	 {
	     fontSize = int.Parse(txtChangeFontSize.Text);
	 }
	 
	 //If the user input is not an integer, an error message box is displayed and the text box is reset.
	 catch
	 {
	     MessageBox.Show("Please enter a valid font size");
	     txtChangeFontSize.Text = "";
	     return;
	 }
	 
	 //Else sets the user input entered as the font size and runs the method from the accessibiltiyHelper class.
	 accessibilityHelper.fontSize = int.Parse(txtChangeFontSize.Text);
	 accessibilityHelper.UpdateFontSize(this.Controls);
	            
 

## Background Colour Changer

On button click

	this.BackColor = System.Drawing.Color.Colour;

## Change text color and font size of individual controls on the form
RADIO BUTTONS

	radioButton_CheckedChanged{
 		label.ForeColor = Color.Blue;
   	}

COMBO BOX

Edit items in string collection editor

	{
 		int size = int.Parse(comboBox.Text);
   		label.Font = new Font(label.Font.Name, size, label.Font.Style);
     	}

CHECKBOXES

	{
 		label.Font = new Font (label.Font.Name, label.Font.Size, label.Font.Style ^ FontStyle.Bold);

	}

## Modules

EXAMPLE OF HASHING

Install module (use using moduleName)

	found = BCrypt.Net.BCrypt.Verify(txtPasswordSignIn.Text, user.password);
 
	string hashedPassword = BCrypt.Net.BCrypt.HashPassword(txtPasswordSignUp.Text);

NewtonSoftJSON

	string payload = await response.Content.ReadAsStringAsync();

	JArray payloadObject = JArray.Parse(payload);


## ISSUES TO WORK WITH TOMORROW

- USER ACCESS LEVELS
- FONT SIZE (ACCESSIBILITY HELPER)
  	check program.cs on mock

- HIGH CONTRAST AND APPLYING IT TO ALL PAGES
- BUGS IN TEST TABLE




