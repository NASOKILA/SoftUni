


/*

Zadacha 4:
Ne zabravqi che mojesh da 
polzvash 'closure' ako iskash neshto da ne se promenq

*/



class PaymentManager {
    constructor(title) {

        this.title = title;
    }

    render(id) {



        let table = $('<table></table>');
        let caption = $(`<caption>${this.title} Payment Manager</caption>`);

        table.append(caption);


        let tr = $('<tr></tr>')
        .append(`<th class="name">Name</th>`)
        .append(`<th class="category">Category</th>`)
        .append(`<th class="price">Price</th>`)
        .append(`<th>Actions</th>`);


        let thead = $(`<thead></thead>`).append(tr);
        table.append(thead);


        let tbody = $('<tbody class="payments"></tbody>');
        table.append(tbody);

        //butona
        let addBtn = $(`<button>Add</button>`).click(function() {
           
            let nameValue = $($(this).parent().parent().parent().parent().find('tfoot').find('tr').find('td')[0]).find('input')[0].value;
            let categoryValue = $($(this).parent().parent().parent().parent().find('tfoot').find('tr').find('td')[1]).find('input')[0].value;
            let priceValue = $($(this).parent().parent().parent().parent().find('tfoot').find('tr').find('td')[2]).find('input')[0].value;
            

            if(nameValue !== '' && categoryValue !== '' && priceValue !== '')
            {

                let deleteBtn = $('<button>Delete</button>')
                    .click(function(){
                        $(this).parent().parent().remove();
                });


                let additionalCode = $('<tr></tr>')
                .append(`<td>${nameValue}</td>`)
                .append(`<td>${categoryValue}</td>`)
                .append(`<td>${Number(priceValue)}</td>`)
                .append(
                    $(`<td></td>`)
                    .append(deleteBtn)
                )


                $(this).parent().parent().parent().parent()
                .append(additionalCode);


                $($(this).parent().parent().parent().parent().find('tfoot').find('tr').find('td')[0]).find('input')[0].value = "";
                $($(this).parent().parent().parent().parent().find('tfoot').find('tr').find('td')[1]).find('input')[0].value = "";
                $($(this).parent().parent().parent().parent().find('tfoot').find('tr').find('td')[2]).find('input')[0].value = "";
            }

        });




        let tfoodTr = $('<tr></tr>')
        .append('<td><input name="name" type="text"></td>')
        .append('<td><input name="category" type="text"></td>')
        .append('<td><input name="price" type="number"></td>')
        .append(
            $(`<td></td>`).append(addBtn)
        
        )



        let tfood = $('<tfoot class="input-data">');
        tfood.append(tfoodTr);
        table.append(tfood);

        this.table = table;    
        $(`#${id}`).append(this.table);

    }

}











