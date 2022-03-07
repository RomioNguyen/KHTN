'use strict';
const ExerciseBase = require('./services/ExerciseBase');
const validateUtils = require("./utils/validate");
const input = require("./utils/input");

class Answer24 {
    constructor(number) {
        this.dic = [];
        this.count = number
        this.iMid = [];
        // lấy nguyên
        const c = (number - number % 2) / 2;
        if (number % 2 == 0) {
            this.iMid.push(c - 1);
        }
        this.iMid.push(c)
    }

    validateInput(value, min = 0) {
        return validateUtils.numBigger(value, min)
    }

    async askInputDic(key, content) {
        const n = await new Promise(resolve => {
            input.question(content, resolve)
        })
        if (this.validateInput(n)) {
            this.dic.push(parseInt(n));
        } else {
            await this.askInputDic(key, content);
        }
    }

    checkOrder() {
        return true;
    }

    addItemWithIndex(arr, index, item) {
        arr.splice(index, 0, item);
    }

    async findNumber() {
        const findNum = await new Promise(resolve => {
            input.question("Nhap so can tim ", resolve)
        })
        if (this.validateInput(findNum, -1)) {
            const num = parseInt(findNum);
            let index = this.dic.indexOf(findNum);
            let added = false;
            if (index === -1) {
                index = 0;
                for (let i = 0; i < this.dic.length; i++) {
                    index = i;
                    if (num <= this.dic[i]) {
                        added = true;
                        this.addItemWithIndex(this.dic, index, num)
                        break;
                    }
                    if (added === false && index === (this.dic.length - 1)) {
                        index = (i + 1)
                        this.addItemWithIndex(this.dic, index, num);
                        break;
                    }
                }
            }
            console.log(this.dic);
            console.log(index)
        } else await this.findNumber()
    }

    async answer() {
        for (let i = 0; i < this.count; i++) {
            await this.askInputDic(i, `Nhap phan tu thu ${(i + 1)}: `);
        }
        const rsCheckOrder = this.checkOrder();
        if (rsCheckOrder) {
            await this.findNumber()
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