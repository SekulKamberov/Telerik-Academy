console.log('Assign all the possible JavaScript literals to different variables.');

var busTicketPrice = 1;
console.log('(Integer) Price of one bus ticket: ' + busTicketPrice + 'lv.');
var gasPrice = 2.29;
console.log('(Floating-Point) Gas-Price: ' + gasPrice + 'lv.');
var isTrue = false;
console.log('(Boolean) Do you like javascript: ' + isTrue);
var city = 'Las Vegas';
console.log('(String) City I have been to: ' + city);

console.log('======================================================================');

console.log('Create a string variable with quoted text in it.');

var quatedText = '"JavaScript", also written as \'javascript\', is the native language of most people living in Delhi.';
console.log(quatedText);

console.log('======================================================================');

console.log('Try typeof on all variables you created.');

console.log('busTicketPrice is of type: ' + typeof busTicketPrice);
console.log('gasPrice is of type: ' + typeof gasPrice);
console.log('isTrue is of type: ' + typeof isTrue);
console.log('city is of type: ' + typeof city);

console.log('======================================================================');

console.log('Create null, undefined variables and try typeof on them.');

var xNull = null;
var yUndefined = undefined;

console.log('xNull = ' + xNull + '  is of type: ' + typeof xNull);
console.log('yUndefined = ' + yUndefined + ' is of type: ' + typeof yUndefined);

console.log('======================================================================');