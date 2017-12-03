namespace Forum.App.Commands.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommand
    {
        //Tova e interfeis za komandi, vsqka edna komanda koqto go inizializira shte ima tova koeto ima tuk

        string Excecute(params string[] args);

    }
}
