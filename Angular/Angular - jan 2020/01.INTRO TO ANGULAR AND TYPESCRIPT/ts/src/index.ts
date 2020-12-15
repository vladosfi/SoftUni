class User{
    private  name: string;

    constructor(name: string){
        this.name = name;
    }

    sayHello(){
        return `${this.name} says hi!`;
    }
}

const user = new User('Iovan');
console.log(user.sayHello());