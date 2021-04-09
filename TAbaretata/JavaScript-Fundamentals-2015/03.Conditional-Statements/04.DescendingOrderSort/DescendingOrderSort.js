
// Problem 4: Sort 3 real values in descending order using nested if statements.

var a = 6,
    b = 7,
    c = 5;

if (a > b) {
    if (a > c) {
        if (b > c) {
            console.log("From bigger to smaller: " + a + " " + b + " " + " " + c);
        } else {
            console.log("From bigger to smaller: " + a + " " + c + " " + b);
        }
    } else {
        console.log("From bigger to smaller: " + c + " " + a + " " + b);
    }
}
if (b > a) {
    if (b > c) {
        if (a > c) {
            console.log("From bigger to smaller: " + b + " " + a + " " + c);
        } else {
            console.log("From bigger to smaller: " + b + " " + c + " " + a);
        }
    } else {
        console.log("From bigger to smaller: " + c + " " + b + " " + a);
    }
}