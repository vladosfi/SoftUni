function filterElements(params) {
    const step = Number(params.pop());
    return params.filter((el, i) => i % step === 0).join('\n');
}

console.log(filterElements(['dsa', 'asd', 'test', 'tset', '2']));
console.log(filterElements(['5', '20', '31', '4', '20', '2']));
console.log(filterElements(['1', '2', '3', '4', '5', '6']));

// function filterElements(params) {
//     const step = Number(params.pop());
    
//     for (let i = 0; i < params.length; i += step){
//         console.log(params[i]);
//     }
// }

// filterElements(['1', '2', '3', '4', '5', '6']);


