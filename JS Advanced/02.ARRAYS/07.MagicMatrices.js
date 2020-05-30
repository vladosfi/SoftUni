"use strict";

// function magicMatrices(arr) {
//     const reducer =  (accumulator, currentValue) => accumulator + currentValue;
//     arr.map(row => {
//         arr[row].reduce(reducer)
//     });

//     console.log();
// }

const magicMatrices = (
    [[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);

isMagicMatrices(magicMatrices);

function isMagicMatrices(matrix) {
    let isMagicMatrix = true;
    const sum = matrix[0].reduce((acc, element) => acc += element, 0);

    const array1 = [0, 0, 0];

    matrix.reduce((acc1, row, index) => {
        row.reduce((acc, element, indexCol) => acc += element, 0) === sum ? arrayRow[indexCol] += element : isMagicMatrix = false;
    });

    // matrix.forEach(row => {
    //     row.reduce((acc, element) => acc += element) === sum ? true : isMagicMatrix = false;
    // });

    console.log(isMagicMatrix);
}



