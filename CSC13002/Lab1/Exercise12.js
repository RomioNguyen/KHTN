'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");

class Exercise11 extends ExerciseBase {
    constructor() {
        super('q11')
    }

    validate(key, value) {
        return validateUtils.isNumber(key, value);
    }

    answer(params) {
        let sum = 0;
        const findVolumeFrom1ToN = (n) => {
            let rsVolume = 1;
            for (let i = 1; i <= n; i++)
                rsVolume = rsVolume * i;
        }
        for (let i = 1; i <= params.n; i++)
            sum += findVolumeFrom1ToN(i)
        console.log(`S(n) = ${sum}`);
    }
}

module.exports = (new Exercise11()).start();