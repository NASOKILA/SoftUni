namespace Forum.Services.Contracts
{
    using Forum.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IUserService
    {
        /*Shte napravim takache da mojem da vzimame useri po Id i po UserName i dr.
         INTEREISITE OT PRED IMAT 'I'*/

            //Pravim si metodi za tozi interfeis
        User ById(int id); //priema id i vrushta User

        User ByUsername(string userName); //priema username i vrushta User

        User ByUsernameAndPassword(string username, int password); //priema username i parola i vrushta User

        User Create(string username, int password); //priema username i parola i vrushta User

        void Delete(int id); //priema id i ne vrushta nishto

        //Sega vseki klas koito nasledqva tozi interfeis shte ima takuiva metodi.


    }
}
