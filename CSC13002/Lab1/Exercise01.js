const Entity = require('./entities/QEntity');
const Services = require('./services/QServices');
const validateUtils = require('./utils/validate');

const validate = (key, value) => {
    if (validateUtils.numBetween(value, 3, 50)) {
        return true;
    }
    return false;
}
const answer = (params) => {
    let sum = 0;
    for (let i = 1; i <= params.n; i++)
        sum += i;
    console.log(`S(n) = ${sum}`);
}

const q = new Entity('q1', validate, answer);
const s = new Services(q);
q.showContentQuestion();
s.start();