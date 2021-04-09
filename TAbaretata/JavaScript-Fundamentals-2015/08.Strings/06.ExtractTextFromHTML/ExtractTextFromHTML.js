/*
Problem 6: Write a function that extracts the content of a html page given as text. 
The function should return anything that is in a tag, without the tags:
    <html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>
Result:
    Sample sitetextmore textand more...in body
*/

function extractTextFromHTML(text) {
    var answer = '',
        inTag = false,
		i;
		
    for (i = 0; i < text.length; i+=1) {
        if (text[i] === '<') {
            inTag = true;
        } else if (text[i] === '>') {
            inTag = false;
        } else if (!inTag) {
            answer += text[i];
        }
    }
    return answer;
}

var text = '<html><head><title>Sample site</title></head><body><div>text<div>more text</div>and more...</div>in body</body></html>';
console.log(extractTextFromHTML(text));