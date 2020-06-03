"use strict";

function solve(tickets, criteria) {
    tickets.map(t => new Ticket(t)).sort(COMPARATOR[criteria]);

    const comparator = {
        destination: () = {},
        price: () = {},
        status: () = {}
    }
    
    class Ticket {
        constructor(descriptor) {
            const [destinationName, price, status] = descriptor.split('|');
            this.destinationName = destinationName;
            this.price = price;
            this.status = status;
        }
    }
}


solve(['Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'],
    'destination'
)