/* globals $ */

/* 

Create a function that takes a selector and COUNT, then generates inside a UL with COUNT LIs:   
  * The UL must have a class `items-list`
  * Each of the LIs must:
    * have a class `list-item`
    * content "List item #INDEX"
      * The indices are zero-based
  * If the provided selector does not selects anything, do nothing
  * Throws if
    * COUNT is a `Number`, but is less than 1
    * COUNT is **missing**, or **not convertible** to `Number`
      * _Example:_
        * Valid COUNT values:
          * 1, 2, 3, '1', '4', '1123'
        * Invalid COUNT values:
          * '123px' 'John', {}, [] 
*/


function solve() {
    return function (selector, count) {
        var i, len;

        if (typeof (selector) !== 'string' || selector === null || selector === '') {
            throw new Error('Selector is in wrong format');
        }
        if (typeof (count) !== 'number' || count === null || isNaN(count) || count <= 0) {
            throw new Error('Count is not a number!');
        }

        $(selector).append('<ul/>')
        $(selector + ' ul').addClass('items-list');

        for (i = 0, len = count; i < len; i += 1) {
            var li = $('<li/>').addClass('list-item').text('List item #' + i);
            $('.items-list').append(li);
        }
    };
};

module.exports = solve;