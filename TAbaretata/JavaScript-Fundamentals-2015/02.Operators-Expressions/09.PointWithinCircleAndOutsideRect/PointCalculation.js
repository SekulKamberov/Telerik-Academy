
// Problem 9: Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) 
// and out of the rectangle R(top=1, left=-1, width=6, height=2).

var x = 4,
    y = 0,
    r = 3,
    center = 1;

if ((x < -1 || x > 5) || (y > 1 || y < -1)) {
    if (Math.pow((x - center), 2) + Math.pow((y - center), 2) < Math.pow(r, 2)) {
        console.log("Point (" + x + ";" + y + ") is in circle and outside the rectangle!");
    } else {
        console.log("Point (" + x + ";" + y + ") is NOT in circle!");
    }
} else {
    console.log("Point (" + x + ";" + y + ") is IN the rectangle!");
}

