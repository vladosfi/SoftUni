"use strict";

function cappyJuice(input) {
    const juiceQantity = new Map();
    const bottles = new Map();

    for (let line of input) {
        const current = line.split(' => ');
        const key = current[0];
        let val = Number(current[1]);

        if (!juiceQantity.has(key)) { 
            juiceQantity.set(key, 0);
        }

        val = val + juiceQantity.get(key);

        if (val >= 1000) {
            let juiceLeft = val % 1000;
            const bottlesCount = Math.floor(val / 1000);

            if (!bottles.has(key)) { bottles.set(key, 0) };

            bottles.set(key, bottles.get(key) + bottlesCount);
            val = juiceLeft;
        }

        juiceQantity.set(key, juiceQantity.get(key) + val);
    }

    bottles.forEach((val, key) => {
        console.log(`${key} => ${val}`);
    })
}

cappyJuice([
    'Orange => 2000',
    'Peach => 1432',
    'Banana => 450',
    'Peach => 600',
    'Strawberry => 549'
]);


cappyJuice([
    'Kiwi => 234',
    'Pear => 2345',
    'Watermelon => 3456',
    'Kiwi => 4567',
    'Pear => 5678',
    'Watermelon => 6789'
]);
