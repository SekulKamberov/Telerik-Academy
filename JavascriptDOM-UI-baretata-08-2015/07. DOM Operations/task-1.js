/* globals $ */

/* 

Create a function that takes an id or DOM element and an array of contents

* if an id is provided, select the element
* Add divs to the element
  * Each div's content must be one of the items from the contents array
* The function must remove all previous content from the DOM element provided
* Throws if:
  * The provided first parameter is neither string or existing DOM element
  * The provided id does not select anything (there is no element that has such an id)
  * Any of the function params is missing
  * Any of the function params is not as described
  * Any of the contents is neight `string` or `number`
    * In that case, the content of the element **must not be** changed   
*/

module.exports = function () {

    return function (element, contents) {
        var i,
            len,
            currDiv,
            el,
            dFrag = document.createDocumentFragment();

        if (typeof (element) !== 'string' && !(element instanceof HTMLElement)) {
            throw new Error('Element does not exist or is not a string!');
        }
        if (arguments.length !== 2 || !Array.isArray(contents)) {
            throw new Error('Function parameters must be 2 and the second one has to be an array!');
        }

        contents.some(function (content) {
            if (typeof (content) !== 'string' && typeof (content) !== 'number') {
                throw new Error('Content element is not string nor number!');
            }
        });

        el = document.getElementById(element);
        if (!el) {
            el = element;
        }
        el.innerHTML = '';

        for (i = 0, len = contents.length; i < len; i += 1) {
            currDiv = document.createElement('div');
            currDiv.innerHTML = contents[i];
            dFrag.appendChild(currDiv);
        }

        el.appendChild(dFrag);
    };
};