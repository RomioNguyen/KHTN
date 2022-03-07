const validateUtils = require("../utils/validate");
const input = require("../utils/input");

class Matrix {
    constructor(_n, _m) {
        this.n = _n;
        this.m = _m;
        this.matrix = [[], []];
        this.min = Number.MAX_SAFE_INTEGER;
        this.max = Number.MIN_SAFE_INTEGER;
    }

    validateInput(value, key) {
        return validateUtils.isNumber(value, `Phan tu ${key}`)
    }

    async askAddNumber(i, j, content) {
        const n = await new Promise(resolve => {
            input.question(content, resolve)
        })
        if (this.validateInput(n, `(${i},${j})`)) {
            const num = parseInt(n);
            this.matrix[i][j] = num;
            if (this.min > num) this.min = num;
            if (this.max < num) this.max = num;
        } else {
            await this.askAddNumber(i, j, content);
        }
    }

    async inputMatrix() {
        for (let i = 0; i < this.n; ++i) {
            for (let j = 0; j < this.m; ++j) {
                await this.askAddNumber(i, j, `Nhap phan tu thu (${i},${j}): `);
            }
        }
    }

    find(num) {
        let rs = [-1, -1];
        for (let i = 0; i < this.n; ++i) {
            let flagFound = false;
            for (let j = 0; j < this.m; ++j) {
                console.log(`${i},${j}`, this.matrix[i][j])
                if (this.matrix[i][j] === num) {
                    rs[0] = i;
                    rs[1] = j;
                    flagFound = true;
                    break;
                }
            }
            if (flagFound) break;
        }
        return rs;
    }

    showMatrix() {
        for (let i = 0; i < this.n; ++i) {
            console.log(this.matrix[i])
        }
    }

}

module.exports = Matrix;
