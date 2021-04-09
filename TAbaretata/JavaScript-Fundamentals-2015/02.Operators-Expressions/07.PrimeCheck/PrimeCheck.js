
// Problem 7: Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

var number = 37;

var maxValue = parseInt(number / 2);
var isPrime = true;

for (var i = 2; i < maxValue; i++) {
    if (parseInt(number % i) === 0) {
        isPrime = false;
        break;
    }
}

console.log("Number " + number + " is prime? --> " + isPrime);
