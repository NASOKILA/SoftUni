



function solution(matrix) {

    //vurtim cikul za vseki masiv
    for(let i = 0; i < matrix.length; i++){

        //napravo setvame edin obekt sus width height i dve funkcii
        matrix[i] = {
            width:matrix[i][0],
            height:matrix[i][1],
            area:function(){
                //Polzvame this za da polzvame width i height
                return this.width * this.height
            },
            compareTo:function(other){
                
                //presmqta rezultata ot .area() na 'a' minus .area() na 'b'
                let diff = other.area() - this.area();
                return diff || other.width - this.width;
            }
        }
    }

//sortirame i vrushtame matricata
    matrix.sort((a,b) => a.compareTo(b));
    return matrix;

}



console.log(solution([[10, 5],[3, 20],[5, 12]]))








