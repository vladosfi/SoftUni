function findGcd(numberOne, NumberTwo) {
    const smallest = Math.min(numberOne, NumberTwo);
    let gcd = 1;
    for (let i = 2; i <= smallest; i++) {
        if (numberOne % i == 0 && NumberTwo % i == 0) {
            gcd = i;
        }
    }
    console.log(gcd);
}

findGcd(15, 5);
findGcd(2154, 458);

function findGcd2(numberOne, NumberTwo) {
    let small = Math.min(numberOne, NumberTwo);
    let large = Math.max(numberOne, NumberTwo);
    let reminder = 1;

    do {
        reminder = large % small;
        large = small;
        small = reminder;

    } while (reminder !== 0)

    console.log(large);
}

findGcd2(15, 5);
findGcd2(2154, 458);