$(e => {
    const send = $('#send');
    const cancel = $('#cancel');
    const email = $('#email');
    const error = $('#error');

    const errorClear = () => setTimeout(() => error.fadeOut("slow"), 5000);

    send.click(e => {
        const val = email.val().toLowerCase();

        if (val.length === 0)
            error.html(`<h4 class="text-danger">Email is empty.</h4>`);

        if (val.split(".com").length === 2 && val.split("@").length === 2) {
            e.stopPropagation();
            $.ajax({
                url: '/account/GetPassword/',
                data: { email: $('#email').val() },
                dataType: 'json',
                success: (data) => {
                    if (data)
                        window.location.href = '/';
                },
                error: data => {
                    console.log(data);
                }
            });
        }


        errorClear();
    });

    cancel.click(e => {
        window.location.href = '/account/login/';
    });

});