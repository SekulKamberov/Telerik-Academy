
// Problem 2: Write a script that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time

var n = 25;

for (var i = 1; i <= n; i++) {
    if (parseInt(i % 3) === 0 && parseInt(i % 7) === 0) {
        continue;
    }
    console.log(i);
}