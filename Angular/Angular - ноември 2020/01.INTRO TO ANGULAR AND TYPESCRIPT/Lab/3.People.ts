class Employee {
    public name: string;
    public age: number;
    public salary: number;
    public tasks: Array<string>;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = []
    }

    work(): void {
        const currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(this.name + currentTask);
    }

    collectSalary(): void {
        console.log(`${this.name} received ${this.getSalary()} this month`)
    }

    getSalary(): number {
        return this.salary;
    }
}

class Junior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks.push(` is working on a single task.`);
    }
}

class Sinior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);

        this.tasks.push(` is working on a complicated task.`);
        this.tasks.push(` is taking time off work.`);
        this.tasks.push(` is supervising junior workers.`);
    }
}


class Manager extends Employee {
    devidend: number;

    constructor(name: string, age: number, devident: number) {
        super(name, age);

        this.devidend = devident;
        this.tasks.push(` scheduled a meeting.`);
        this.tasks.push(` is preparing a quarterly report.`);
    }

    getSalary(): number {
        return this.salary + this.devidend;
    }
}

var managet = new Manager('jovan', 30, 12);
managet.work();
managet.work();
managet.work();
managet.work();
managet.salary = 111;
managet.devidend = 111;
console.log(managet.getSalary());