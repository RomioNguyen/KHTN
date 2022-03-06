'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise08 extends ExerciseBase {
    constructor() {
        super('q8')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 5);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += (2 * i + 1) / (2 * i + 2);
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise08()).start();