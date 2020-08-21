const isOddOrEven = require('./app.js');
const expect = require('chai').expect;

describe('Odd or Even', function () {
    it('should return even', function () {
        expect(isOddOrEven('aa')).to.equal('even');
    });

    it('should return odd', () => {
        expect(isOddOrEven('aaa')).to.equal('odd');
    });

    it('should return undefind with number parameter', function () {
        expect(isOddOrEven(1)).to.equal(undefined);
        expect(isOddOrEven([])).to.equal(undefined);
        expect(isOddOrEven({})).to.equal(undefined);
    });
});