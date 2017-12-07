using System;
using System.Collections.Generic;
using System.Text;

namespace Employees.App.Commands.CommandInterface
{
    internal interface ICommand
    {
        /*
            s "params" mojem da mu podadem ne samo masiv ot stringove 
            no i samo stringovete bez da sa opakovani v masiv ili samo edin string
            Shte go prieme kato masiv sus samo edin string. !!!!!!!!!
            mojem da mu podadem "stringEdno", "stringDve", "stringTri" ...
        */

        string Excecute(params string[] args);
    }
}
