'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise04 extends ExerciseBase {
    constructor() {
        super('q4')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 9);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += (1 / (2 * i));
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise04()).start();