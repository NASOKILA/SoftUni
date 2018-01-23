namespace TeamBuilder.Client.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Client.Core.Commands;

    public class CommandDispatcher
    {
        public string Dispatch(string input)
        {
            string result = string.Empty;

            string[] inputArgs = input.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);

            //Ako sme podali parametri znachi imeto na komandata e urviq parametur ako nqma znachi imeto e prazen string !
            string commandName = inputArgs.Length > 0 ? inputArgs[0] : string.Empty;

            //Mahame imeto i ostavat samo parametrite
            inputArgs = inputArgs.Skip(1).ToArray();


            switch (commandName)
            {
                case "Exit":
                    ExitCommand exit = new ExitCommand();
                    result = exit.Excecute(inputArgs);
                    break;

                case "Login":
                    LoginCommand login = new LoginCommand();
                    result = login.Excecute(inputArgs);
                    break;

                case "Logout":
                    LogoutCommand logout = new LogoutCommand();
                    result = logout.Excecute(inputArgs);
                    break;

                case "RegisterUser":
                    RegisterUserCommand registerUser = new RegisterUserCommand();
                    result = registerUser.Excecute(inputArgs);
                    break;

                case "DeleteUser":
                    DeleteUserCommand deleteUser = new DeleteUserCommand();
                    result = deleteUser.Excecute(inputArgs);
                    break;

                case "CreateEvent":
                    CreateEventCommand createEvent = new CreateEventCommand();
                    result = createEvent.Excecute(inputArgs);
                    break;

                case "CreateTeam":
                    CreateTeamCommand createTeam = new CreateTeamCommand();
                    result = createTeam.Excecute(inputArgs);
                    break;
                    
                case "ShowEvent":
                    ShowEventCommand showEvent = new ShowEventCommand();
                    result = showEvent.Excecute(inputArgs);
                    break;

                case "ShowTeam":
                    ShowTeamCommand showTeam = new ShowTeamCommand();
                    result = showTeam.Excecute(inputArgs);
                    break;

                case "AddTeamTo":
                    AddTeamToCommand addTeamToCommand = new AddTeamToCommand();
                    result = addTeamToCommand.Excecute(inputArgs);
                    break;

                case "InviteToTeam":
                    InviteToTeamCommand inviteToTeam = new InviteToTeamCommand();
                    result = inviteToTeam.Excecute(inputArgs);
                    break;

                case "AcceptInvite":
                    AcceptInviteCommand acceptInviteCommand = new AcceptInviteCommand();
                    result = acceptInviteCommand.Excecute(inputArgs);
                    break;
                    
                case "DeclineInvite":
                    DeclineInviteCommand declinetInvite = new DeclineInviteCommand();
                    result = declinetInvite.Excecute(inputArgs);
                    break;
                    
                case "KickMember":
                    KickMemberCommand kickMemberCommand = new KickMemberCommand();
                    result = kickMemberCommand.Excecute(inputArgs);
                    break;
                    
                case "DisbandTeam":
                    DisbandTeamCommand disbandTeamCommand = new DisbandTeamCommand();
                    result = disbandTeamCommand.Excecute(inputArgs);
                    break;
                    
                default:
                    throw new NotSupportedException($"Command {commandName} not supported!");
            }

            return result;

        }

    }
}


