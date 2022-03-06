'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const input = require("./utils/input");

class Answer29 {
    constructor(number) {
        this.dic = [];
        this.maxLength = 0;
        this.arrMaxLength = [];
        this.countStr = number
    }


    validateStr(value) {
        return (value && value.trim() !== '');
    }

    findMaxLength(str) {
        if (str.length === this.maxLength) {
            this.arrMaxLength.push(str);
        }
        if (str.length > this.maxLength) {
            this.maxLength = str.length;
            this.arrMaxLength = [str];
        }
    }

    async askInputDic(key, content) {
        const n = await new Promise(resolve => {
            input.question(content, resolve)
        })
        if (this.validateStr(n)) {
            this.dic.push(n)
            this.findMaxLength(n);
        } else {
            console.log(`Tu thu ${(key + 1)} khong duoc trong`)
            await this.askInputDic(key, content);
        }
    }

    async answer() {
        for (let i = 0; i < this.countStr; i++) {
            await this.askInputDic(i, `Nhap tu thu ${(i + 1)}`);
        }
        console.log(this.dic)
        console.log(this.arrMaxLength)
    }
}

class Exercise29 extends ExerciseBase {
    constructor() {
        super('q29')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 0);
    }

    answer(params) {
        (new Answer29(params.n)).answer();
    }
}

module.exports = (new Exercise29()).start();