(function (){

let module = {
    
    id: 0,
    allReports: new Map(),
    element: null,
    report:(author, description, isReproducible, severity) => {
        
        //pubnim reporta kato za kluch slagame id-to +1 i kato value obekt s podadenite stoinosti
        this.allReports.set(this.id++, {
            author, 
            description, 
            isReproducible, 
            severity
        })
        
        //printirame si outputa kato izvikvame s output() funkciqta
        this.output();
    },
    setStatus: (id, newStatus) => {

        //vzimame go po Id ot allStatus obekta i mu setvame newStatus
        //vzima se kato obekt.
        this.allReports.get(id).status = newStatus;
    },
    remove: (id) => {

        //namirame go po id i go triem
        this.allReports.get(id).remove();
    },
    sort: (criteria) => {

        //sortirame vsichki reporti
        return [...this.allReports].sort((a,b) => {

        //ako nqmame criterii ili e = na ID sortirame taka
            if(criteria === 'ID' || !criteria)
                return a[0] - b[0];
            else
            a[1][criteria] - b[1][criteria];
        });
    },
    output: (selector) => {
        
        this.element = $(selector);
        for(let id in this.allReports){
            
            let report = this.allReports.get(id);

            this.element.append(
                $('<div>')
                .setAttribute(`id`, `report_${id}`)
                .addClass('report')
                .append($('<div>')
                    .addClass('body')
                    .append($(`<p>${report.description}</p>`))
            
                .append($('<div>')
                    .addClass('title')
                    .append($(`<span>`)
                    .addClass('author')
                    .text(`Submitted by: ${report.author}`))
                .append($(`<span>`)
                    .addClass('status')
                    .text(`${report.status} | ${report.severity}`))
                 ))
                )

        }      

    }

}




return module;

})()

solve();