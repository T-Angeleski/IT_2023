$(function () { // On DOM ready
    var ajaxFormSubmit = function () {
        var $form = $(this);
        var options = {
            url: $form.attr("action"),
            type: $form.attr("method"),
            data: $form.serialize() // search term
        };

        $.ajax(options).done(function (data) {
            var $target = $($form.attr("data-noteverse-target"));
            var $newHtml = $(data);
            $target.replaceWith($newHtml);
            $newHtml.effect("highlight");
        })

        return false;
    }

    var submitAutoCompleteForm = function (event, ui) {
        var $input = $(this);
        $input.val(ui.item.label);
        var $form = $input.parents("form:first");
        $form.submit();
    }

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-noteverse-autocomplete"),
            select: submitAutoCompleteForm
        };

        $input.autocomplete(options);
    }


    $("form[data-noteverse-ajax='true']").submit(ajaxFormSubmit);
    $("input[data-noteverse-autocomplete]").each(createAutocomplete)
})