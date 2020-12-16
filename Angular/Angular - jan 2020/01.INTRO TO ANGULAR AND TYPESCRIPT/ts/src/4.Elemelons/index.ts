abstract class Melon {
    public element: string;
    public weight: number;
    public melonSort: string;

    constructor(weight: number, melonSort: string) {
        this.weight = weight;
        this.melonSort = melonSort;
    }

    elementIndex(): number {
        return this.weight * this.melonSort.length;
    }

    toString(): string {
        const result = `Element: ${this.element} \r\nSort: ${this.melonSort}\r\nElement Index: ${this.elementIndex()}`;
        return result;
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

class Melolemonmelon extends Watermelon {
    elements = ['Water', 'Fire', 'Earth', 'Air'];

    constructor(weight: number, melonSort: string) {
        super(weight, melonSort);
        this.element = this.elements[0];
    }

    morph(): void {
        this.element = this.elements.shift();
        this.elements.push(this.element);
    }
}


//let test : Melon = new Melon(100, "Test");
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