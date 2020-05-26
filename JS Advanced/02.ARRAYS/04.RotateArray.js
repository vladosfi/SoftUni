function rotate(arr) {
    const rotations = Number(arr.pop());

    for (let index = 0; index < rotations; index++) {
        arr.unshift(arr.pop());
    }
    return arr.join(' ');
}

console.log(rotate(['1', '2', '3', '4', '2']));
console.log(rotate(	['Banana', 'Orange', 'Coconut', 'Apple', '15']));