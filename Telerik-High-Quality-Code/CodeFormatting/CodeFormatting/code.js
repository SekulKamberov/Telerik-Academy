var applicationName = navigator.appName,
    addScroll = false,
    pointX = 0,
    pointY = 0,
    theLayer;
if ((navigator.userAgent.indexOf('MSIE 5') > 0) || (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

document.onmousemove = mouseMove;
if (applicationName == "Netscape") {
    document.captureEvents(Event.MOUSEMOVE)
};

function mouseMove(evn) {
    if (applicationName == "Netscape") {
        pointX = evn.pageX - 5;
        pointY = evn.pageY;
    } else {
        pointX = event.x - 5;
        pointY = event.y;
    }

    if (applicationName == "Netscape") {
        if (document.layers['ToolTip'].visibility == 'show') {
            popTip();
        }
    } else {
        if (document.all['ToolTip'].style.visibility == 'visible') {
            popTip();
        }
    }
}

function popTip() {
    if (applicationName == "Netscape") {
        theLayer = eval('document.layers[\'ToolTip\']');
        if ((pointX + 120) > window.innerWidth) {
            pointX = window.innerWidth - 150;
        }

        theLayer.left = pointX + 10;
        theLayer.top = pointY + 15;
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'ToolTip\']');

        if (theLayer) {
            pointX = event.x - 5;
            pointY = event.y;
            if (addScroll) {
                pointX = pointX + document.body.scrollLeft;
                pointY = pointY + document.body.scrollTop;
            }

            if ((pointX + 120) > document.body.clientWidth) {
                pointX = pointX - 150;
            }

            theLayer.style.pixelLeft = pointX + 10;
            theLayer.style.pixelTop = pointY + 15;
            theLayer.style.visibility = 'visible';
        }
    }
}

function hideTip() {
    if (applicationName == "Netscape") {
        document.layers['ToolTip'].visibility = 'hide';
    } else {
        document.all['ToolTip'].style.visibility = 'hidden';
    }
}

function hideFirstMenu() {
    if (applicationName == "Netscape") {
        document.layers['menu1'].visibility = 'hide';
    } else {
        document.all['menu1'].style.visibility = 'hidden';
    }
}

function showFirstMenu() {
    if (applicationName == "Netscape") {
        theLayer = eval('document.layers[\'menu1\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'menu1\']');
        theLayer.style.visibility = 'visible';
    }
}

function hideSecondMenu() {
    if (applicationName == "Netscape") {
        document.layers['menu2'].visibility = 'hide';
    } else {
        document.all['menu2'].style.visibility = 'hidden';
    }
}

function showSecondMenu() {
    if (applicationName == "Netscape") {
        theLayer = eval('document.layers[\'menu2\']');
        theLayer.visibility = 'show';
    } else {
        theLayer = eval('document.all[\'menu2\']');
        theLayer.style.visibility = 'visible';
    }
}