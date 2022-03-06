'use strict';
const dataQ = require('../data/questions');

class QEnty {
    constructor(
        key = 'key',
        validate = () => null,
        answer = () => null
    ) {
        if (dataQ.hasOwnProperty(key)) {
            this.q = dataQ[key];
            this.fnValidate = validate;
            this.fnAnswer = answer;
        }
    }
    getParams() {
        return this.q?.params || null;
    }

    showContentQuestion() {
        console.log(this?.q?.content || 'Cau hoi khong co content')
    }
}

module.exports = QEnty;