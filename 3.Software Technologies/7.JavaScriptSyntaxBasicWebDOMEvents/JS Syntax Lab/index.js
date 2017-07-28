



function Calculate(){
    let firstNum = document.getElementById("firstNum").value;
    let secondNum = document.getElementById("secondNum").value;


    // PROBLEMA E CHE VSICHKO NAPISANO Ot USERA IDVA KATO STRING I TRQBVA DA GO KONVERTIRAME VUV INT
    // IMAME DVA VARIANTA: ParseInt(...)  I Number(...)

    firstNum = Number(firstNum);
    secondNum = parseInt(secondNum);

    let sum = firstNum + secondNum;

    document.getElementById("result").innerHTML = sum;
    // Sus InnerHTML Kazvame kade da slojim tova koeto iskame v tozi sluchai slagame sum v taga s ID result
    // mojem da slojim i <h1> tagove ili kakvoto i da e

}






































