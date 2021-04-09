/*
Problem 11: Write a function that formats a string using placeholders:
    var str = stringFormat('Hello {0}!', 'Peter');
    //str = 'Hello Peter!';
The function should work with up to 30 placeholders and all types
    var frmt = '{0}, {1}, {0} text {2}';
    var str = stringFormat(frmt, 1, 'Pesho', 'Gosho');
    //str = '1, Pesho, 1 text Gosho'
*/

function stringFormat(text, wordsArr) {
    var answer = '',
        start = 0,
        index = text.indexOf('{'),
		holderNum;
		
    while (index > -1) {
        holderNum = text.substr(index + 1, 1) | 0;
        answer += text.substring(start, index - 1) + ' ';
        answer += wordsArr[holderNum] + ' ';
        start = index + 3;
        index = text.indexOf('{', index + 1);
    }
    return answer;
}

var text = '{0}, {1}, {0} text {2}',
	words = [1, 'Pesho', 'Gosho'];
	
console.log(stringFormat(text,words));