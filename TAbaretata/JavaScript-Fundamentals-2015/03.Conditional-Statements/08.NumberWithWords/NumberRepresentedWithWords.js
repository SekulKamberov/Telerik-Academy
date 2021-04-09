
// Problem 8: Write a script that converts a number in the range [0...999] to a text corresponding to its English pronunciation. 

var n = 100;
var word = "";
var ones = ["Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten",
    "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"];
var tens = ["", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety"];

if (n <= 999) {
    if (n >= 100) {
        console.log(ones[parseInt(n / 100)] + " hundred" + (parseInt(n % 100) == 0 ? "" : " and "));
        if (n % 100 != 0) {
            n = (n - ((parseInt(n / 100)) * 100));
            if (n < 100) {
                if (n < 20) {
                    word = ones[n];
                } else {
                    word = tens[parseInt(n / 10)];

                    if (parseInt(n % 10) != 0) {
                        word = word + "-" + ones[parseInt(n % 10)];
                    }
                }
            }
            console.log(word);
        }
    } else {
        if (n >= 0 && n < 100) {
            if (n < 20) {
                word = ones[n];
            } else {
                word = tens[parseInt(n / 10)];

                if (parseInt(n % 10) != 0) {
                    word += "-" + ones[parseInt(n % 10)];
                }
            }
        }
        console.log(word);
    }
}
else {
    Console.WriteLine("Invalid input!");
}
