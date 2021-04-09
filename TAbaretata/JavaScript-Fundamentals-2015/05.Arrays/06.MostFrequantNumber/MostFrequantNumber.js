
// Problem 6: Write a program that finds the most frequent number in an array. Example:
// {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} > 4 (5 times)

var arr = [4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3];
var count = 1,
    maxCount = 1,
    countedNum = 0;

arr.sort(function (a, b) {
    return a - b;
});

for (var i = 0; i < arr.length - 1; i++) {
    if (arr[i] == arr[i + 1]) {
        count++;
    } else {
        count = 1;
    }
    if (count >= maxCount) {
        maxCount = count;
        countedNum = arr[i];
    }
}
if (maxCount > 1) {
    console.log('Most frequant number is ' + countedNum + ' and it is counted ' + maxCount + ' times.');
} else {
    console.log('No frequancy!');
}
