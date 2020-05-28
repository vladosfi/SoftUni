function magicMatrices(arr) {
    const reducer =  (accumulator, currentValue) => accumulator + currentValue;
    arr.map(row => {
        arr[row].reduce(reducer)
    });

    console.log();
}

magicMatrices(
    [[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);

