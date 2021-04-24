$(() => {
    const dateOfBirth = $('#DateOfBirth');
    const dateOfBirthNextElement = dateOfBirth.next();
    const submitBtn = $('#submit');

    dateOfBirth.change(e => {
        let input = dateOfBirth.val();
        var dob = new Date(input);
        var today = new Date();
        var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
        if (age < 18) {
            dateOfBirthNextElement.html('Under 18 years').css('color', 'red');
            submitBtn.attr('disabled', true).css('cursor', 'not-allowed');
        }
        else {
            dateOfBirthNextElement.html("");
            submitBtn.attr('disabled', false).css('cursor', 'default');
        }
    });

    const nid = document.querySelector('#NID');
    const nidError = $('#nidError');

    nid.addEventListener('keyup', e => {
        let nidValue = nid.value;
        if (isNaN(nidValue)) {
            submitBtn.prop('disabled', true);
            nidError.html('This is not a valid NID number.').addClass('text-danger');
        }
        else {
            nidError.html('');
            submitBtn.prop('disabled', false);
        }
    });

    nid.addEventListener('blur', e => {
        let nidValueLength = nid.value.length;
        if (nidValueLength !== 10 && nidValueLength !== 13) {
            submitBtn.prop('disabled', true);
            nidError.html('NID number must be within 10 or 13 chracters.').addClass('text-danger');
        }
        else {
            submitBtn.prop('disabled', false);
            nidError.html('');
        }
    });
});