
// Problem 4: Write a function that checks if a given object contains a given property.

function hasProperty(obj, prop) {
    for (var i in obj) {
        if (i === prop) {
            return true;
        }
    }
    return false;
}

var testObj = {
    fname: "Dwayne",
    lname: "Johnson",
    age: 42
}

var hasProp = hasProperty(testObj, 'fname');
console.log(hasProp);