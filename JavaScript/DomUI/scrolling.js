(function ($) {
    var $curr;
    $.fn.nextOrFirst = function (element, className) {
        $curr = element.addClass(className);
        this.on('click', function () {
            var $next = $curr.next();
            if ($next.length === 0) {
                $curr = $curr.siblings().first();
            } else {
                $curr = $next;
            }
            $curr.addClass(className)
                .siblings()
                .removeClass(className);
        });

        return this;
    };

    $.fn.prevOrLast = function (element, className) {
        $curr = element.addClass(className);
        this.on('click', function () {
            var $prev = $curr.prev();
            if ($prev.length === 0) {
                $curr = $curr.siblings().last();
            } else {
                $curr = $prev;
            }
            $curr.addClass(className)
                .siblings()
                .removeClass(className);
        });

        return this;
    };
}(jQuery));