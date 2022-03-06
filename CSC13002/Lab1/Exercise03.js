'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise03 extends ExerciseBase {
    constructor() {
        super('q3')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 6);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += (1 / i);
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise03()).start();