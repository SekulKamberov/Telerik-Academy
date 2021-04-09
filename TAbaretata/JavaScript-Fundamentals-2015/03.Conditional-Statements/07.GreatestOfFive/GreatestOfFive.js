
// Problem 7: Write a script that finds the greatest of given 5 variables.

var arr = [2, 3, 4, 5, 6];
var biggest = arr[0];

for (i = 1; i < arr.length; i++) {
    if (biggest < arr[i]) {
        biggest = arr[i];
    }
}

console.log("Biggest number is: " + biggest);