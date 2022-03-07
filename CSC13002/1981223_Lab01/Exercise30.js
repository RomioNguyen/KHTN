'use strict';
const ExerciseBase = require('./services/ExerciseBase');

class Exercise30 extends ExerciseBase {
    constructor() {
        super('q30')
    }

    validate(key, value) {
        if (value && value.trim() !== '')
            return true
        console.log(`Chuoi khong duoc trong`)
        return false;
    }

    answer(params) {
        let flag = true;
        let arrChecked = [];
        const arrChars = Object.assign([], params.s);
        for (let i = 0; i < arrChars.length; i++) {
            if (arrChecked.indexOf(arrChars[i]) === -1) {
                arrChecked.push(arrChars[i]);
            }else{
                flag=false;
                break;
            }
        }
        console.log(flag)
    }
}

module.exports = (new Exercise30()).start();