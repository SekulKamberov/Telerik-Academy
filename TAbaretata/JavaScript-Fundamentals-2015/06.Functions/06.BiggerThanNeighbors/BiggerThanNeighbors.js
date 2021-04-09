
// Problem 6: Write a function that checks if the element at given position in given array of integers is bigger than 
// its two neighbors (when such exist).

function biggerThanNeighbors(arr, position) {
    if (position < 0) {
        position = 0;
    }
    if (arr[position] > arr[0] && arr[position] < arr.length) {
        if ((arr[position - 1] < arr[position]) && (arr[position + 1] < arr[position])) {
            return true;
        } else {
            return false;
        }
    } else {
        return false;
    }
}

function printResult() {
    var arr = [2, 3, 4, 2, 1, 5, 4],
        position = 2;
    var isBigger = biggerThanNeighbors(arr, position);
    console.log('Number ' + arr[position] + ' is bigger than neighbors? --> ' + isBigger);
}

printResult();