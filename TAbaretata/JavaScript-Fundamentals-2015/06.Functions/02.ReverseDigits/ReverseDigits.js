
// Problem 2: Write a function that reverses the digits of given decimal number. Example: 256 > 652

function reverseDigits(number) {
    var r;

    for (r = 0; number; number = Math.floor(number / 10)) {
        r *= 10;
        r += number % 10;
    }
    return r;
}

function printResult() {
    var reversedNumber = reverseDigits(256);
    console.log(reversedNumber);
}

printResult();