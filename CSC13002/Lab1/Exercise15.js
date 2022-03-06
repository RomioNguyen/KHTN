'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise15 extends ExerciseBase {
    constructor() {
        super('q15')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        let sum = 0;
        let crrDenominator = 0;

        for (let i = 1; i <= params.n; i++) {
            crrDenominator += i
            sum += (1 / crrDenominator)
        }
        console.log(`S(n)= ${sum}`);
    }
}

module.exports = (new Exercise15()).start();