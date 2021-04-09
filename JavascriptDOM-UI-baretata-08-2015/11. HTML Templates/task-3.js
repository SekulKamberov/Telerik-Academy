// globals Handlebars //
/// <reference path="..\node_modules\jquery\dist\jquery.js" />	

function solve() {
    return function () {
        $.fn.listview = function (data) {
            var i,
                len,
                $this = $(this),
                template = $('#' + $this.attr('data-template')).html(),
                compiledTemplate = handlebars.compile(template);

            for (i = 0, len = data.length; i < len; i+=1) {
                $this.append(compiledTemplate(data[i]));
            }

            return this;
        };
    };
}

module.exports = solve;