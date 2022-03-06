'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise20 extends ExerciseBase {
    constructor() {
        super('q20')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        let sum = 0;
        let crrDenominator = 1;
        let fromNum = 1;

        function sFact(from, initNumber, toNumber) {
            let rval = from;
            for (let i = initNumber; i <= toNumber; i++)
                rval = rval * i;
            return rval;
        }

        for (let i = 1; i <= params.n; i++) {
            const to = (2 ** (i - 1));
            crrDenominator = sFact(crrDenominator, fromNum, to);
            sum += ((params.x * i) / crrDenominator);
            fromNum = (to + 1);
        }
        console.log(`S(x, n) = ${sum}`);
    }
}

module.exports = (new Exercise20()).start();