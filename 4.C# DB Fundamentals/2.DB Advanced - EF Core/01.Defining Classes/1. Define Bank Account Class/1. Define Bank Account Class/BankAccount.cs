using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BankAccount
{
    public int ID { get; set; }
    public decimal Balance { get; set; }

    
    public void Deposit(decimal amount)
    {
        this.Balance += amount;   
    }

    public void Withdraw(decimal amount)
    {
        this.Balance -= amount;
    }

    /*konstruktor za BankAccount*/
    /*s edin parametur za da mojem da slagame ID-to pri suzdavaneto na 
     bankoviq akaunt !!!*/
    public BankAccount(int id)
    {
        this.ID = id;
    }
}


