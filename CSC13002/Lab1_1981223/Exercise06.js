'use strict';
const Fraction = require('./entities/Fraction');
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise06 extends ExerciseBase {
    constructor() {
        super('q6')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 6);
    }

    answer(params) {
        const sum = new Fraction(1, 1);
        for (let i = 1; i <= params.n; i++) {
            if (i === 1) {
                sum.setFraction(1, (i * (i + 1)));
            } else {
                sum.plus(new Fraction(1, (i * (i + 1))));
            }

        }
        console.log(`S(n) = ${sum.showFraction()}`);
    }
}

module.exports = (new Exercise06()).start();
