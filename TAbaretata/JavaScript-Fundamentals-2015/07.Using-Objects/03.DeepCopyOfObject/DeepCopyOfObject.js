
// Problem 3: Write a function that makes a deep copy of an object.The function should work for both primitive and reference types

function deepCopy(obj) {
    if (obj === null || typeof obj !== 'Object') {
        var copy = obj;
        return copy;
    } else if (obj instanceof Array) {
        copy = [];
        for (i = 0; i < obj.length; i+=1) {
            copy[i] = deepCopy(obj[i]);
        }
        return copy;
    } else if (obj instanceof Object) {
        copy = {};
        for (var prop in obj) {
            if (prop.hasOwnProperty(prop)) {
                copy[prop] = deepCopy(obj[prop]);
            }
        }
        return copy;
    }
}

var originalObj = {
    first: 1,
    second: 2
}
var clonedObj = deepCopy(originalObj);
for (var i in clonedObj) {
    console.log(i + ' -> ' + clonedObj[i]);
}