'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise18 extends ExerciseBase {
    constructor() {
        super('q18')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        let sum = 0;
        let crrDenominator = 1;

        for (let i = 1; i <= params.n; i++) {
            crrDenominator = crrDenominator * i;
            sum += ((params.x * i) / crrDenominator)
        }
        console.log(`S(x, n) = ${sum}`);
    }
}

module.exports = (new Exercise18()).start();