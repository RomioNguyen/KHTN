'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise09 extends ExerciseBase {
    constructor() {
        super('q9')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 6);
    }

    answer(params) {
        let rs = 1;
        for (let i = 1; i <= params.n; i++)
            rs = rs * i;
        console.log(`S(n) = ${rs}`);
    }
}

module.exports = (new Exercise09()).start();