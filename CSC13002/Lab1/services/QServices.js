'use strict';
const input = require('../utils/input');

class QServices {
    constructor(question) {
        this.q = question;
        this.params = {};
    }

    async ask(key, content) {
        const n = await new Promise(resolve => {
            input.question(content, resolve)
        })
        if (this.q.fnValidate(key, n)) {
            this.params[key] = n;
        } else {
            console.log("Your input invalid. Please again!!!")
            await this.ask(key, content);
        }
    }

    async start() {
        if (this.q) {
            const params = this.q.getParams();
            if (params) {
                const keyParams = Object.keys(params);
                for (let i = 0; i < keyParams.length; i++) {
                    await this.ask(keyParams[i], params[keyParams[i]]);
                }
            }
            this.q.fnAnswer(this.params);
        }

    }
}

module.exports = QServices;