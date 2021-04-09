/* globals $ */

/*
Create a function that takes a selector and:
* Finds all elements with class `button` or `content` within the provided element
  * Change the content of all `.button` elements with "hide"
* When a `.button` is clicked:
  * Find the topmost `.content` element, that is before another `.button` and:
    * If the `.content` is visible:
      * Hide the `.content`
      * Change the content of the `.button` to "show"       
    * If the `.content` is hidden:
      * Show the `.content`
      * Change the content of the `.button` to "hide"
    * If there isn't a `.content` element **after the clicked `.button`** and **before other `.button`**, do nothing
* Throws if:
  * The provided ID is not a **jQuery object** or a `string` 

*/

/// <reference path="..\node_modules\jquery\dist\jquery.js" />

function solve() {
    return function (selector) {
        if (typeof (selector) !== 'string' || selector === null || selector === '' || $(selector).size() === 0) {
            throw new Error('Invalid selector');
        }

        var buttons = $('.button'),
            i,
            len;

        for (i = 0, len = buttons.length; i < len; i += 1) {
            var $currButton = $(buttons[i]);

            $currButton.text('hide');
            $currButton.on('click', function () {
                var clickedButton = $(this),
                nextSibling = clickedButton.next(),
                firstContent,
                validFirstContent = false;

                while (nextSibling) {
                    if (nextSibling.hasClass('content')) {
                        firstContent = nextSibling;
                        nextSibling = nextSibling.next();
                        while (nextSibling) {
                            if (nextSibling.hasClass('button')) {
                                validFirstContent = true;
                                break;
                            }
                            nextSibling = nextSibling.next();
                        }
                        break;
                    } else {
                        nextSibling = nextSibling.next();
                    }
                }

                if (validFirstContent) {
                    if (firstContent.css('display') === 'none') {
                        clickedButton.text('hide');
                        firstContent.css('display', '');
                    } else {
                        clickedButton.text('show');
                        firstContent.hide();
                    }
                }
            });

        }
    };
};

module.exports = solve;