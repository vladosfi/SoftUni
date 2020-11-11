class Ticket {
    constructor(public destinationName: string, public price: number, public status: string) {
    }
}

class Tickets {
    tickets = [];
    sortingCriteria: string;

    constructor(ticketList, sortingCriteria: string) {
        ticketList.forEach(t => {
            let ticketDetails = t.split('|');
            let status: string = ticketDetails.pop();
            let price: number = ticketDetails.pop();
            let destinationName: string = ticketDetails.pop();
            this.tickets.push(new Ticket(destinationName, price, status));
        });

        if (sortingCriteria == 'price') {
            this.tickets.sort((a, b) => a.price > b.price ? -1 : a.price < b.price ? 1 : 0);
        } else if (sortingCriteria == 'status') {
            this.tickets.sort((a, b) => a.status.localeCompare(b.status));
        } else {
            this.tickets.sort((a, b) => a.destinationName.localeCompare(b.destinationName));
        }


        console.log(this.tickets);
    }
}

//let tickets = new Tickets(['Philadelphia|94.20|available', 'New York City|95.99|available', 'New York City|95.99|sold', 'Boston|126.20|departed'], 'destination');


let tickets2 = new Tickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
],
    'status');


    // let tickets3 = new Tickets([
    //     'Philadelphia|94.20|available',
    //      'New York City|95.99|available',
    //      'New York City|95.99|sold',
    //      'Boston|126.20|departed'
    //     ],
    //     'status');
