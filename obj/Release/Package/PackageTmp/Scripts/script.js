$(() => {
    $('#otherComp').hide();
    $('#budgetElse').hide();

    $('input[type="radio"]:checked').parent().addClass('active');



    if ($('#otherCompCheck').attr('checked') == 'checked')
        $('#otherComp').show();

    if ($('#budgetElseCheck').attr('checked') == 'checked')
        $('#budgetElse').show();

    $('#otherCompCheck').click(() => {
        $('#otherComp').toggle();
        if ($('#otherComp').not(':visible')) {
            $('#otherComp').val('');
        }
    });

    $('#budgetElseCheck').click(() => {
        $('#budgetElse').toggle();
        if ($('#budgetElse').not(':visible')) {
            $('#budgetElse').val('');
        }
    });

    $('#intResourcesCheck').click(() => {
        if ($('#intResourcesCheck').is(':checked')) {
            $('#intResources option[value="true"]').attr('selected', 'selected');
            $('#intResources option[value="false"]').removeAttr('selected');
        } else {
            $('#intResources option[value="false"]').attr('selected', 'selected');
            $('#intResources option[value="true"]').removeAttr('selected');
        }
    });

    $('#doNothingCheck').click(() => {
        if ($('#doNothingCheck').is(':checked')) {
            $('#doNothing option[value="true"]').attr('selected', 'selected');
            $('#doNothing option[value="false"]').removeAttr('selected', '');
        } else {
            $('#doNothing option[value="false"]').attr('selected', 'selected');
            $('#doNothing option[value="true"]').removeAttr('selected');
        }
    });
});