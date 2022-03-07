class Fraction {
    constructor(_n, _d) {
        this.numerator = _n;
        this.denominator = _d;
    }

    findGreatestCommonDivisor(x, y) {
        while (x != y) {
            if (x > y) x = x - y;
            else y = y - x;
        }
        return x;
    }

    plus(ps) {
        let newNumerator = this.numerator * ps.denominator + this.denominator * ps.numerator;
        let newDenominator = this.denominator * ps.denominator;
        const greatestCommonDivisor = findGreatestCommonDivisor(newNumerator, newDenominator);
        this.numerator = newNumerator / greatestCommonDivisor;
        this.denominator = newDenominator / greatestCommonDivisor;
    }

    showFraction() {
        return `${this.numerator}/${this.denominator}`
    }

}

module.exports = Fraction;