
$(() => {
    const EligibleAmountForRebate = $('#EligibleAmountForRebate');
    const TotalAllowableInvestmentContribution = $('#TotalAllowableInvestmentContribution');
    const TotalIncome14B = $('#TotalIncome14B');
    const Crore14C = $('#Crore14C');
    const AmountOfTaxRebateCalculated = $('#AmountOfTaxRebateCalculated');

    const particularsOfIncomeFromSlariesTotal = $('#particularsOfIncomeFromSlariesTotal');

    const calculatePercentage = (amount, percentage) =>
        +(percentage / 100) * amount;


    

    function setDefault() {
        if (particularsOfIncomeFromSlariesTotal === null)
            window.location.href = '/incometax/totalIncome/';
        else
            TotalIncome14B.val(
                Math.ceil(calculatePercentage(+particularsOfIncomeFromSlariesTotal.text().trim(), 25))
            );
        defaultSetter();
    }
    setDefault();

    function defaultSetter() {
        let taiContribution = +TotalAllowableInvestmentContribution.val();
        let ti14B = +TotalIncome14B.val();
        let crore14C = +Crore14C.val();

        //checking 14A, 14B, 14C

        if ((taiContribution === '' && !isNaN(+taiContribution))
            || (ti14B === '' && !isNaN(+ti14B))
            || (crore14C === '' && !isNaN(+crore14C))) {
        }
        else {
            setTimeout(() => {
                let temp = 0;
                if (taiContribution < ti14B && taiContribution < crore14C)
                    temp = taiContribution;
                else if (ti14B < taiContribution && ti14B < crore14C)
                    temp = ti14B;
                else
                    temp = crore14C;
                //EligibleAmountForRebate.val(temp);
                let v = calculatePercentage(temp, 15);
                $('#AmountOfTaxRebateCalculated').val(Math.ceil(v));
            }, 100);
        }
    }



    //FOR 13 COLUMN = 3 + TO + 13 +
    let tmg = 0;
    //$('input.a').each((i, el) => {
    //    setTimeout(e => {
    //        tmg += +$(el).val();
    //        $('#TotalAllowableInvestment').val(tmg);
    //        $('#TotalAllowableInvestmentContribution').val(tmg);
    //    }, 50);

    //    $(el).change(() => {
    //        let tm = 0;
    //        setTimeout(() => {
    //            $.each($('input.a'), (j, v) => {
    //                tm += +$(v).val();
    //            });
    //            $('#TotalAllowableInvestment').val(tm);
    //            $('#TotalAllowableInvestmentContribution').val(tm);
    //        }, 70);
    //    });
    //});
    function calcTotalFor13() {
        $('input.a').each((i, el) => {
            setTimeout(e => {
                tmg += +$(el).val();
                $('#TotalAllowableInvestment').val(tmg);
                $('#TotalAllowableInvestmentContribution').val(tmg);
            }, 50);

            $(el).change(() => {
                let tm = 0;
                setTimeout(() => {
                    $.each($('input.a'), (j, v) => {
                        tm += +$(v).val();
                    });
                    $('#TotalAllowableInvestment').val(tm);
                    $('#TotalAllowableInvestmentContribution').val(tm);
                }, 70);
            });
        });
    }

    calcTotalFor13();


    //5-2-2021


    $('input').each((i, input) => {
        $(input).change(() => {
            setTimeout(() => {
                let x = +$('#TotalAllowableInvestmentContribution').val();
                let y = +$('#TotalIncome14B').val();
                let z = +$('#Crore14C').val();
                let min = Math.min(x, y, z);

                let a = calculatePercentage(min, 15);
                $('#EligibleAmountForRebate').val(min);
                $('#AmountOfTaxRebateCalculated').val(Math.ceil(a));
            }, 1000)
        })
    })
});