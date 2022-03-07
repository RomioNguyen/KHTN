'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise14 extends ExerciseBase {
    constructor() {
        super('q14')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += (params.x ** (2 * i + 1))
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise14()).start();