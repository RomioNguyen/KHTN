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
    isNumber: (value) => int_try_parse(value, null),
    numBetween: (value, min = 0, max = 0) => {
        const n = int_try_parse(value, null);
        if (n) {
            if ((n > min && n < max)) return true
            console.log(`Your input need a between ${min} and ${max}`);
            return false;
        } else {
            console.log('Your input need a number')
            return false;
        }

    }
};