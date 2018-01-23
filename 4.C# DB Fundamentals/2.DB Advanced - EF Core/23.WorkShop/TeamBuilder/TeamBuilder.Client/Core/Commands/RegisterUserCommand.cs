namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using TeamBuilder.Client.Utilities;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class RegisterUserCommand
    {
        public string Excecute(string[] inputArgs)
        {

            Checks.CheckLenght(7, inputArgs);


            string username = inputArgs[0];

            //proverka na duljinata na username
            if (username.Length < Constants.MinUsernameLength || username.Length > Constants.MaxUsernameLength)
                throw new ArgumentException(string.Format(Constants.ErrorMessages.UsernameNotValid, username));

            
            string password = inputArgs[1];

            //proverka dali parolata nqma chilo ili GlavnaBukva  
            if(password.Any(char.IsDigit) || !password.Any(char.IsUpper))
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordNotValid, password));


            string repeatPassword = inputArgs[2];

            //proverka dali suvpadat parolite
            if (password != repeatPassword)
                throw new ArgumentException(string.Format(Constants.ErrorMessages.PasswordDoesNotMatch));


            string firstName = inputArgs[3];
            string lastName = inputArgs[4];

            //Ako moje da se parsne v age i isNumber stava true
            int age;
            bool isNumber = int.TryParse(inputArgs[5], out age);


            if(!isNumber || age <= 0)
                throw new ArgumentException(string.Format(Constants.ErrorMessages.AgeNotValid));

            //Ako moje da se parsne v gender i isGenderValid stava true
            Gender gender;
            bool isGenderValid = Enum.TryParse(inputArgs[6], out gender);

            if(!isGenderValid)
                throw new ArgumentException(string.Format(Constants.ErrorMessages.GenderNotValid));

            //Proverqvame dali usera sushtestvuva
            if (CommandHelper.IsUserExisting(username))
                throw new InvalidOperationException(string.Format(Constants.ErrorMessages.UsernameIsTaken, username));

            this.RegisterUser(username, password, firstName, lastName, age, gender);

            return $"User {username} was registered successfully!";
        }

        private void RegisterUser(string username, 
                                  string password, 
                                  string firstName, 
                                  string lastName, 
                                  int age, 
                                  Gender gender)
        {

            using (var db = new TeamBuilderContext())
            {
                User user = new User()
                {
                    Username = username,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Age = age,
                    Gender = gender
                };

                db.Users.Add(user);

                db.SaveChanges();

            }


        }
    }
}
