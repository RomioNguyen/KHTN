'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise05 extends ExerciseBase {
    constructor() {
        super('q5')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 1);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += (1 / (2 * i + 1));
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise05()).start();