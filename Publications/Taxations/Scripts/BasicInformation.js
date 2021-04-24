$(e => {
    const grossTaxBeforeTaxRebate = $('#GrossTaxBeforeTaxRebate');
    const taxRebate = $('#TaxRebate');
    const netTaxAfterTaxRebate = $('#NetTaxAfterTaxRebate');

    const twentyFourToThirtyThreeInputs = $('.24-33');
    const totalFor46 = $('.46total');
    let values1 = [];
    let values2 = [];

    function calcFor41(){
        const netTaxAfterTaxRebate = +$('#NetTaxAfterTaxRebate').val();//37
        const netWealthSurcharge = +$('#NetWealthSurcharge').val();//39
        const interestOrOrdinance = +$('#InterestOrOrdinance').val();//40TotalAmountPayable
        const totalAmountPayable = $('#TotalAmountPayable');//41
        totalAmountPayable.val(netTaxAfterTaxRebate+netWealthSurcharge+interestOrOrdinance);
    }

    function calcFor45Helper(){
        const totalAmountPayable = +$('#TotalAmountPayable').val();
        let res = 0;
        let t=0;
        $('.total414243').each((x, y)=>{
            let val = +$(y).val();
            t += val;
        });
        res = totalAmountPayable - t;
        $('#AmountPaidWithReturn').val(res>0?res:0);
        calcFor46();
    }

    function calcFor45(){
        calcFor45Helper();
        $('.total414243').each((i, el)=>{
            $(el).change(()=>{
                calcFor45Helper()
            });
        });
    }
    calcFor45();

    function calcFor46(){
        let t = 0;
        let result = 0;
        $('.46').each((x, y)=>{
            let val = +$(y).val();
            t += val;
        });

        $('#TotalAmountPaidAndAdjusted').val(t);
    }
    calcFor46();


    function calcFor47() {
        setTimeout(() => {
            let res = +$('#TotalAmountPayable').val() - +$('#TotalAmountPaidAndAdjusted').val();
            $('#DeficitOrExcess').val(res);
        }, 200);
    }
    calcFor47();


    function bootstrap() {

        let resultForTaxAfterTaxRebate = +grossTaxBeforeTaxRebate.val() - +taxRebate.val();
        if (resultForTaxAfterTaxRebate > 0) {
            netTaxAfterTaxRebate.val(resultForTaxAfterTaxRebate);
        }

        twentyFourToThirtyThreeInputs.each((i, v) => {
            $(v).attr('type', 'number')

            let id = $(v).attr('id');
            let val = +$(v).val();
            values1.push({ id, val })
            $(v).change(e => {
                val = +$(v).val();
                if (isNaN(val))
                    return;
                let exists = values1.find(x => x.id === id);
                if (typeof exists === 'undefined')
                    values1.push({ id, val });
                else {
                    let index = values1.map(v => v.id).indexOf(id);
                    if (index > -1)
                        values1[index].val = +val;
                }
                totalForValues1();
            });
        });
        totalForValues1();

        // totalFor46.each((i, v) => {
        //     $(v).attr('type', 'number')

        //     let id = $(v).attr('id');
        //     let val = +$(v).val();
        //     values2.push({ id, val })
        //     $(v).change(e => {
        //         val = +$(v).val();
        //         if (isNaN(val))
        //             return;
        //         let exists = values2.find(x => x.id === id);
        //         if (typeof exists === 'undefined')
        //             values2.push({ id, val });
        //         else {
        //             let index = values2.map(v => v.id).indexOf(id);
        //             if (index > -1)
        //                 values2[index].val = +val;
        //         }
        //         // totalForValues2();
        //     });
        // });
        // totalForValues2();


        

        setTimeout(() => {
            calcFor41();
            // calcFor45();
        }, 100);
    }

    bootstrap();

    function totalForValues1() {
        if (values1.length > 0) {
            let total = 0;
            $.each(values1, (i, v) => {
                total += v.val;
            });
            $('#TotalIncome').val(total);
        }
    }


    //5-2-2021
    //for manipulate 47 column
    $('input').each((i, v) => {
        $(v).change(() => {
            calcFor47();
        })
    })
});