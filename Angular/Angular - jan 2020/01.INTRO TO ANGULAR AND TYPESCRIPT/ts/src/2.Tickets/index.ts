class Ticket {
    destination: string;
    price: number;
    status: string;

    constructor(destination: string, price: number, status: string) {
        this.destination = destination;
        this.price = price;
        this.status = status;
    }
}


// class Tickets {
//     private ticketArray: Array<Ticket> = [];
//     private sortingCriteria: string;

//     constructor(ticketRows: Array<string>, sortingCriteria: string) {

//         this.sortingCriteria = sortingCriteria;
//         ticketRows.forEach(t => {
//             const singleTicket = t.split('|');
//             this.ticketArray.push(new Ticket(singleTicket[0], Number(singleTicket[1]), singleTicket[2]));
//         })

//         if (this.sortingCriteria == 'price') {
//             this.ticketArray.sort((a, b) => a.price > b.price ? -1 : a.price < b.price ? 1 : 0);
//         } else if (this.sortingCriteria == 'status') {
//             this.ticketArray.sort((a, b) => a.status.localeCompare(b.status));
//         } else if (this.sortingCriteria == 'destination') {
//             this.ticketArray.sort((a, b) => a.destination.localeCompare(b.destination));
//         }

//         // console.log(this.ticketArray);
//     }
// }


function PrintTickets(ticketRows: Array<string>, sortingCriteria: string) {
    let ticketArray: Array<Ticket> = [];

    ticketRows.forEach(t => {
        const singleTicket = t.split('|');
        ticketArray.push(new Ticket(singleTicket[0], Number(singleTicket[1]), singleTicket[2]));
    })

    if (sortingCriteria == 'price') {
        ticketArray.sort((a, b) => a.price > b.price ? -1 : a.price < b.price ? 1 : 0);
    } else if (sortingCriteria == 'status') {
        ticketArray.sort((a, b) => a.status.localeCompare(b.status));
    } else if (sortingCriteria == 'destination') {
        ticketArray.sort((a, b) => a.destination.localeCompare(b.destination));
    }

    return ticketArray;
}


console.log(PrintTickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
],
    'status'
));

// console.log(new Tickets([
//     'Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'
// ],
//     'destination'));


// console.log(new Tickets([
//     'Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'
// ],
//     'status'
// ));

// console.log(new Tickets([
//     'Philadelphia|94.20|available',
//     'New York City|95.99|available',
//     'New York City|95.99|sold',
//     'Boston|126.20|departed'
// ],
//     'price'));

