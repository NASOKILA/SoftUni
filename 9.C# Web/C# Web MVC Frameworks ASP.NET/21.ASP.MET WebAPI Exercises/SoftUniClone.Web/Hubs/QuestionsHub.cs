using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace SoftUniClone.Web.Hubs
{
    //nasledqva Hub klasa
    public class QuestionsHub : Hub
    {

        //pri nachaloto na vruzkata s tozi hub
        public override Task OnConnectedAsync()
        {
            //mojem da dobavqme ID -ta na useri i drugi neshta.
            return base.OnConnectedAsync();
        }

        //pri krai na vruzkata
        public override Task OnDisconnectedAsync(Exception exception)
        {
            //mojem da mahame useri ot dadena grupa.
            return base.OnDisconnectedAsync(exception);
        }
    }
}
