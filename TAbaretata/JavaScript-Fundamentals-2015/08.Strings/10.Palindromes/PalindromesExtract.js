
// Problem 10: Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

function extractPalindromes(text) {
    var splitedText,
        word = '',
		i,
		j;
		
    text = text.toLowerCase();
    text = text.replace('.', ' ').replace('!', ' ').replace('?', ' ').replace(',', ' ');
	splitedText = text.split(' ');
	
    for (i = 0; i < splitedText.length; i+=1) {
        word = '';
        for (j = splitedText[i].length - 1; j >= 0; j-=1) {
            word += splitedText[i][j];
        }
        if (word === splitedText[i]) {
            console.log(word);
        }
    }
}

var text = 'ABBA are lamal and start with exe';
extractPalindromes(text);