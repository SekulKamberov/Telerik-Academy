/*
Problem 8: Write a JavaScript function that replaces in a HTML document given as string all the tags 
<a href="…">…</a> with corresponding tags [URL=…]…/URL]. 
Sample HTML fragment:
    <p>Please visit <a href="http://academy.telerik. com">our site</a> to choose a training course.
    Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>
Result: 
    <p>Please visit [URL=http://academy.telerik.com]our site[/URL] to choose a training course. 
    Also visit [URL=www.devbg.org]our forum[/URL] to discuss the courses.</p>
*/

var text = '<p>Please visit <a href="http://academy.telerik.com">our site</a> to choose a training course.Also visit <a href="www.devbg.org">our forum</a> to discuss the courses.</p>',
    urlStart = '[URL=',
    urlClose = ']',
    urlEnd = '[/URL]';

function replaceTags(text) {
	var i;
	
    for (i = 0; i < text.length - 9; i += 1) {
        if (text.substr(i, 9) === '<a href="') {
            text = text.replace('<a href="', urlStart);
        } else if (text.substr(i, 2) === '">') {
            text = text.replace('">', urlClose);
        } else if (text.substr(i, 4) === '</a>') {
            text = text.replace('</a>', urlEnd);
        }
    }
    return text;
}

console.log(replaceTags(text));
