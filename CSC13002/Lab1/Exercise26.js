'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const input = require("./utils/input");

class Answer26 {
    constructor(number) {
        this.dic = [];
        this.rs = [];
        this.count = number
    }


    validateInput(key, value) {
        return validateUtils.isNumber(value, `Input a ${key}`)
    }

    handleAddRs(num) {
        const index = this.rs.indexOf(num);
        if (index === -1) {
            this.rs.push(num);
        } else {
            this.rs.splice(index, 1);
        }
    }

    async askInputDic(key, content) {
        const n = await new Promise(resolve => {
            input.question(content, resolve)
        })
        if (this.validateInput(key, n)) {
            this.dic.push(n);
            this.handleAddRs(n);
        } else {
            await this.askInputDic(key, content);
        }
    }

    async answer() {
        for (let i = 0; i < this.count; i++) {
            await this.askInputDic(i, `Nhap phan tu thu ${(i + 1)}: `);
        }
        console.log(this.dic)
        console.log(this.rs)
    }
}

class Exercise26 extends ExerciseBase {
    constructor() {
        super('q26')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 0);
    }

    answer(params) {
        (new Answer26(params.n)).answer();
    }
}

module.exports = (new Exercise26()).start();