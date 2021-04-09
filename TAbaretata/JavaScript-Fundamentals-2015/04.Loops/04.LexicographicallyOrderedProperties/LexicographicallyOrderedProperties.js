
// Problem 4: Write a script that finds the lexicographically smallest and largest property in document, 
// window and navigator objects

var arr = [document, window, navigator];
var output = "";
var propertyArray;

for (var i = 0; i < 3; i++) {
    
    for (var property in arr[i]) {
        output = output + property + ' ';
    }
}

propertyArray = output.split(' ');
propertyArray.sort();
console.log('Min element ' + propertyArray[1]);
console.log('Max element ' + propertyArray[propertyArray.length - 1]);