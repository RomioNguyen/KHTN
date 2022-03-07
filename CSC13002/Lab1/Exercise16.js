'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const Fraction = require("./entities/Fraction");

class Exercise16 extends ExerciseBase {
    constructor() {
        super('q16')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        let crrDenominator = 0;
        const sum = new Fraction(1, 1);
        for (let i = 1; i <= params.n; i++) {
            crrDenominator += i
            if (i === 1) {
                sum.setFraction((params.x * i), crrDenominator);
            } else {
                sum.plus(new Fraction((params.x * i), crrDenominator));
            }
        }
        console.log(`S(x,n) = ${sum.showFraction()}`);
    }
}

module.exports = (new Exercise16()).start();
