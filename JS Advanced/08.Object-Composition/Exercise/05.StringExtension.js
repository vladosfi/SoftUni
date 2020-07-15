(function stringExtension() {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this;
        }

        return this.toString();
    };

    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str;
        }

        return this.toString();
    };

    String.prototype.isEmpty = function () {
        if (this.length === 0) {
            return true;
        }
        return false;
    };

    String.prototype.truncate = function (n) {
        if (n < 3) return '.'.repeat(n);
        if (n >= this.length) return this.toString();
        let spaceIndex = this.substring(0, n - 1).lastIndexOf(' ');
        if (spaceIndex >= 0) {
            return this.substring(0, spaceIndex) + '...';
        } else {
            return this.substring(0, n - 3) + '...';
        }
    };

    String.format = function (string, ...params) {
        params.forEach((el, i) => {
            string = string.replace(`{${i}}`, el);
        });

        return string;
    }
})();

let str = 'my string';
str = str.ensureStart('my');
console.log(str);
str = str.ensureStart('hello ');
console.log(str);
str = str.truncate(16);
console.log(str);
str = str.truncate(14);
console.log(str);
str = str.truncate(8);
console.log(str);
str = str.truncate(4);
console.log(str);
str = str.truncate(2);
console.log(str);
str = String.format('The {0} {1} fox', 'quick', 'brown');
console.log(str);
str = String.format('jumps {0} {1}', 'dog');
console.log(str);
