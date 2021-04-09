
// Problem 4: Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732 => true.

var number = 1732;
var calc = parseInt(number / 100);
var isSeven = false;

if (calc % 10 == 7) {
    isSeven = true;
}

console.log("Third digit is 7? --> " + isSeven);
