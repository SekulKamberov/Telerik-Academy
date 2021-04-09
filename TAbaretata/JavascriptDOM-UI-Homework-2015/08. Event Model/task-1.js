/* globals $ */

/* 

Create a function that takes an id or DOM element and:

*/

function solve() {
    return function (selector) {
        var element = document.getElementById(selector);

        if (typeof (selector) !== 'string' && !(selector instanceof HTMLElement)) {
            throw new Error('Id is not provided!');
        }
        if (element === null) {
            throw new Error('Id does not select any element!');
        }

        var i,
            len,
            buttons = document.getElementsByClassName('button'),
            content = document.getElementsByClassName('content');

        for (i = 0, len = buttons.length; i < len; i += 1) {
            buttons[i].innerHTML = 'hide';
            buttons[i].addEventListener('click', function (e) {
                var clickedButton = e.target,
                    nextSibling = clickedButton.nextElementSibling,
                    validContent = false,
                    firstContent;

                while (nextSibling) {
                    if (nextSibling.className === 'content') {
                        firstContent = nextSibling;
                        nextSibling = nextSibling.nextSibling;
                        while (nextSibling) {
                            if (nextSibling.className === 'button') {
                                validContent = true;
                                break;
                            }
                            nextSibling = nextSibling.nextElementSibling;
                        }
                        break;
                    } else {
                        nextSibling = nextSibling.nextElementSibling;
                    }
                }

                if (validContent) {
                    if (firstContent.style.display === 'none') {
                        firstContent.style.display = '';
                        clickedButton.innerHTML = 'hide';
                    } else {
                        firstContent.style.display = 'none';
                        clickedButton.innerHTML = 'show';
                    }
                }
            });
        }
    };
};

module.exports = solve;