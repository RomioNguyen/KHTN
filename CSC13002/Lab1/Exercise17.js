'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise17 extends ExerciseBase {
    constructor() {
        super('q17')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        function sFact(num) {
            let rval = 1;
            for (let i = 2; i <= num; i++)
                rval = rval * i;
            return rval;
        }

        console.log(`S(n) = ${sFact(params.n)}`);
    }
}

module.exports = (new Exercise17()).start();