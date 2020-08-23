const expect = require('chai').expect;
const Payment = require('./PaymentPackage.js');
const PaymentPackage = require('./PaymentPackage.js');

describe('Payment package', () => {
    const validName = 'My package';
    const validValue = 130;

    describe('Instantietion', () => {
        it('should work with valid partameters', () => {
            expect(() => new PaymentPackage(validName, validValue)).to.not.throw();
        });

        it('work correctly set up', () => {
            const instance = new PaymentPackage(validName,validValue);

            expect(instance.name).to.equal(validName);
            expect(instance.value).to.equal(validValue);
            expect(instance.VAT).to.equal(20);
            expect(instance.active).to.equal(true);
        });

        it('should not work with invalid name', () => {
            expect(() => new PaymentPackage('', validValue)).to.throw();
            expect(() => new PaymentPackage(undefined, validValue)).to.throw();
            expect(() => new PaymentPackage({}, validValue)).to.throw();
        });

        it('should work with invalid value', () => {
            expect(() => new PaymentPackage(validName, -5)).to.throw();
            expect(() => new PaymentPackage(validName, '')).to.throw();
            expect(() => new PaymentPackage(validName, {})).to.throw();
        });

        it('should have all properies', () => {
            const instance = new PaymentPackage(validName, validValue);

            expect(instance).to.have.property('name');
            expect(instance).to.have.property('value');
            expect(instance).to.have.property('VAT');
            expect(instance).to.have.property('active');
        });
    });

    describe('Accessors', () => {
        let instance = null;

        beforeEach(() => {
            instance = new PaymentPackage(validName, validValue);
        });

        it('accepts and sets valid name', () => {
            instance.name = 'New Pachage';
            expect(instance.name).to.equal('New Pachage');
        });

        it('rejects invalid name', () => {
            expect(() => instance.name = '').to.throw();
            expect(() => instance.name = undefined).to.throw();
            expect(() => instance.name = {}).to.throw();
        });

        it('accepts and sets valid value', () => {
            instance.value = 90;
            expect(instance.value).to.equal(90);
        });

        it('rejects invalid value', () => {
            expect(() => instance.value = '').to.throw();
            expect(() => instance.value = undefined).to.throw();
            expect(() => instance.value = -5).to.throw();
        });

        it('accepts and sets valid VAT', () => {
            instance.VAT = 33;
            expect(instance.VAT).to.equal(33);
        });

        it('rejects invalid VAT', () => {
            expect(() => instance.VAT = '').to.throw();
            expect(() => instance.VAT = undefined).to.throw();
            expect(() => instance.VAT = -3).to.throw();
        });

        it('accepts and sets valid active', () => {
            instance.active = true;
            expect(instance.active).to.be.true;

            instance.active = false;
            expect(instance.active).to.be.false;
        });

        it('rejects invalid active', () => {
            expect(() => instance.active = '').to.throw();
            expect(() => instance.active = undefined).to.throw();
            expect(() => instance.active = -3).to.throw();
        });
    });

    describe('String info', () => {
        let instance = null;

        beforeEach(() => {
            instance = new PaymentPackage(validName, validValue);
        });

        it('contains the name', () => {
            expect(instance.toString()).to.contain(validName);
        });

        it('contains the vlaue', () => {
            expect(instance.toString()).to.contain(validValue);
        });

        it('contains the VAT', () => {
            expect(instance.toString()).to.contain(instance.VAT + '%');
        });

        it('displays inactive label', () => {
            instance.active = false;
            expect(instance.toString()).to.contain('inactive');
        });

        it('updates info trough setters', () => {
            instance.name = 'New Package';
            instance.value = 90;
            instance.VAT = 9;

            const output = instance.toString();

            expect(output).to.contain('New Package');
            expect(output).to.contain('90');
            expect(output).to.contain('9%');
        });
    });
});
