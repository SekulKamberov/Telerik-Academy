
// Problem 9: Write a function for extracting all email addresses from given text. All substrings that match the format 
// <identifier>@<host>…<domain> should be recognized as emails. Return the emails as array of strings.

function extractEmail(text) {
    var regex = /([a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9._-]+)/gi;
    return text.match(regex);
}

var text = 'Email examples example@abv.bg or dwayne.johnson@gmail.com are valid';
console.log(extractEmail(text));