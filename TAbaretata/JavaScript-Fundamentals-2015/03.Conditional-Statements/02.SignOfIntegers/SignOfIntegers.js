
// Problem 2: Write a script that shows the sign (+ or -) of the product of three real numbers without calculating it.
// Use a sequence of if statements.

var a = 5,
    b = -5,
    c = 6;

if (a > 0) {
    if (b > 0) {
        if (c > 0) {
            console.log("Sign is '+'");
        } else {
            console.log("Sign is '-'");
        }
    }
    if (b < 0) {
        if (c > 0) {
            console.log("Sign is '-'");
        } else {
            console.log("Sign is '+'");
        }
    }
} else if (a < 0) {
    if (b > 0) {
        if (c > 0) {
            console.log("Sign is '-'");
        } else {
            console.log("Sign is '+'");
        }
    }
    if (b < 0) {
        if (c < 0) {
            console.log("Sign is '-'");
        } else {
            console.log("Sign is '+'");
        }
    }
}