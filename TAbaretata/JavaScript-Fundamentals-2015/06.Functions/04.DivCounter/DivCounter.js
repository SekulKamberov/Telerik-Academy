
// Problem 4: Write a function to count the number of divs on the web page

function divCounter() {
    var divs = document.getElementsByTagName('div').length;
    console.log(divs);
}

divCounter();