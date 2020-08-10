class VeterinaryClinic {
    constructor(clinicName, capacity) {
        this.clinicName = clinicName;
        this.capacity = capacity;

        this.clients = [];
        this.totalProfit = 0;
        this.currentWorkload;
    }

    newCustomer(ownerName, petName, kind, procedures) {
        const pet = {
            petName,
            kind,
            procedures
        };

        const customer = this.clients.find(c => c.ownerName === ownerName);
        let client = undefined;

        if (customer === undefined) {
            client = {
                ownerName,
                pets: []
            };
        } else {
            client = customer;
        }

        if (this.clients.length >= this.capacity) {
            throw new Error('Sorry, we are not able to accept more patients!');
        }

        if (customer !== undefined) {
            const pet = customer.pets.find(p => p.petName === petName && p.procedures.length > 0);
            if (pet !== undefined) {
                throw new Error(`This pet is already registered under ${ownerName} name! ${petName} is on our lists, waiting for ${pet.procedures.join(', ')}.`);
            }
        }

        client.pets.push(pet);

        client.pets.sort(function (a, b) {
            return a.petName.localeCompare(b.petName);
        });

        if (!this.clients.find(c => c.ownerName === ownerName)) {
            this.clients.push(client);
        }

        this.currentWorkload++;
        return `Welcome ${petName}!`;
    }

    onLeaving(ownerName, petName) {
        const client = this.clients.find(c => c.ownerName === ownerName);

        if (client === undefined) {
            throw new Error('Sorry, there is no such client!');
        }

        let customer = undefined;
        let pet = undefined;
        this.clients.forEach(c => {
            if (c.ownerName === ownerName) {
                const exactPet = c.pets.find(p => p.petName === petName);
                if (exactPet !== undefined) {
                    customer = c;
                    pet = exactPet;
                }
            }
        });

        if (customer === undefined || pet === undefined || pet.procedures.length === 0) {
            throw new Error(`Sorry, there are no procedures for ${petName}!`);
        }

        this.totalProfit += pet.procedures.length * 500;
        this.currentWorkload--;
        pet.procedures = [];

        return `Goodbye ${petName}. Stay safe!`;
    }

    toString() {
        let result = [];
        let percentage = 0;

        this.clients.forEach(c => {
            c.pets.forEach(p => {
                if (p.procedures.length > 0) {
                    percentage++;
                }
            });
        });

        percentage = Math.floor((percentage / this.capacity) * 100);
        result.push(`${this.clinicName} is ${percentage}% busy today!`);
        result.push(`Total profit: ${this.totalProfit.toFixed(2)}$`);

        this.clients.sort(function (a, b) {
            return a.ownerName.localeCompare(b.ownerName);
        });

        this.clients.forEach(c => {
            result.push(`${c.ownerName} with:`);
            c.pets.forEach(p => {
                result.push(`---${p.petName} - a ${p.kind.toLowerCase()} that needs: ${p.procedures.join(', ')}`);
            })
        });

        return result.join('\n');
    }
}



let clinic = new VeterinaryClinic('SoftCare', 10);
console.log(clinic.newCustomer('Jim Jones', 'Tom', 'Cat', ['A154B', '2C32B', '12CDB']));
console.log(clinic.newCustomer('Anna Morgan', 'Max', 'Dog', ['SK456', 'DFG45', 'KS456']));
console.log(clinic.newCustomer('Jim Jones', 'Tiny', 'Cat', ['A154B']));
console.log(clinic.onLeaving('Jim Jones', 'Tiny'));
console.log(clinic.toString());
clinic.newCustomer('Jim Jones', 'Sara', 'Dog', ['A154B']);
console.log(clinic.toString());

