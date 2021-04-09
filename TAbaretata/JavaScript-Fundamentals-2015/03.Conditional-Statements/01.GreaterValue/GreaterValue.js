
// Problem 1: Write an if statement that examines two integer variables and exchanges their 
// values if the first one is greater than the second one.

var firstValue = 6,
    secondValue = 5;

if (firstValue > secondValue) {
    var temp = secondValue;
    secondValue = firstValue;
    firstValue = temp;
}

console.log(firstValue);