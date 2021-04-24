$(e => {
    $('#colors .color').each((i, elm) => {
        $(elm).click(() => {
            let colorId = $(elm).attr('id');
            document.getElementsByTagName('body')[0].classList = '';
            $('body').addClass(colorId);
            $('#topMenu').addClass(colorId);
            $('#taxation-header').addClass(colorId);
            //$('#leftFeedsMenu').addClass(colorId);
        });
    })
});

