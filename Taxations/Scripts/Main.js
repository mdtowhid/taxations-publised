


setTimeout(() => {
    const cancelSubmittingStatus = document.querySelector('#cancelSubmittingStatus');
    if (cancelSubmittingStatus != null) {
        cancelSubmittingStatus.addEventListener("click", e => {
            document.querySelector('#submittingStatus').classList.add('d-none');
        });
    }
}, 2000);

$(document).ready(function () {
    $('.left-menu > div > a').each(function() {
        if ("http://localhost:1940" + $(this).attr('href') == window.location.href) {
            $(this).addClass('active');
        }
    });

    $('a').each(function() {
        if ("http://localhost:1940" + $(this).attr('href') == window.location.href) {
            $(this).addClass('active');
        }
    });


    $(window).scroll(()=> {
        ($(window).scrollTop() > 100)
            ? $('#progressId').addClass('shrink')
            : $('#progressId').removeClass('shrink');
    });


    $('#help').click(() => {
        $('#help').toggleClass('active');
        $('#helpDetails').toggleClass('active');
    });

    let highlightMenuItem = element => {
        if (element.attr('href') == location.pathname) {
            element.addClass('active');
        }
    }

    $('ul li a').each(function (e) {
        highlightMenuItem($(this));
    });

    

    $('#userMenu img').mouseover(function () {
        $('#userProfileDropDownWrapper').addClass('active');
    });

    $(window).click(function (e) {
        if (!(e.target.classList == $('#userProfileDropDownWrapper').attr('class'))) {
            $('#userProfileDropDownWrapper').removeClass('active');
        }
    });


    const fileControls = $('input[type="file"]');

    fileControls.each((i, fileControl) => {
        $(fileControl).change(e => {
            $(fileControl).next().text(e.target.files[0].name);
        });
    });
    
    if(window.innerHeight < 900){
        $('#footer').css({
            // 'marginTop': 500+'px'
        });
    }

    $('form').each((i, el) => {
        $(el).attr('autocomplete', 'off');
    })
});


