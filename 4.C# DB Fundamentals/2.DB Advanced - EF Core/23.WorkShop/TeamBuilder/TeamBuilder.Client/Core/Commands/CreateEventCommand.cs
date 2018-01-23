namespace TeamBuilder.Client.Core.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Text;
    using TeamBuilder.Data;
    using TeamBuilder.Models;

    public class CreateEventCommand
    {

        public string Excecute(string[] inputArgs)
        {
            using (var db = new TeamBuilderContext())
            {

                string eventName = inputArgs[0];

                string description = inputArgs[1];

                if (!inputArgs[2].Contains("/") || !inputArgs[3].Contains(":")
                    || !inputArgs[4].Contains("/") || !inputArgs[5].Contains(":"))
                    throw new ArgumentException("Please insert the dates in format: [dd/MM/yyyy HH:mm]!");

                string fullStartDate = inputArgs[2] + " " + inputArgs[3];

                string fullEndDate = inputArgs[4] + " " + inputArgs[5];


                DateTime endDate;
                DateTime startDate;
                try
                {
                    startDate =
                    DateTime.ParseExact(fullStartDate,
                        "dd/MM/yyyy HH:mm",
                        CultureInfo.InvariantCulture);


                    endDate =
                      DateTime.ParseExact(fullEndDate,
                           "dd/MM/yyyy HH:mm",
                           CultureInfo.InvariantCulture);
                }
                catch 
                {
                    throw new ArgumentException("Please insert the dates in format: [dd/MM/yyyy HH:mm]!");
                }

                       
                if (startDate > endDate)
                    throw new ArgumentException("Start date should be before end date.");

                if (Session.User == null)
                    throw new InvalidOperationException("You should login first!");

                //get the logged user
                User currentUser = Session.User;

                //create the new event
                Event e = new Event()
                {
                    Name = eventName,

                    Description = description,

                    StartDate = startDate,

                    EndDate = endDate,

                    CreatorId = currentUser.Id
                    
                };

                db.Events.Add(e);
                db.SaveChanges();

                return $"Event {e.Name} was created successfully!";

            }


        }
        
    }
}
