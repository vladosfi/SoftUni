function solve() {
    const juniorTasks = [
        ' is working on a simple task.'
    ];

    const seniorTasks = [
        ' is working on a complicated task.',
        ' is taking time off work.',
        ' is supervising junior workers.'
    ];

    const managerTasks = [
        ' scheduled a meeting.',
        ' is preparing a quarterly report.'
    ];

    class Employee {
        constructor(name, age) {
            this.name = name;
            this.age = age;
            this.salary = 0;
            this.tasks = [];
        }

        work() {
            const currentTask = this.tasks.shift();
            console.log(this.name + currentTask);
            this.tasks.push(currentTask);
         }

        collectSalary() { 
            console.log(`${this.name} received ${this.salary} this month.`);
        }
    }

    class Junior extends Employee {
        constructor(name, age) {
            super(name, age);

            juniorTasks.forEach(t => this.tasks.push(t));
        }
    }

    class Senior extends Employee {
        constructor(name, age) {
            super(name, age);

            seniorTasks.forEach(t => this.tasks.push(t));
        }
    }

    class Manager extends Employee {
        constructor(name, age) {
            super(name, age);
            this.dividend = 0;

            managerTasks.forEach(t => this.tasks.push(t));
        }

        collectSalary() { 
            console.log(`${this.name} received ${this.salary + this.divident} this month.`);
        }
    }

    return {
        Junior,
        Senior,
        Manager
    };
}

const people = solve();

const a = new people.Junior('Gerge', 25);
a.work();

const b = new people.Senior('Peter', 21);
b.work();

const c = new people.Manager('Man', 30);
c.work();
c.collectSalary();

console.log(a.hasOwnProperty('salary'));
console.log(b.hasOwnProperty('salary'));
console.log(c.hasOwnProperty('salary'));
console.log(c.hasOwnProperty('dividend'));