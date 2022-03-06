'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise07 extends ExerciseBase {
    constructor() {
        super('q7')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 0);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += (i / (i + 1));
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise07()).start();