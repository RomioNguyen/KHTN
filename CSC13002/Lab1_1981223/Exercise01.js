'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise01 extends ExerciseBase {
    constructor() {
        super('q1')
    }

    validate(key, value) {
        return validateUtils.numBetween(value, 3, 50);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += i;
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise01()).start();