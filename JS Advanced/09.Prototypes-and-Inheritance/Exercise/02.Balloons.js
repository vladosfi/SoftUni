/* eslint-disable no-undef */
function solve() {
    class Balloon {
        constructor(color, gasWeight) {
            this.color = color;
            this.gasWeight = gasWeight;
        }
    }

    class PartyBalloon extends Balloon {
        constructor(color, gasWeight, ribbonColor, ribbonLength) {
            super(color, gasWeight);

            this._ribbon = {
                color: ribbonColor,
                length: ribbonLength
            };
        }

        get ribbon() {
            return this._ribbon;
        }
    }

    class BirthdayBalloon extends PartyBalloon {
        constructor(color, gasWeigth, ribbonColor, ribbonLength, text) {
            super(color, gasWeigth, ribbonColor, ribbonLength);
            this._text = text;
        }

        get text() {
            return this._text;
        }
    }


    return {
        Balloon,
        PartyBalloon,
        BirthdayBalloon
    };
}



const balloons = solve();

const a = new balloons.Balloon('green', 10);

console.log(a);

let test = new balloons.PartyBalloon('Tumno-bqlo', 20.5, 'Svetlo-cherno', 10.25);
console.log(test);