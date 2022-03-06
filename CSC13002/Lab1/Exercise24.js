'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const input = require("./utils/input");

class Answer24 {
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

    async askInputDic(key, content) {
        const n = await new Promise(resolve => {
            input.question(content, resolve)
        })
        if (this.validateInput(key, n)) {
            this.dic.push(n);
        } else {
            await this.askInputDic(key, content);
        }
    }

    async answer() {
        for (let i = 0; i < this.count; i++) {
            await this.askInputDic(i, `Nhap phan tu thu ${(i + 1)}: `);
        }
        const rsCheckOrder = this.checkOrder();
        if (rsCheckOrder) {
            const findNum = await new Promise(resolve => {
                input.question(content, resolve)
            })
            return true
        } else
            return false;

    }
}

class Exercise24 extends ExerciseBase {
    constructor() {
        super('q24')
    }

    validate(key, value) {
        return validateUtils.numBigger(value, 0);
    }

    async answer(params) {
        const answerServices = (new Answer24(params.n));
        let flagStop = false;
        let rsOrder = false;
        while (flagStop === false && rsOrder === false) {
            rsOrder = answerServices.answer();
            if (rsOrder === false) {
                const stop = await new Promise(resolve => {
                    input.question('You want to continue exercise (y/n)?: ', resolve)
                })
                flagStop = (stop !== 'y');
            }
        }
    }
}

module.exports = (new Exercise24()).start();