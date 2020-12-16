abstract class Employee {
    public name: string;
    public age: number;
    public salary: number;
    public tasks: Array<string>;

    constructor(name: string, age: number) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }

    work(): void {
        const currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(currentTask);
    }
    collectSalary(): void {
        console.log(`${this.name} received ${this.salary} this month.`);
    }

    getSalary(): number {
        return this.salary;
    }

    setSalary(salary: number): void {
        this.salary = salary;
    }
}


class Junior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks.push(this.name + ' is working on a simple task.');
    }
}

class Senior extends Employee {
    constructor(name: string, age: number) {
        super(name, age);
        this.tasks.push(this.name + ' is working on a complicated task.')
        this.tasks.push(this.name + ' is taking time off work.')
        this.tasks.push(this.name + ' is supervising junior workers.')
    }
}

class Manager extends Employee {
    divident: number;

    constructor(name: string, age: number) {
        super(name, age);
        this.divident = 0;
        this.tasks.push(this.name + ' scheduled a meeting.')
        this.tasks.push(this.name + ' is preparing a quarterly report.')
    }

    collectSalary(): void {
        console.log(`${this.name} received ${this.salary + this.divident} this month.`)
    }
}


var managet = new Manager('jovan', 30);
managet.work();
managet.work();
managet.salary = 111;
//managet.devidend = 111;
console.log(managet.getSalary());