$(() => {
    let tinNumnerSpanText = $('#tinNumberSpanId').text();
    let elem = $('<div id="tinNumnerSpanTextId"/>');
    for (let tin of tinNumnerSpanText) {
        elem.append('<span>' + tin + '</span>');
    }
    $('#tinNumId').html(elem);
});