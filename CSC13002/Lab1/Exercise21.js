'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const Matrix = require("./entities/Matrix");
const input = require("./utils/input");

class Exercise21 extends ExerciseBase {
    constructor() {
        super('q21')
    }

    validate(key, value) {
        return validateUtils.isNumber(value, key);
    }

    async answer(params) {
        const matrix = (new Matrix(params.n, params.m));
        await matrix.inputMatrix();
        matrix.showMatrix();

        const askFindNumber = async () => {
            const n = await new Promise(resolve => {
                input.question('Nhap so can tim: ', resolve)
            })
            if (validateUtils.isNumber(n, 'So nhap')) {
                return n;
            }
            return await askFindNumber();
        }

        const numberNeedFind = await askFindNumber();
        const pos = matrix.find(parseInt(numberNeedFind));
        console.log(`${numberNeedFind} can tim o vi tri ${pos}`);
        console.log(`Gia tri nho nhat: ${matrix.min}`);
        console.log(`Gia tri lon nhat: ${matrix.max}`);
    }
}

module.exports = (new Exercise21()).start();