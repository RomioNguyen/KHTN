const int_try_parse = function (val, default_val) {
    try {
        if (val != null) {
            if (val.length > 0) {
                return parseInt(val);
            }
        }
    } catch (err) {
        console.log(err);
    }
    return default_val;
}
module.exports = {
    isNumber: (value, key) => {
        if (int_try_parse(value, null))
            return true
        console.log(`${key} need a number`)
        return false;
    },
    numBigger: (value, min = 0) => {
        const n = int_try_parse(value, null);
        if (n) {
            if (n > min) return true
            console.log(`Your input need bigger than ${min}`);
            return false;
        } else {
            console.log('Your input need a number')
            return false;
        }
    },
    numBetween: (value, min = 0, max = 0) => {
        const n = int_try_parse(value, null);
        if (n) {
            if ((n > min && n < max)) return true
            console.log(`Your input need between ${min} and ${max}`);
            return false;
        } else {
            console.log('Your input need a number')
            return false;
        }
    }
};