var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (Object.prototype.hasOwnProperty.call(b, p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var Employee = /** @class */ (function () {
    function Employee(name, age) {
        this.name = name;
        this.age = age;
        this.salary = 0;
        this.tasks = [];
    }
    Employee.prototype.work = function () {
        var currentTask = this.tasks.shift();
        this.tasks.push(currentTask);
        console.log(currentTask);
    };
    Employee.prototype.collectSalary = function () {
        console.log(this.name + " received " + this.salary + " this month.");
    };
    Employee.prototype.getSalary = function () {
        return this.salary;
    };
    Employee.prototype.setSalary = function (salary) {
        this.salary = salary;
    };
    return Employee;
}());
var Junior = /** @class */ (function (_super) {
    __extends(Junior, _super);
    function Junior(name, age) {
        var _this = _super.call(this, name, age) || this;
        _this.tasks.push(_this.name + ' is working on a simple task.');
        return _this;
    }
    return Junior;
}(Employee));
var Senior = /** @class */ (function (_super) {
    __extends(Senior, _super);
    function Senior(name, age) {
        var _this = _super.call(this, name, age) || this;
        _this.tasks.push(_this.name + ' is working on a complicated task.');
        _this.tasks.push(_this.name + ' is taking time off work.');
        _this.tasks.push(_this.name + ' is supervising junior workers.');
        return _this;
    }
    return Senior;
}(Employee));
var Manager = /** @class */ (function (_super) {
    __extends(Manager, _super);
    function Manager(name, age) {
        var _this = _super.call(this, name, age) || this;
        _this.divident = 0;
        _this.tasks.push(_this.name + ' scheduled a meeting.');
        _this.tasks.push(_this.name + ' is preparing a quarterly report.');
        return _this;
    }
    Manager.prototype.collectSalary = function () {
        console.log(this.name + " received " + (this.salary + this.divident) + " this month.");
    };
    return Manager;
}(Employee));
var managet = new Manager('jovan', 30);
managet.work();
managet.work();
managet.salary = 111;
//managet.devidend = 111;
console.log(managet.getSalary());
