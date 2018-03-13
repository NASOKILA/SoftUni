
function solve(ticketDescription, sortingCriteria) {

    let tickets = [];

    class Ticket {
        constructor(destination, price, status) {
            this.destination = destination;
            this.price = Number(price);
            this.status = status;
        }
    }

    for (let ticketArgs of ticketDescription) {
            
        let args = ticketArgs.split('|');
        let destination = args[0];
        let price = args[1];
        let status = args[2];
    
        tickets.push(new Ticket(destination, price, status));
    }

    tickets.sort((a,b) => a[`${sortingCriteria}`] > b[`${sortingCriteria}`]);

    return tickets;
}


solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'destination');

console.log();

solve(['Philadelphia|94.20|available',
'New York City|95.99|available',
'New York City|95.99|sold',
'Boston|126.20|departed'],
'status');

console.log();

solve(['Philadelphia|94.20|available',
        'New York City|95.99|available',
        'New York City|95.99|sold',
        'Boston|126.20|departed'],
        'price');

