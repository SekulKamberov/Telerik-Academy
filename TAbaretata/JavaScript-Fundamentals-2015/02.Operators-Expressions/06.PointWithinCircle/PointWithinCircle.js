
// Problem 6: Write an expression that checks if given print (x,  y) is within a circle K(O, 5).

var x = 3,
    y = 1,
    r = 5;

if (Math.pow(x,2) + Math.pow(y,2) < Math.pow(r,2)) {
    console.log("Point (" + x + ";" + y + ") is in circle K(0,5)!");
} else {
    console.log("Point (" + x + ";" + y + ") is NOT in circle K(0,5)!");
}

