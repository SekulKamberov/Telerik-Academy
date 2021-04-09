
// Problem 3: Write a script that finds the maximal sequence of equal elements in an array
// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} > {2, 2, 2}.

var arr = [2, 3, 4, 4, 2, 2, 2, 3];
var bestSeq = 1,
    currSeq = 1,
    bestNum = 0;

for (var i = 0; i < arr.length - 1; i++) {
    if (arr[i] === arr[i + 1]) {
        currSeq++;
    } else {
        currSeq = 1;
    }
    if (currSeq >= bestSeq) {
        bestSeq = currSeq;
        bestNum = arr[i];
    }
}

// Print the maximal euqal sequance 
for (var i = 0; i < bestSeq; i++) {
    console.log(bestNum);
}