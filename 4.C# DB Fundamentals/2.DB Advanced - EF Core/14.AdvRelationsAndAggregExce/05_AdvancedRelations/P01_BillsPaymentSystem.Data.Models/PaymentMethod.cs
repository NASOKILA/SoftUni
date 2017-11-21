﻿namespace P01_BillsPaymentSystem.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PaymentMethod
    {
        public PaymentMethod()
        {

        }

        public int Id { get; set; }

        public Type Type { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int? BankAccountId { get; set; }
        public BankAccount BankAccount { get; set; }

        public int? CreditCardId { get; set; }
        public CreditCard CreditCard { get; set; }
        
    }
}
