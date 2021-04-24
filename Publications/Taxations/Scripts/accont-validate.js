$(() => {
    let employmentStatusError = $('#EmploymentStatusError');
    $('#EmploymentStatus').change(function () {
        employmentStatus();
    });

    $('input[type="submit"]').click(() => {
        employmentStatus();
    });

    let employmentStatus = () => {
        let optionText = $('#EmploymentStatus option:selected').val();
        if (optionText == 'none') {
            employmentStatusError.text('Please Select Employment Status');
            return false;
        } else {
            employmentStatusError.text('');
        }
    }
});