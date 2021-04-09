/*
Problem 4: You are given a text. Write a function that changes the text in all regions:
<upcase>text</upcase> to uppercase.
<lowcase>text</lowcase> to lowercase
<mixcase>text</mixcase> to mix casing(random)
    We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have
    <lowcase>anything</lowcase> else.

The expected result:
    We are LiVinG in a YELLOW SUBMARINE. We dOn'T have anything else.
Regions can be nested.
*/

function getReplacedTextRegions(text) {
    text = String(text);
	
    var answer = "",
		cases = [],
		currLetter,
		j,
		i;
	
    function mixCase(letter) {
        var upper = Math.random() < 0.5;
        if (upper) {
            return letter.toUpperCase();
        }
        else {
            return letter.toLowerCase();
        }
    }
	
    function lowCase(letter) {
        return letter.toLowerCase();
    }
	
    function upCase(letter) {
        return letter.toUpperCase();
    }
	
		
    for (i = 0; i < text.length; i+=1) {
        if (text[i] == '<') {
            i++;
            if (text[i] == "/") {
                cases.pop();
                while (text[i] != '>') {
                    i++;
                }
            }
            else if (text[i] == 'm') {
                cases.push(mixCase);
                while (text[i] != '>') {
                    i++;
                }
            }
            else if (text[i] == 'u') {
                cases.push(upCase);
                while (text[i] != '>') {
                    i++;
                }
            }
            else if (text[i] == 'l') {
                cases.push(lowCase);
                while (text[i] != '>') {
                    i++;
                }
            }
            else {
                alert(i + "Something wrong at this index mr Developer");
            }
        }
        else {
            if (cases.length == 0) {
                answer += text[i];
            }
            else {
                currLetter = text[i];
                for (j = cases.length - 1; j >= 0; j-=1) {
                    currLetter = cases[j](currLetter);
                }
                answer += currLetter;
            }
        }
    }
    return answer;
}

var text = "We are <mixcase>living</mixcase> in a <upcase>yellow submarine</upcase>. We <mixcase>don't</mixcase> have <lowcase>anything</lowcase> else.",
	changed = getReplacedTextRegions(text);
	
console.log(changed);