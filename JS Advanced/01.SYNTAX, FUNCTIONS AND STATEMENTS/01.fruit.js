function fruit(fruitName, weightInGrams, pricePerKg){
    const weightInKg = weightInGrams / 1000;
    const money = weightInKg * pricePerKg;
    //console.log('I need $' + (money).toFixed(2) + ' to buy ' + (weightInKg).toFixed(2) + ' kilograms ' + fruitName + '.');
    console.log(`I need $${money.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms fruitName.`);
}
fruit('banana',200,2);  