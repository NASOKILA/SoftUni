
// this function will be called when we create a new calculator instance
function Calculator(leftOperand, operator, rightOperand){

    // lets define the calculator properties:
    this.leftOperand = leftOperand;
    this.operator = operator;
    this.rightOperand = rightOperand;

    // the following function will calculate the result !
    this.caculateResult = function result(){
        let result = 0;

        switch(this.operator) {
            case '+':
                result = this.leftOperand + this.rightOperand;
                break;
            case '-':
                result = this.leftOperand - this.rightOperand;
                break;
            case '*':
                result = this.leftOperand * this.rightOperand;
                break;
            case '/':
                result = this.leftOperand / this.rightOperand;
                break;
        }

        return result;
    }

}

// exportvame tozi kalkulator za da moje da se polzva izvun tozi fail !
module.exports = Calculator;















