'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise10 extends ExerciseBase {
    constructor() {
        super('q10')
    }

    validate(key, value) {
        if (validateUtils.isNumber(value))
            return true
        console.log(`${key} need a number`)
        return false;
    }

    answer(params) {
        console.log(`T(x, n) = ${(params.x ** params.n)}`);
    }
}

module.exports = (new Exercise10()).start();