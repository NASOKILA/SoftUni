
function printRandNum() {
    //vzimame si random chislo ot 0 do 100 i go zakruglqme
    let num = Math.round(
        Math.random() * 100);

    //slagame go v nov div
    document.body.innerHTML += `<div>${num}</div>`;
}







