"use strict";

// function magicMatrices(arr) {
//     const reducer =  (accumulator, currentValue) => accumulator + currentValue;
//     arr.map(row => {
//         arr[row].reduce(reducer)
//     });

//     console.log();
// }

isMagicMatrices(
    [[4, 5, 6],
    [6, 5, 4],
    [5, 5, 5]]
);

isMagicMatrices(
    [[11, 32, 45],
    [21, 0, 1],
    [21, 1, 1]]
);

isMagicMatrices(
    [[1, 0, 0],
    [0, 0, 1],
    [0, 1, 0]]
);

function isMagicMatrices(matrix) {
    let isMagicMatrix = true;
    const sum = matrix[0].reduce((acc, element) => acc += Number(element), 0);
	
    const array1 = [0, 0, 0];

    matrix.reduce((acc1, row, index) => {
        row.reduce((acc, element, indexCol) => acc += element, 0) === sum ? arrayRow[indexCol] += element : isMagicMatrix = false;
    });

    const arrayRow = new Array(matrix.length).fill(0);

    matrix.reduce((acc, row) => {
        let arrayColSum = 0;
        row.reduce((acc, element, indexCol) => {
            arrayColSum += Number(element);
            arrayRow[indexCol] += Number(element);
        }, 0);
        if (arrayColSum !== sum) {
            isMagicMatrix = false;
        }
    }, 0);

    arrayRow.reduce((acc, element) => {
        if (element !== sum) {
            isMagicMatrix = false;
        }
    }, 0);
    
    console.log(isMagicMatrix);
}



