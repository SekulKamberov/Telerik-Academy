
// Problem 5: Write a function that counts how many times given number appears in given array. 
// Write a test function to check if the function is working correctly.

function numberCounter(arr, number) {
    var counter = 0;
    arr.forEach(function (element) {
        if (element === number) {
            counter+=1;
        }
    });

    return counter;
}

function test() {
    var arr = [2, 3, 4, 5, 6, 2, 3, 4, 2],
        number = 2;
    console.log(numberCounter(arr, number));
}

test();