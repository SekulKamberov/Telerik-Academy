/* 
Problem 5: Sorting an array means to arrange its elements in increasing order. Write a script to sort an array.
Use the "selection sort" algorithm: Find the smallest element, move it at the first position, find the smallest from the rest,
move it at the second position, etc.Hint: Use a second array
*/

var arr = [1, 3, 66, 40, 21, 25, 4, 60, 33, 28, 44];

for (var i = 0; i < arr.length - 1; i++) {
    var min = i;
    for (var j = i + 1; j < arr.length; j++) {
        if (arr[j] < arr[min]) {
            min = j;
        }
    }
    var temp = arr[i];
    arr[i] = arr[min];
    arr[min] = temp;
}
for (var i = 0; i < arr.length; i++) {
    console.log(arr[i] + ' ');
}