abstract class Melon {
    element: string;
    elementIndex: number;

    constructor(public weight: number, public melonSort: string) {
        this.elementIndex = weight * melonSort.length;
    }

    getElementIndex() {
        return this.elementIndex;
    }

    toString() {
        const elemetInfo = [];
        elemetInfo.push(`Element: ${this.element}`);
        elemetInfo.push(`Sort: ${this.melonSort}`);
        elemetInfo.push(`Element Index: ${this.getElementIndex()}`);
        return elemetInfo.join('\n');
    }
}

class Watermelon extends Melon {
    element = 'Water';

    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }
}

class Firemelon extends Melon {
    element = 'Fire';
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }
}


class Earthmelon extends Melon {
    element = 'Earth';
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }
}

class Airmelon extends Melon {
    element = 'Air';
    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }
}

class Melolemonmelon extends Airmelon {
    elements: Array<string> = ['Water', 'Fire', 'Earth', 'Air'];

    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
    }

    morph(): void { 
        this.element = this.elements.shift();
        this.elements.push(this.element);
    }    
}



//let test: Melon = new Melon(100, "Test");
//Throws error

let watermelon: Watermelon = new Watermelon(12.5, "Kingsize");
console.log(watermelon.toString());

// Element: Water
// Sort: Kingsize
// Element Index: 100


let melolemonmelon: Melolemonmelon = new Melolemonmelon(12.5, "Kingsize");
melolemonmelon.morph();
melolemonmelon.morph();
console.log(melolemonmelon.toString());