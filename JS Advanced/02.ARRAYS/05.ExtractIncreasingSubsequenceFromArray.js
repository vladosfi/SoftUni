function increasingSubsequence(array) {
    const result = [];
    result.push(array.shift());
    let currentBiggestOne = result[0];

    for (let i = 0; i < array.length; i++) {
        if (array[i] >= currentBiggestOne ) {
            currentBiggestOne = array[i];
            result.push(currentBiggestOne);
        }
    }
    console.log(result.join('\n'));
}

increasingSubsequence([1, 3, 8, 4, 10, 12, 3, 2, 24]);
increasingSubsequence([1, 2, 3, 4]);
increasingSubsequence([20, 3, 2, 15, 6, 1]);