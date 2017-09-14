


/*
	Triggeri:

	Te sa kato procedurite samoche ne gi ivikvame ruchno a gi zakachame za 
	nqkakvo SUBITIE v bazata i te si se izvikvat avtomatichno.

	SUBITIE oznachava CRUD operacii : Create, Read, Update, Delete

	MOJEM DA GI ZAKACHIM SAMO NA INSERT, UPDATE ili DELETE.

	Zakachat se za tablica i se izpulnqvat kogato se izulni daden SQL kod.

	Primerno : Mojem da gi zakachim za tablica i kato dobavim edin red da se 
	izpulnqvat, tova se naricha after Trigger.


	Ima dva vida:
		1. After Trigger - izpulnqva se sled kato deistvieto prikluchi
		2. Instead Tigger - zamenqt izvurshenata operaciq s druga
*/



/*

Syntax:
	Davame : 
	1.Ime na triggera
	2.za koq tablica da go zakachim
	3.kakuv trigger shte bude, FOR oznachava che shte e AFTER TRIGGER
	4.za koi event da go zakachim, v sluchaq za UPDATE 

*/

--Shte napravim trigger koito pri UPDATE na daden grad ako mu sloji kato ime da e NULL ili
--prazen string da ni hvurlq exeption : !!!!!!
CREATE TRIGGER tr_TownsUpdate ON Towns FOR UPDATE 
AS	
	--Ako sushtestvuva grad na koito imeto da e NULL(Ne kato string) ili e prazen string
	IF(EXISTS(select * from Towns WHERE Name IS NULL) OR EXISTS(select * from Towns WHERE LEN(Name) = 0))
	BEGIN
		--vhurlqme exeption
		ROLLBACK
		raiserror('Cannot Update because Town cannot be NULL or Empty',1,15)
		return;
	END

GO

--Mojem da vidim napravenite trigeri v papkata Triggers v tablicata na koqto sme gi zakachili !!!!!

select * from Towns
where TownID = 1;

--Testvame : Ako pudeitnem grad i mu daden ime da e prazen string ili NULL shte ni dade greshka.
UPDATE Towns
SET Name = ''
Where TownID = 1;

--Kato napishem NULL ni dava exeption taka ili imache


--VAJNO !!! : REALNO TOKUSHTO NAPRAVENOTO MOJE DA SE NAPRAVI S 'CHECK' KOETO E PO LESNO.



/*
	Primer s INSTEAD OF TRIGGER:
	Toi direktno zamenq cqlata operaciq:
*/

--Kogat oiztriem daden da dobavim nov s ime 'NewTown'
CREATE TRIGGER tr_TownsDelete ON Towns 
INSTEAD OF DELETE
AS
	INSERT Towns
	VALUES ('NewTown');
GO

--SHTE TESTVAME V TRANZAKCIQ ZA VSEKI SLUCHAI
BEGIN TRAN

--Triem grada Calgary
	DELETE FROM Towns
	WHERE TownID = 15;

--Kato gi selektirame vsichki vijdame che kato iztriem edin nakraq se poqvqva drug s ime 'NewTown' !
select * from Towns
ROLLBACK;







