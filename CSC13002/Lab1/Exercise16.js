'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise16 extends ExerciseBase {
    constructor() {
        super('q16')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        let sum = 0;
        let crrDenominator = 0;

        for (let i = 1; i <= params.n; i++) {
            crrDenominator += i
            sum += ((params.x * i) / crrDenominator)
        }
        console.log(`S(x, n) = ${sum}`);
    }
}

module.exports = (new Exercise16()).start();