'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const Fraction = require("./entities/Fraction");

class Exercise19 extends ExerciseBase {
    constructor() {
        super('q19')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        const sum = new Fraction(1, 1);
        let crrDenominator = 1;
        let fromNum = 1;

        function sFact(from, initNumber, toNumber) {
            let rval = from;
            for (let i = initNumber; i <= toNumber; i++)
                rval = rval * i;
            return rval;
        }

        for (let i = 1; i <= params.n; i++) {
            const to = (2 * i);
            crrDenominator = sFact(crrDenominator, fromNum, to);
            sum.plus(new Fraction((params.x * 2 * i), crrDenominator));
            fromNum = (to + 1);
        }
        console.log(`S(x,n) = ${sum.showFraction()}`);
    }
}

module.exports = (new Exercise19()).start();
