
// Problem 5: Write a function that replaces non breaking white-spaces in a text with &nbsp;

function replaceWhitespace(text, replacer) {
    var modifiedText = '',
        i;
		
    for (i = 0; i < text.length; i+=1) {
        if (text[i] === ' ') {
            modifiedText += replacer;
            continue;
        }
        modifiedText += text[i];
    }
    return modifiedText;
}

var text = "We are living in an yellow submarine. We don't have anything else.",
    replacer = '&nbsp';

console.log(replaceWhitespace(text, replacer));