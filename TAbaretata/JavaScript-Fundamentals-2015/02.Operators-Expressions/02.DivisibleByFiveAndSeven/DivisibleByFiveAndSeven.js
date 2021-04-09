
// Problem 2: Write a boolean expression that checks for given integer if it can be divided 
// (without remainder) by 7 and 5 in the same time.

var number = 34;

if (number % 5 === 0 && number % 7 === 0) {
    console.log("Number is divisible by 5 and 7 at the same time");
}
else {
    console.log("Number is NOT divisible by 5 and 7 at the same time");
}