using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IMovable
{

    //  PURVO SI PRAVIM KLAS I POSLE GO PREKRUSHTAVAME NA interface

    /*  
        interfeisite e dobre  da sa samo public ili internal, nqma 
        smisul da sa private !
        
        vutre v interfeisa DUMATA public NQMA SMISUL DA Q PISHEM ZASHTOTO
        KOMPILATORA Q SLAGA AVTOMATICHNO NAVSQKUDE !

        
        V TOZI INTERFEIS SHTE SLAGAME SAMO NESHTA KOITO SA MOVABLE !!!        
     */

        //tova e deklaraciqta na edin metod v interfeisite !
    void Move(int distance);

    /*
      Ne pishem nikakva logica v kudravi skobki, NE MOJEM DA PRAVIM OBEKT OT
      INTERFEIS KAKTO PRAVIM S KLASOVETE.
      Te ne se nasledqvat a se IMPLEMENTIRAT.

      KAKUV IM E SMISULA ?   TE SA KATO DOGOVORI, PROSTO SUSHTESTVUVAT !!!
      MOJE I BEZ TQH !
      TE SA PROSTO ZA INFORMACIQ I ZA PO PODREDEN KOD !
      NO TE NI KAZVAT KOE ZA KAKVO E, V SLUCHAQ IMovable trqbva da sudurja
      vsichko koeto se dviji, i vseki klas koito moje da dviji neshto 
      trqbva da e s tozi interfeis i da sudurja metodite mu !!!
         
    Moje da se prilaga i na metodi !!!

     TUK OBACHE NAVLIZA I POLIMORFIZMA NO TOVA E ZA PO NAPRED !!!
     
     */


}

