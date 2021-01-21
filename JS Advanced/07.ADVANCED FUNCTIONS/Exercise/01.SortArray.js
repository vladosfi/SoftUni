function solve(arr, sortType) {
    sortedArr = arr.slice();

    if (sortType === 'asc') {
        sortedArr.sort((a, b) => (a - b));
    } else {
        sortedArr.sort((a, b) => (b - a));
    }

    return sortedArr;
}

console.log(solve([14, 7, 17, 6, 8], 'asc'));