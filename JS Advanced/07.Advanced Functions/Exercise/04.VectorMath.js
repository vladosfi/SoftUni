function solve() {
    return {
        add: (a, b) => {
            return [a[0] + b[0], a[1] + b[1]];
        },
        multiply: (a, s) => {
            return [a[0] * s, a[1] * s];
        },
        length: (a) => {
            return Math.sqrt(Math.pow(a[0], 2) + Math.pow(a[1], 2));
        },
        dot: (a, b) => {
            return a[0] * a[1] + b[0] * b[1];
        },
        cross: (a, b) => {
            return a[0] * b[1] - a[1] * b[0];
        },
    }
}

const vectorMath = solve();
console.log(vectorMath.add([3, 1], [-4, 3]));
console.log(vectorMath.multiply([3.5, -2], 2));
console.log(vectorMath.length([3, -4]));
console.log(vectorMath.dot([1, 0], [0, -1]));
console.log(vectorMath.cross([3, 7], [1, 0]));