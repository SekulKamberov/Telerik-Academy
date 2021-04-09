
// Problem 6: Write a script that enters the coefficients a, b and c of a quadratic equation a*x2 + b*x + c = 0 
// and calculates and prints its real roots. Note that quadratic equations may have 0, 1 or 2 real roots.

var a = 2,
    b = 5,
    c = 3,
    x1,
    x2,
    determin;

if (isNaN(a) || isNaN(b) || isNaN(c)) {
    console.log("Values are not numbers!");
} else {
    if (a != 0) {
        determin = b * b - 4 * a * c;
        if (determin > 0) {
            x1 = (-b + Math.sqrt(determin)) / (2 * a);
            x2 = (-b - Math.sqrt(determin)) / (2 * a);
            console.log("x1= " + x1 + "; x2= " + x2);
        } else if (determin === 0) {
            x1 = (-b) / (2 * a);
            console.log("x1, x2 = " + x1);
        } else {
            console.log("There are no roots!");
        }
    } else if (b != 0) {
        x1 = (-c) / b;
        console.log("x1, x2 = " + x1);
    }
}
