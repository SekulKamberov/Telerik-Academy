
// Problem 7: Write a program that finds the index of given element in a sorted array of integers by using
// the binary search algorithm 

var arr = [3, 1, 5, 12, 4, 8, 2];
var key = 4,
    first = 0,
    last = arr.length - 1;

arr.sort(function (a, b) {
    return a - b;
});

while (last >= first) {
    var mid = parseInt((first + last) / 2);
    if (arr[mid] < key) {
        first = mid + 1;
    } else if (arr[mid] > key) {
        last = mid - 1;
    } else {
        console.log(mid);
        break;
    }
}