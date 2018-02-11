
    function solve(text){


        //TRIM ELEMENTS INSAFE QUOTES:
        text = text.toString().replace(/\s*(\")\s*/g, '"')
        text = text.toString().replace(/\s*(\.)\s*/g, '. ')
        text = text.toString().replace(/\s*(\,)\s*/g,', ')
        text = text.toString().replace(/\s*(\:)\s*/g,': ')
        text = text.toString().replace(/\s*(\!)\s*/g,'! ')
        text = text.toString().replace(/\s*(\?)\s*/g,'? ')
        text = text.toString().replace( /\s*(\;)\s*/g,'; ')
        


        let datePatt = /\.\s*(\d+)\.\s*(\d+)/g;
        let match = datePatt.exec(text);
        while(match !== null){

            let replacement = '.' + match[1] + '.' + match[2]; 
            text = text.replace(match[0], replacement);
            match = datePatt.exec(text); 
        }

        /*
        //replacevame tezi koito imat pone  ili poveche edin space sled edin ot tezi sinvoli 
        let pattTwo = /([.,!?:;])(\s+)/g;


        let matchTwo = pattTwo.exec(text);
        while(matchTwo !== null){


            text = text.replace(matchTwo[0], matchTwo[1] + ' ');
            matchTwo = pattTwo.exec(text); 
        }


        //nakraq ako nqmat space sled tqh im dobavqme
        //proverqvame pred vseki ot elementite ako elementa ne e ' ' znachi mu dobavqme OBACHE SHTE SE NALOJI DA POLZVAME INDEX
        let pattThree = /[.,!?:;]/g;

        let matchThree = pattThree.exec(text);
        let textArr = text.split('');
        while(matchThree !== null){

            let index = matchThree.index;

            textArr[index] = matchThree[0] + ' ';
            matchThree = pattThree.exec(text); 
        }

        text = textArr.join('');

        text = text.substring(0, text.length - 1);
        */

        //ako ima sequenci gi opravqme po sledniq nachin
        text = text.toString().replace(/\.\s*\.\s*\.\s*|\.\s*\.\s*\./g, '...');


        console.log(text);
    }


solve('Terribly formatted text      .  With chaotic spacings." Terrible quoting   "! Also this date is pretty confusing : 20   .   12.  16 .');

solve('Make,sure to give:proper spacing where is needed... !');


