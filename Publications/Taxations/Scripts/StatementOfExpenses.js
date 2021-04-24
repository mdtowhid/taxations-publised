$(() => {

    const totalFor12 = () => {
        let t = 0;
        setTimeout(e => {
            $('.t').each((i, el) => t += +$(el).val());
            $('#TotalExpenseRelating').val(t);
        }, 200);
    };
    totalFor12();


    const totalFor14 = () => {
        setTimeout(e => {
            let a = +$('#TotalExpenseRelating').val();
            let b = +$('#PaymentOfTax13A13B').val();
            $('#TotalAmountOfExpense').val(a + b);
            $('#total').val(a + b);
        }, 200);
    }
    totalFor14();


    $('#HousingExpense').change(e => totalFor12());
    $('#AnyOtherExpenses').change(e => totalFor12());



    //FOR 7
    $('.7').each((i, el) => {
        $(el).change(() => {
            let t = 0;
            $.each($('.7'), (i, v) => t += +$(v).val());
            $('#AutoAndTransportationExpenses07A08B').val(t);
            totalFor12();
            totalFor14();
        });
    });

    //FOR 8
    $('.8').each((i, el) => {
        $(el).change(() => {
            let t = 0;
            $.each($('.8'), (i, v) => t += +$(v).val());
            $('#HouseholdAndUtilityExpenses08A08B08C08D').val(t);
            totalFor12();
            totalFor14();
        });
    });

    //FOR 10
    $('.10').each((i, el) => {
        $(el).change(() => {
            let t = 0;
            $.each($('.10'), (i, v) => t += +$(v).val());
            $('#SpecialExpenses10A10B10C10D').val(t);
            totalFor12();
            totalFor14();
        });
    });

    //FOR 13
    $('.13').each((i, el) => {
        $(el).change(() => {
            let t = 0;
            $.each($('.13'), (i, v) => t += +$(v).val());
            $('#PaymentOfTax13A13B').val(t);
            totalFor12();
            totalFor14();
        });
    });
});