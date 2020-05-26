// function print(params) {
//     const demilimeter = params[params.length - 1];
//     const arr = [];

//     for (let i = 0; i < params.length-1; i++) {
//         arr.push(params[i])
//     }

//     console.log(arr.join(params[Number(params.length-1)]));
// }

function print(params) {
    const demilimeter = params.pop();
    console.log(params.join(demilimeter));
} 

print(['One', 'Two', 'Three', 'Four', 'Five', '-']);
print(['How about no?', 'I', 'will', 'not', 'do', 'it!', '_']);