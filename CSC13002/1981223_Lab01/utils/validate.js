const int_try_parse = function (val, default_val) {
    try {
        if (val != null) {
            if (`${val}`.length > 0) {
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
        if (int_try_parse(value, null) !== null)
            return true
        console.log(`${key} phai la so`)
        return false;
    },
    numBigger: (value, min = 0) => {
        const n = int_try_parse(value, null);
        if (n !== null) {
            if (n > min) return true
            console.log(`So nhap phai lon hon ${min}`);
            return false;
        } else {
            console.log('Phan tu phai la so')
            return false;
        }
    },
    numBetween: (value, min = 0, max = 0) => {
        const n = int_try_parse(value, null);
        if (n !== null) {
            if ((n > min && n < max)) return true
            console.log(`So phap phai o giua ${min} va ${max}`);
            return false;
        } else {
            console.log('Phan tu phai la so')
            return false;
        }
    }
};
