namespace P03_SalesDatabase
{
    using P03_SalesDatabase.Data;
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new SalesContext())
            {


                //NE STAVA KATO NAPISHA updata-database I ZATOVA PRAVA TAKA !!!

                db.Database.EnsureDeleted();
                //Suzdavame si bazata kato runvame programata
                db.Database.EnsureCreated();



                /*
	insert into Product(Description, Name, Price, Quantity)
	values
	('Keep Walking', 'Johnny Walker', 155.72, 550),
	('Dont drink it too mutch', 'RedBull', 8.44, 160),
	('This is the best product ever !!!', 'IsoSport', 2.63, 50);
	
	SELECT * FROM Product
	*/

                /*
                insert into Store(Name)
                values
                ('StoreOne'),
                ('StoreTwo'),
                ('StoreThree');

                SELECT * FROM Store
                */



                /*
                 VSICHKITE INSERTI : 
                  
                insert into Customer(CreditCardnumber, Email, Name)
                values
                ('1111 2222 3333 4444', 'atanas_kambitov@abv.bg', 'Atanas Kambitov'),
                ('4444 4444 4444 4444', 'asen_kambitov@abv.bg', 'Asen Kambitov'),
                ('3333 3333 3333 3333', 'anton_stoqnov@abv.bg', 'Anton Kambitov');

                SELECT * FROM Customer
                */

                /*
                insert into Sale(CustomerID,ProductID, StoreID)
                values
                (1,1,1),
                (2,2,2),
                (3,3,3)

                //Sus DATE
                insert into Sale(Date, CustomerID,ProductID, StoreID)
                values
                ('06/02/2000',1,2,3);


                SELECT * FROM Sale
                */



            }
        }
    }
}
