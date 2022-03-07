'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const input = require("./utils/input");

class Answer25 {
    constructor(number) {
        this.dic = [];
        this.rs = [];
        this.count = number
        this.iMid = [];
        // lấy nguyên
        const c = (number - number % 2) / 2;
        if (number % 2 == 0) {
            this.iMid.push(c - 1);
        }
        this.iMid.push(c)
    }

    validateInput(key, value) {
        return validateUtils.numBigger(value, 0)
    }

    async askInputDic(key, content, addRs = false) {
        const n = await new Promise(resolve => {
            input.question(content, resolve)
        })
        if (this.validateInput(key, n)) {
            this.dic.push(n);
            addRs && this.rs.push(n);
        } else {
            await this.askInputDic(key, content, addRs);
        }
    }

    async answer() {
        for (let i = 0; i < this.count; i++) {
            await this.askInputDic(i, `Nhap phan tu thu ${(i + 1)}: `, this.iMid.indexOf(i) > -1);
        }
        console.log(this.dic)
        console.log(this.rs)
    }
}

class Exercise25 extends ExerciseBase {
    constructor() {
        super('q25')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 0);
    }

    answer(params) {
        (new Answer25(params.n)).answer();
    }
}

module.exports = (new Exercise25()).start();