var Ticket = /** @class */ (function () {
    function Ticket(destinationName, price, status) {
        this.destinationName = destinationName;
        this.price = price;
        this.status = status;
    }
    return Ticket;
}());
var Tickets = /** @class */ (function () {
    function Tickets(ticketList, sortingCriteria) {
        var _this = this;
        this.tickets = [];
        ticketList.forEach(function (t) {
            var ticketDetails = t.split('|');
            var status = ticketDetails.pop();
            var price = ticketDetails.pop();
            var destinationName = ticketDetails.pop();
            _this.tickets.push(new Ticket(destinationName, price, status));
        });
        if (sortingCriteria == 'price') {
            this.tickets.sort(function (a, b) { return a.price > b.price ? -1 : a.price < b.price ? 1 : 0; });
        }
        else if (sortingCriteria == 'status') {
            this.tickets.sort(function (a, b) { return a.status.localeCompare(b.status); });
        }
        else {
            this.tickets.sort(function (a, b) { return a.destinationName.localeCompare(b.destinationName); });
        }
        console.log(this.tickets);
    }
    return Tickets;
}());
//let tickets = new Tickets(['Philadelphia|94.20|available', 'New York City|95.99|available', 'New York City|95.99|sold', 'Boston|126.20|departed'], 'destination');
var tickets2 = new Tickets([
    'Philadelphia|94.20|available',
    'New York City|95.99|available',
    'New York City|95.99|sold',
    'Boston|126.20|departed'
], 'status');
// let tickets3 = new Tickets([
//     'Philadelphia|94.20|available',
//      'New York City|95.99|available',
//      'New York City|95.99|sold',
//      'Boston|126.20|departed'
//     ],
//     'status');
