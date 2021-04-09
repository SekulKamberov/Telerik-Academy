/*
Problem 2: Write a JavaScript function to check if in a given expression the brackets are put correctly.
    Example of correct expression: ((a+b)/5-d).
    Example of incorrect expression: )(a+b)).
*/

function checkBrackets(expression) {
    var counter = 0,
		i;
    for (i = 0; i < expression.length; i+=1) {
        if (expression[i] === '(') {
            counter += 1;
        } else if (expression[i] === ')') {
            counter -= 1;
            if (counter < 0) {
                break;
            }
        }
    }
    return counter;
}

var brackets = checkBrackets(')(a+b))');
console.log(brackets === 0 ? 'Correct expression' : 'Incorrect expression');