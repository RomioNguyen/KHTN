'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const Fraction = require("./entities/Fraction");

class Exercise15 extends ExerciseBase {
    constructor() {
        super('q15')
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
                sum.setFraction(1, crrDenominator);
            } else {
                sum.plus(new Fraction(1, crrDenominator));
            }
        }
        console.log(`S(n) = ${sum.showFraction()}`);
    }
}

module.exports = (new Exercise15()).start();
