


class Dialog {
    constructor(message, callback) {
        this.message = message;
        this.callback = callback;
        this.inputs = [];
    }


    addInput(label, name, type) {
        this.inputs.push( {label, name, type} );
    }

    render() {

        let p = $(`<p>${this.message}</p>`)
        let innerDiv = $(`<div class="dialog">`)
            .append(p)

        //polzvame cikula
        for (let obj of this.inputs) {
            let input = $(`<input name="${obj.name}" type="${obj.type}">`);
            let l = $(`<label>${obj.label}</label>`);
            innerDiv.append(l);
            innerDiv.append(input);
        }

        //zakachame si butonite
        let okBtn = $('<button>OK</button>');
        let cancelBtn = $('<button>Cancel</button>');
        
        //attach events
        okBtn.on('click', function () {
            
            //pravim si obekt
            let obj = {};

            let inputs = $('.overlay').find('input').toArray();

            //pulnim si obekta
            inputs.forEach(i => obj[$(i).attr('name')] = $(i).val());

            //izvikvame callback funkciqta s obekta
            console.log(obj);
            this.callback(obj);

            $('.overlay').remove();
        })
        
        cancelBtn.on('click', function () {
            $('.overlay').remove();    
        })
        
        //append buttons to InnerDiv
        innerDiv.append(okBtn);
        innerDiv.append(cancelBtn);

        //zakachame inner diva za outerdiva
        let outerDiv = $(`<div class="overlay">`)
            .append(innerDiv);

        //append outer div to the body 
        $('body').append(outerDiv);

    }

}













