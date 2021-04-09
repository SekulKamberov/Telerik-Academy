/// <reference path="..\node_modules\jquery\dist\jquery.js" />

function solve() {
    return function (selector) {
        var $outterDiv = $('<div/>').addClass('dropdown-list');
        $(selector).prependTo($outterDiv);
        //console.log($(selector).val());
        $('body').append($outterDiv);
        $(selector).css('display', 'none');

        var $currentDiv = $('<div/>').addClass('current').attr('data-value', '').text('Option 1');
        $outterDiv.append($currentDiv);

        $currentDiv.on('click', function () {
            $optionContainerDiv.show();
        });

        var $optionContainerDiv = $('<div/>').addClass('options-container').css('position', 'absolute').css('display', 'none');
        $outterDiv.append($optionContainerDiv);

        var i, len, $optionDiv;
        for (i = 0, len = $(selector + ' option').size() ; i < len; i += 1) {
                $(' <div class="dropdown-item" data-value="' +
            (i - 1) + '" data-index = "' + i + '">Option ' + (i + 1) + '</div>').appendTo('.options-container');
            //$('<div/>').addClass('dropdown-item').attr('data-value', 'value-' + (i - 1))
            //    .text('Option ' + (i + 1)).appendTo('.options-container');

        }

        $('.dropdown-item').on('click', function () {
            var $this = $(this);
            $currentDiv.text($this.text()); //attr('data-value', $this.attr('data-value'))
            $optionContainerDiv.hide();

        });
    };
}

module.exports = solve;