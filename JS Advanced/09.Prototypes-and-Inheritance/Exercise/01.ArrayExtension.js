(function extendArray() {
    Array.prototype.last = function () {
        return this[this.length - 1];
    }

    Array.prototype.skip = function (n) {
        let result = [];
        for (let i = n; i < this.length; i++) {
            result.push(this[i]);
        }
        return result;
    }

    Array.prototype.take = function (n) {
        let result = [];

        for (let i = 0; i < n; i++) {
            result.push(this[i]);
        };

        return result
    }

    Array.prototype.sum = function () {
        let sum = 0;
        this.forEach(element => {
            sum += element;
        });

        return sum;
    }

    Array.prototype.average = function () {
        return this.sum() / this.length;
    }
}());

const arr = [1, 2, 3];

console.log(arr.last());
console.log(arr.skip(1));
console.log(arr.take(1));
console.log(arr.sum());
console.log(arr.average());