function solve(input) {
    const cars = {};

    for (const car of input) {
        const [carBrand, carModel, producedCars] = car.split(' | ');

        if (cars.hasOwnProperty(carBrand) === false) {
            cars[carBrand] = {};
        }

        if (cars[carBrand].hasOwnProperty(carModel) === false) {
            cars[carBrand][carModel] = 0;
        }

        cars[carBrand][carModel] = cars[carBrand][carModel] + Number(producedCars);
    }

    const carBrands = Object.keys(cars);

    for (const brand of carBrands) {
        console.log(brand);

        const models = Object.keys(cars[brand]);

        for (const model of models) {
            console.log(`###${model} -> ${cars[brand][model]}`);
        }
    }
}

solve(['Audi | Q7 | 1000',
    'Audi | Q6 | 100',
    'BMW | X5 | 1000',
    'BMW | X6 | 100',
    'Citroen | C4 | 123',
    'Volga | GAZ-24 | 1000000',
    'Lada | Niva | 1000000',
    'Lada | Jigula | 1000000',
    'Citroen | C4 | 22',
    'Citroen | C5 | 10']
)