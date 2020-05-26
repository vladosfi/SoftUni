// function numbers(a) {
//     let sum = 0;
//     const firstDigit = a % 10;
//     let isSame = true;
//     let digit = 0;

//     while (a !== 0) {
//         sum += a % 10;
//         digit = a % 10;
//         a = Math.ceil(a / 10);
//         if (firstDigit !== digit) {
//             isSame = false;
//         }
//     }

//     console.log(isSame);
//     console.log(sum);
// }

// numbers(2222222);
// numbers(1234);


function numbers2(a) {
    const numAsText = a.toString();
    const firstChar = numAsText[0];
    let sum = 0;
    let isSame = true;

    for (let i = 0; i < numAsText.length; i++) {
        sum += Number(numAsText[i]);
        if (firstChar !== numAsText[i]) {
            isSame = false;
        }
    }

    console.log(isSame);
    console.log(sum);
}

numbers2(2222222);
numbers2(1234);