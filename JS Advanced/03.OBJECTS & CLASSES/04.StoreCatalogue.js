function solve(input) {
    const catalogue = {};

    for (const line of input) {
        const [productName, productPrice] = line.split(' : ');
        const firstLetter = productName[0];

        if(catalogue.hasOwnProperty(firstLetter) === false){
            catalogue[firstLetter] = {};
        }

        catalogue[firstLetter][productName] = Number(productPrice);
    }

    const sortedKeys = Object.keys(catalogue).sort((a,b) => a.localeCompare(b));

    for (const key of sortedKeys) {
        console.log(`${key}`);
        
        const sortedProducts = Object.keys(catalogue[key]).sort((a,b) =>a.localeCompare(b));

        for (const product of sortedProducts) {
            console.log(`  ${product}: ${catalogue[key][product]}`);
        }
    }
}

solve(
    ['Appricot : 20.4',
        'Fridge : 1500',
        'TV : 1499',
        'Deodorant : 10',
        'Boiler : 300',
        'Apple : 1.25',
        'Anti-Bug Spray : 15',
        'T-Shirt : 10']
)