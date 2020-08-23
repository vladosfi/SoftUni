const mathEnforcer = require('./app.js');
const expect = require('chai').expect;

describe('Math Enforcer', () => {
    describe('Check adding numbers', () => {
        it('shuld return undefined if parameter is not a number', () => {
            expect(mathEnforcer.addFive('4')).to.equal(undefined);
        });

        it('shuld return correct result if parameter is correct', () => {
            expect(mathEnforcer.addFive(2)).to.equal(7);
            expect(mathEnforcer.addFive(-2)).to.equal(3);
            expect(mathEnforcer.addFive(-2)).to.closeTo(3, 0.01);
            expect(mathEnforcer.addFive(10.001)).equal(15.001);
        });
    });

    describe('Check adding numbers', () => {
        it('shuld return undefined if parameter is not a number', () => {
            expect(mathEnforcer.subtractTen('4')).to.equal(undefined);
        });

        it('shuld return correct result if parameter is correct', () => {
            expect(mathEnforcer.subtractTen(10)).to.equal(0);
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
            expect(mathEnforcer.subtractTen(-10)).to.closeTo(-20, 0.01);
            expect(mathEnforcer.subtractTen(10.001)).equal(10.001-10);
        });
    });

    describe('Check sum numbers', () => {
        it('shuld return undefined if one of parameters is not a number', () => {
            expect(mathEnforcer.sum('4', 2)).to.equal(undefined);
            expect(mathEnforcer.sum(4, '2')).to.equal(undefined);
            expect(mathEnforcer.sum('4', '2')).to.equal(undefined);
        });

        it('shuld return correct result if parameter is correct', () => {
            expect(mathEnforcer.sum(10, 12)).to.equal(22);
            expect(mathEnforcer.sum(-10.33, -12)).to.equal(-22.33);
        });

        it('should return correct result for floating point parameters', function () {
            expect(mathEnforcer.sum(2.7, 3.4)).to.be.closeTo(6.1, 0.01);
        });
    });
});