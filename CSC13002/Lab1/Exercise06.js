'use strict';
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
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += (1 / (i * (i + 1)));
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise06()).start();