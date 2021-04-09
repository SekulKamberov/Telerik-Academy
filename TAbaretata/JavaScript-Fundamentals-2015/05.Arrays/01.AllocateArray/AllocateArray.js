
// Problem 1: Write a script that allocates array of 20 integers and initializes each element by 
// its index multiplied by 5. Print the obtained array on the console.

var arr = new Array(20);

for (var i = 0; i < arr.length; i++)
{
    arr[i] = i * 5;
    console.log('arr[' + i + '] = ' + arr[i]);
}