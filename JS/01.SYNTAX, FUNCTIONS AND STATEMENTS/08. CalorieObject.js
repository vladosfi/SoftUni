function calorie(params) {
    let calories = {};
    for (let i = 0; i < params.length; i += 2) {
        const propName = params[i];
        const val = Number(params[i + 1]);
        calories[propName] = val;
    }

    console.log(calories);
}

calorie(['Yoghurt', '48', 'Rise', '138', 'Apple', '52']);