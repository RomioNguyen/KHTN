'use strict';
const Entity = require("../entities/QEntity");
const Services = require("./QServices");

class ExerciseBase {
    constructor(_key) {
        this.key = _key;
        this.q = new Entity(_key, this.validate, this.answer);

    }

    validate(key, value) {
        return true
    }

    answer(value) {

    }

    start() {
        const s = new Services(this.q);
        this.q.showContentQuestion();
        s.start();
    }
}

module.exports = ExerciseBase;