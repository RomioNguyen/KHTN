'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise02 extends ExerciseBase {
    constructor() {
        super('q2')
    }

    validate(key,value) {
        return validateUtils.numBetween(value, 4, 21);
    }

    answer(params) {
        let sum = 0;
        for (let i = 1; i <= params.n; i++)
            sum += Math.sqrt(i);
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise02()).start();