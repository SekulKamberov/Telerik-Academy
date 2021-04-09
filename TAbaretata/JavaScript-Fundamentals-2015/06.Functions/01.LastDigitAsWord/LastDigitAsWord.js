
// Problem 1: Write a function that returns the last digit of given integer as an English word. Examples: 512 > "two",
// 1024 > "four", 12309 > "nine"

function lastDigitAsWord(number) {
    var lastDigit = number % 10;
    switch (lastDigit)
    {
        case 0: return 'zero'; break;
        case 1: return 'one'; break;
        case 2: return 'two'; break;
        case 3: return 'three'; break;
        case 4: return 'four'; break;
        case 5: return 'five'; break;
        case 6: return 'six'; break;
        case 7: return 'seven'; break;
        case 8: return 'eight'; break;
        case 9: return 'nine'; break;
        default: return 'wrong input'; break;
    }
}

function printResult() {
    var num = 102;
    console.log('Last digit in number ' + num + ' is ' + lastDigitAsWord(num));
}

printResult();