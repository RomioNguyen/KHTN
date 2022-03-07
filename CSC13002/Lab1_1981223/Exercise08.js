'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const Fraction = require("./entities/Fraction");

class Exercise08 extends ExerciseBase {
    constructor() {
        super('q8')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 5);
    }

    answer(params) {
        const sum = new Fraction(1, 1);
        for (let i = 1; i <= params.n; i++) {
            if (i === 1) {
                sum.setFraction((2 * i + 1), (2 * i + 2));
            } else {
                sum.plus(new Fraction((2 * i + 1), (2 * i + 2)));
            }

        }
        console.log(`S(n) = ${sum.showFraction()}`);
    }
}

module.exports = (new Exercise08()).start();
