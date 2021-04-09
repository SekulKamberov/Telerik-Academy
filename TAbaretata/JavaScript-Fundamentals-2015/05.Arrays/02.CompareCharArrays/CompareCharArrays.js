
// Problem 2: Write a script that compares two char arrays lexicographically (letter by letter).

var firstCharArray = ['n','m','o'];
var secondCharArray = ['n', 'm', 'i'];
var isEqual = true;

if (firstCharArray.length === secondCharArray.length) {
    for (var i = 0; i < firstCharArray.length; i++) {
        if (firstCharArray[i] !== secondCharArray[i]) {
            isEqual = false;
            break;
        }
    }
} else {
    isEqual = false;
}

console.log('Char arrays are equal? --> ' + isEqual);