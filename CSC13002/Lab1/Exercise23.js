'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const input = require("./utils/input");

class Answer23 {
    constructor(number) {
        this.dic = [];
        this.count = number;
        this.best = Number.MAX_SAFE_INTEGER;
    }

    findSubArrayMinWithIndices() {
        this.best = Number.MAX_SAFE_INTEGER;
        let sum = 0;
        let arrRs = [...this.dic];
        let index_start = 0, index_end = 0, current_start = 0;
        for (let i = 0; i < this.count; i++) {
            if (sum + this.dic[i] > this.dic[i]) {
                current_start = i;
                sum = this.dic[i];
            } else {
                sum += this.dic[i];
            }

            if (this.best > sum) {
                this.best = sum;
                index_start = current_start;
                index_end = i;
            }
        }
        const rs = arrRs.splice(index_start, (index_end - index_start + 1));
        console.log('Tong: ', this.best);
        console.log('Mang: ', rs);
    }

    validateInput(value, key) {
        return validateUtils.isNumber(value, `Phan tu tai ${key}`)
    }

    async askInputDic(key, content) {
        const n = await new Promise(resolve => {
            input.question(content, resolve)
        })
        if (this.validateInput(n, key)) {
            this.dic.push(parseInt(n));
        } else {
            await this.askInputDic(key, content);
        }
    }


    async answer() {
        for (let i = 0; i < this.count; i++) {
            await this.askInputDic(i, `Nhap phan tu thu ${(i + 1)}: `);
        }
        this.findSubArrayMinWithIndices();

    }
}

class Exercise23 extends ExerciseBase {
    constructor() {
        super('q23')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 0);
    }

    async answer(params) {
        (new Answer23(params.n)).answer();
    }
}

module.exports = (new Exercise23()).start();
