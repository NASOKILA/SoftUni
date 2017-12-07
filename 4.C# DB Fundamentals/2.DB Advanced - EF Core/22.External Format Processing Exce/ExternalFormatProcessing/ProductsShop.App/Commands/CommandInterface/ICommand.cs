namespace ProductsShop.App.Commands.CommandInterface
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface ICommand
    {
        string Excecute(params string[] args);
    }
}
