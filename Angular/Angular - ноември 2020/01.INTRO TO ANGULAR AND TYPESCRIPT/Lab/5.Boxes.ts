class  Box<T> {
    private _elements = [];

    add(element: T){
        this._elements.push(element);
    }

    remove(){
        this._elements.pop();
    }

    get count(): number{
        return this._elements.length;
    }
}

let box = new Box<Number>();
box.add(1);
box.add(2);
box.add(3);
box.add(5);
console.log(box.count);
