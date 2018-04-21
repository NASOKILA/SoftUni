﻿namespace Forum.App.Menus
{
	using Models;
	using Contracts;

    public class SignUpMenu : Menu
    {
		private const string DETAILS_ERROR = "Invalid Username or Password!";
		private const string USERNAME_TAKEN_ERROR = "Username already in use!";

		private bool error;

        private ILabelFactory labelFactory;
        private ICommandFactory commandFactory;
        private ISession session;
        private IUserService userService;
        private IForumReader forumReader;  // prosto chete ot konzolata

        public SignUpMenu(ILabelFactory labelFactory,
            ICommandFactory commandFactory,
            ISession session,
            IUserService userService,
            IForumReader forumReader)
        {
            this.labelFactory = labelFactory;
            this.commandFactory = commandFactory;
            this.session = session;
            this.userService = userService;
            this.forumReader = forumReader;

            this.Open();
        }
        
        private string UsernameInput => this.Buttons[0].Text.Trim();

		private string PasswordInput => this.Buttons[1].Text.Trim();

		private string ErrorMessage { get; set; }

		protected override void InitializeStaticLabels(Position consoleCenter)
		{
			string[] labelContents = new string[] { this.ErrorMessage, "Name:", "Password:" };

			Position[] labelPositions = new Position[]
			{
				new Position(consoleCenter.Left - this.ErrorMessage?.Length / 2 ?? 0, consoleCenter.Top - 13),   // Error: 
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 10),   // Name:
                new Position(consoleCenter.Left - 16, consoleCenter.Top - 8),    // Password:
            };

			this.Labels = new ILabel[labelContents.Length];

			this.Labels[0] = this.labelFactory.CreateLabel(
                labelContents[0], labelPositions[0], !this.error);


			for (int i = 1; i < this.Labels.Length; i++)
			{
				this.Labels[i] = this.labelFactory.CreateLabel(labelContents[i], labelPositions[i]);
			}
		}

		protected override void InitializeButtons(Position consoleCenter)
		{
			string[] buttonContents = new string[]
			{
				" ", " ", "Sign Up", "Back"
			};

			Position[] buttonPositions = new Position[]
			{
				new Position(consoleCenter.Left - 10, consoleCenter.Top - 10), // Name
                new Position(consoleCenter.Left - 6, consoleCenter.Top - 8),   // Password
                new Position(consoleCenter.Left + 16, consoleCenter.Top),      // Sign Up
                new Position(consoleCenter.Left + 16, consoleCenter.Top + 1)   // Back
            };

			this.Buttons = new IButton[buttonContents.Length];

			for (int i = 0; i < this.Buttons.Length; i++)
			{
				string buttonContent = buttonContents[i];
				bool isField = string.IsNullOrWhiteSpace(buttonContent);
				this.Buttons[i] = this.labelFactory.CreateButton(buttonContent, buttonPositions[i], false, isField);
			}
		}

		public override IMenu ExecuteCommand()
        {
            if (this.CurrentOption.IsField)
            {
                string fieldInput = " " + this.forumReader.ReadLine
                    (this.CurrentOption.Position.Left + 1, this.CurrentOption.Position.Top);

                this.Buttons[this.currentIndex] = this.labelFactory.CreateButton(
                    fieldInput, this.CurrentOption.Position, false, true);

                return this;
            }
            else
            {

                try
                {
                    string commandName = string.Join("", this.CurrentOption.Text.Split());

                    ICommand command = this.commandFactory.CreateCommand(commandName);

                    //podavame na sign up komandata username i parola
                    return command.Execute(this.UsernameInput, this.PasswordInput);
                }
                catch (System.Exception e) 
                {
                    this.error = true;
                    this.ErrorMessage = e.Message;
                    this.Open();

                    return this;
                }


            }
        }


	}
}
