
// Problem 7: Write a function that returns the index of the first element in array that is bigger than its neighbors,
// or -1, if there’s no such element.Use the function from the previous exercise.

function biggerThanNeighbors(arr) {
    for (var i = 0; i < arr.length; i+=1) {
        if (arr[i] > arr[0] && arr[i] < arr.length) {
            if ((arr[i - 1] < arr[i]) && (arr[i + 1] < arr[i])) {
                return i;
            }
        }
    }
    return -1;
}

function printResult() {
    var arr = [2, 3, 4, 2, 1, 5, 4],
        isBigger = biggerThanNeighbors(arr);
    console.log('First number bigger than its neighbors is at position ' + isBigger);
}

printResult();