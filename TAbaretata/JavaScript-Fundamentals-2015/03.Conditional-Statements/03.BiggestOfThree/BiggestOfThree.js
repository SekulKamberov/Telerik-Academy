
// Problem 3: Write a script that finds the biggest of three integers using nested if statements.

var a = 3,
    b = 5,
    c = 4;

if (a > b) {
    if (a > c) {
        console.log("Bigger number is: " + a);
    } else {
        console.log("Bigger number is: " + c);
    }
} else if (b > a) {
    if (b > c) {
        console.log("Bigger number is: " + b);
    } else {
        console.log("Bigger number is: " + c);
    }
}