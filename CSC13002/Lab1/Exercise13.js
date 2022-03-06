'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise12 extends ExerciseBase {
    constructor() {
        super('q12')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += (params.x ** i)
        console.log(`T(x, n) = ${sum}`);
    }
}

module.exports = (new Exercise12()).start();