function solveClasses() {
    class Pet {
        constructor(owner, name) {
            this.owner = owner;
            this.name = name;
            this.comments = [];
        }


        addComment(comment) {
            const isCommentUnique = this.comments.indexOf(comment);

            if (isCommentUnique !== -1) {
                return 'This comment is already added!';
            }

            this.comments.push(comment);
            return 'Comment is added.';
        }

        feed() {
            return this.name + ' is fed';
        }

        toString() {
            let result = `Here is ${this.owner}\'s pet ${this.name}.`;

            if (this.comments.length > 0) {
                result += '\nSpecial requirements: ';
                result += this.comments.join(', ');
            }

            return result;
        }
    }

    class Cat extends Pet {
        constructor(owner, name, insideHabits, scratching) {
            super(owner, name);
            this.insideHabits = insideHabits;
            this.scratching = scratching;
        }

        feed() {
            return super.feed() + ', happy and purring.';
        }

        toString() {
            let result = [];
            result.push(super.toString());
            result.push('Main information:');
            let mainInfoDetails = `${this.name} is a cat with ${this.insideHabits}`;

            if (this.scratching) {
                mainInfoDetails += ', but beware of scratches.';
            }
            result.push(mainInfoDetails);

            return result.join('\n');
        }
    }

    class Dog extends Pet {
        constructor(owner, name, runningNeeds, trainability) {
            super(owner, name);
            this.runningNeeds = runningNeeds;
            this.trainability = trainability;
        }

        feed() {
            return super.feed() + ', happy and wagging tail.';
        }

        toString() {
            const result = [];
            result.push(super.toString());
            result.push('Main information:');
            result.push(`${this.name} is a dog with need of ${this.runningNeeds}km running every day and ${this.trainability} trainability.`);

            return result.join('\n');
        }
    }

    return {
        Pet,
        Cat,
        Dog
    }
}

let classes = solveClasses();
let pet = new classes.Pet('Ann', 'Merry');
console.log(pet.addComment('likes bananas'));
console.log(pet.addComment('likes sweets'));
console.log(pet.feed());
console.log(pet.toString());

let cat = new classes.Cat('Jim', 'Sherry', 'very good habits', true);
console.log(cat.addComment('likes to be brushed'));
console.log(cat.addComment('sleeps a lot'));
console.log(cat.feed());
console.log(cat.toString());

let dog = new classes.Dog('Susan', 'Max', 5, 'good');
console.log(dog.addComment('likes to be brushed'));
console.log(dog.addComment('sleeps a lot'));
console.log(dog.feed());
console.log(dog.toString());



// Unexpected error: expected 'Here is Jim\'s pet Sherry.\nSpecial requirements: likes to be brushed, sleeps a lot, happy and purring.' 
//                   to equal 'Sherry is fed, happy and purring.'