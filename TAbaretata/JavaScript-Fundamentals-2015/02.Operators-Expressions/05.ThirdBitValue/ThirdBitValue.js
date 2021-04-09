
// Problem 5: Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

var number = 8;
var position = 3;
var result = (number & (1 << position)) >> position;

console.log(result);