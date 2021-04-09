
/* Problem 2: Write a function that removes all elements with a given value.
    Attach it to the array type.
    Read about prototype and how to attach methods.
*/

Array.prototype.remove = function (element) {
    var fixedArr = [];
    for (var i in this) {
        if (this[i] !== element) {
            fixedArr.push(this[i]);
        }
    }
    return fixedArr;
}

var arr = [1, 2, 1, 4, 1, 3, 4, 1, 111, 3, 2, 1, '1'];
var changedArr = arr.remove(1);
for (var i = 0; i < changedArr.length -1; i+=1) {
    console.log(changedArr[i]);
}