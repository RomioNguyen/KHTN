'use strict';
const Fraction = require('./entities/Fraction');
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise05 extends ExerciseBase {
    constructor() {
        super('q5')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 1);
    }

    answer(params) {
        const sum = new Fraction(1, 1);
        for (let i = 1; i <= params.n; i++) {
            if (i === 1) {
                sum.setFraction(1, (2 * i + 1));
            } else {
                sum.plus(new Fraction(1,(2 * i + 1)));
            }
        }
        console.log(`S(n) = ${sum.showFraction()}`);
    }
}

module.exports = (new Exercise05()).start();
