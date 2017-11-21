using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Person
{
    private int v1;
    private string v2;

    public decimal Balance { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public List<BankAccount> Accounts { get; set; }

    /*Konstruktor bez parametri*/
    public Person()
    {
        this.Accounts = new List<BankAccount>();
    }



    /*konstruktor s dva parametura*/
    public Person(int age, string name):this()
    {
        /*AKO IMAME DVA PARAMETURA PURVO SHTE SE IZPULNI TOZI
          KONSTRUKTOR, OBACHE :this() OZNACHAVA CHE PURVO SHTE 
          IZVIKA PRAZNIQ KONSTRUKTOR I POSLE TOZI KONSTRUKTOR.*/

        this.Balance = 0; /*setvame  balansa da e na 0 po default*/
        this.Name = name;
        this.Age = age;
        this.Accounts = new List<BankAccount>();
    }

    /*konstruktor s tri parametura*/
    public Person(int age, string name,  List<BankAccount> accounts)
        :this(age, name)
    {
        //this.Name = name;
        //this.Age = age;

        //VMESTO DA ISEM GORNITE DVA REDA MOJEM PROSTO DA VIKNEM 
        //PURVO PREDISHNIQ KONSTRUKTOR KATO NAPISHEM :this(age, name)

        this.Accounts.AddRange(accounts); /*taka vkarvame spisuk v spisuk !*/
    }

   
   
    /*TEZI PRIMERI POKZVA 'KONKATENACIQ NA KONSTRUKTORI' !!!
        EDIN KONSTRUKTOR MOJE DA VIKA DRUG. 
        V NASHIQ SLUCHAI KONSTRUKTURA VINAGI VIKA GORNIQ !!!
     */


}

