function getFibonator() {
    let current = 1;
    let previous = 0;


    function fibonator() {
        let fibNum = current + previous;
        previous = current;
        current = fibNum;
        return previous;
    };
    
    return fibonator;
}

let fib = getFibonator();
console.log(fib()); // 1
console.log(fib()); // 1
console.log(fib()); // 2
console.log(fib()); // 3
console.log(fib()); // 5
console.log(fib()); // 8
console.log(fib()); // 13
