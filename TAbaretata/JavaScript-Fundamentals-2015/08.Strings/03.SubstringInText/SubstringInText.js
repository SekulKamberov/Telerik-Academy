/*
Problem 3: Write a JavaScript function that finds how many times a substring is contained in a given text 
(perform case insensitive search).
Example: The target substring is "in". The text is as follows:

We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. 
So we are drinking all the day. We will move out of it in 5 days.

The result is: 9.
*/

function substringCount(text) {
    var splitedText = text.toLowerCase().split(substrWord),
		wordCount = splitedText.length - 1;
    console.log(wordCount <= 0 ? 'Word not found' : 'Word counts: ' + wordCount);
}

var text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.",
    substrWord = 'in';
substringCount(text);

