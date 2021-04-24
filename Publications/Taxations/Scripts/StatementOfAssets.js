$(() => {
    
    const AgriculturalProperty07 = $('#AgriculturalProperty07');
    const FinancialAssetsValue08 = $('#FinancialAssetsValue08');
    const GoldDiamond10 = $('#GoldDiamond10');
    const FurnitureEquipmentAndElectronicItems11 = $('#FurnitureEquipmentAndElectronicItems11');
    const OtherAssetsOfSignificantValue12 = $('#OtherAssetsOfSignificantValue12');
    const CashAndFundOutsideBusiness = $('#CashAndFundOutsideBusiness');
    const GrossWealth14 = $('#GrossWealth14');
    const LiabilitiesButsideBusines15 = $('#LiabilitiesButsideBusines15');
    const NetWealth16 = $('#NetWealth16');
    const NetWealth17 = $('#NetWealth17');
    const ChangeIn18 = $('#ChangeIn18');
    const OtherFundOutflow19 = $('#OtherFundOutflow19');
    const TotalFundOutflow20 = $('#TotalFundOutflow20');
    const ShortageOfFund22 = $('#ShortageOfFund22');
    let values = [];

    //sp=special add
    function spAdd(params) {
        let { left, right } = params;
        let x = +left.val();
        let y = +right.val();
        let r = 0;
        if (x >= 0 && y > 0)
            r = x + y;
        if (r > 0)
            left.val(r);
    }

    $('.sp-7').change(e => spAdd({ left: $('#AgriculturalProperty07'), right: $('.sp-7') }));

    $('.sp-10').change(e => spAdd({ left: $('#GoldDiamond10'), right: $('.sp-10') }));

    $('.sp-11').change(e => spAdd({ left: $('#FurnitureEquipmentAndElectronicItems11'), right: $('.sp-11') }));

    $('.sp-12').change(e => spAdd({ left: $('#OtherAssetsOfSignificantValue12'), right: $('.sp-12') }));

    $('.sp-14').change(e => spAdd({ left: $('#GrossWealth14'), right: $('.sp-14') }));

    $('.sp-16').change(e => spAdd({ left: $('#NetWealth16'), right: $('.sp-16') }));

    $('.sp-17').change(e => spAdd({ left: $('#NetWealth17'), right: $('.sp-17') }));

    const eachFieldAdder = (elemRef, prevInfoElemRef) => {
        let prevInfoStatus = prevInfoElemRef ?? false;

        let t = 0;

        $.each($(elemRef), (i, v) => {
            t += +$(v).val();
        });

        if (prevInfoStatus)
            t += +prevInfoElemRef.val();

        aggregate5to13();
        return t;
    }

    $('#prevCardWrap input:not(.sp-7, .sp-10, .sp-11, .sp-12, .sp-14, .sp-16, .sp-17)').each((i, inp) => {
        $(inp).attr('readonly', false);
        $(inp).attr('type', 'number');
        $(inp).change(e => {
            console.log(inp)
            const params = {
                id: $(inp).attr('id'),
                value: $(inp).val(),
            };

            prevYearInputChange(params);
        });
    });

    function prevYearInputChange(params) {
        let { id, value } = params;
        let total = 0;
        let p = $(`.${id.replace('Prev', '_Prev')}`);
        let pt = $(`.${id.replace('Prev', '_Prev_Total')}`);
        p.each((i, j) => {
            let jVal = $(j).val();
            if (jVal.length > 0) {
                total += +jVal;
            }
        });

        if (total > 0) {
            total += +value;
        }

        $(pt).val(total);
        return;
    }


    //FOR NET WEALTH 14-15
    const setNetWealth14Minus15 = () => NetWealth16.val(+GrossWealth14.val() - +LiabilitiesButsideBusines15.val());

    // FOR Change in net wealth (16-17) = 18
    // const setNetWealth16Minus17 = () => ChangeIn18.val(+NetWealth16.val() - +NetWealth17.val());
    const setNetWealth16Minus17 = () =>
        ChangeIn18.val($('#netWealth16Prev') !== null ? $('#netWealth16Prev').val() : 0);

    // FOR Total fund outflow in the income year (18+19)
    const totalFund18Plus19 = () => TotalFundOutflow20.val(+ChangeIn18.val() + +OtherFundOutflow19.val());

    // Shortage of fund, if any (21-20) = 22
    const shortageOfFund21Minus20 = () => {
        setTimeout(e => {
            let a = +$('#TotalFundOutflow20').val();
            let b = +$('#SourcesOfFund21').val();
            let t = b - a;
            (t === 1) ?
                $('#ShortageOfFund22').val(0) : $('#ShortageOfFund22').val(t);
        }, 200);
    };

    shortageOfFund21Minus20();

    //FOR NET WEALTH 5-13
    function aggregate5to13() {
        setTimeout(() => {
            let t = +$('#BusinessCapital').val() +
                +$('#TotalOf06A06B').val() +
                +FinancialAssetsValue08.val() +
                +GoldDiamond10.val() +
                +AgriculturalProperty07.val() +
                +FurnitureEquipmentAndElectronicItems11.val() +
                +OtherAssetsOfSignificantValue12.val() +
                +CashAndFundOutsideBusiness.val();
            GrossWealth14.val(t);
            setTimeout(() => {
                setNetWealth14Minus15();
            }, 100);
        }, 250);


    }
    GoldDiamond10.change(e => aggregate5to13());
    AgriculturalProperty07.change(e => aggregate5to13());
    FurnitureEquipmentAndElectronicItems11.change(e => aggregate5to13());
    OtherAssetsOfSignificantValue12.change(e => aggregate5to13());


    //FOR 18
    NetWealth17.change(e => setNetWealth16Minus17());



    //for 5
    $('.5').change(e => {
        if ($('#businessCapitalPrev').val() == null || undefined) {
            $('#BusinessCapital').val(eachFieldAdder($('.5'), undefined));
        }
        else {
            $('#BusinessCapital').val(eachFieldAdder($('.5'), $('#businessCapitalPrev')));
        }
    });

    //for 6
    $('.6').change(e => {
        if ($('#totalOf06A06BPrev').val() == null || undefined)
            $('#TotalOf06A06B').val(eachFieldAdder($('.6'), undefined));
        else
            $('#TotalOf06A06B').val(eachFieldAdder($('.6'), $('#totalOf06A06BPrev')));
    });

    //for 7
    $('.7').change(e => {
        if ($('#agriculturalProperty07Prev').val() == null || undefined)
            $('#AgriculturalProperty07').val(eachFieldAdder($('.7'), undefined));
        else
            $('#AgriculturalProperty07').val(eachFieldAdder($('.7'), $('#agriculturalProperty07Prev')));
    });

    //for 8
    $('.8').change(e => {
        if ($('#financialAssetsValue08Prev').val() == null || undefined)
            $('#FinancialAssetsValue08').val(eachFieldAdder($('.8'), undefined));
        else
            $('#FinancialAssetsValue08').val(eachFieldAdder($('.8'), $('#financialAssetsValue08Prev')));
    });

    //for 10
    $('.10').change(e => {
        if ($('#goldDiamond10Prev').val() == null || undefined)
            $('#GoldDiamond10').val(eachFieldAdder($('.10'), undefined));
        else
            $('#GoldDiamond10').val(eachFieldAdder($('.10'), $('#goldDiamond10Prev')));
    });

    //for 11
    $('.11').change(e => {
        if ($('#furnitureEquipmentAndElectronicItems11Prev').val() == null || undefined)
            $('#FurnitureEquipmentAndElectronicItems11').val(eachFieldAdder($('.11'), undefined));
        else
            $('#FurnitureEquipmentAndElectronicItems11').val(eachFieldAdder($('.11'), $('#furnitureEquipmentAndElectronicItems11Prev')));
    });

    //for 12
    $('.12').change(e => {
        if ($('#otherAssetsOfSignificantValue12Prev').val() == null || undefined)
            $('#OtherAssetsOfSignificantValue12').val(eachFieldAdder($('.12'), undefined));
        else
            $('#OtherAssetsOfSignificantValue12').val(eachFieldAdder($('.12'), $('#otherAssetsOfSignificantValue12Prev')));
    });

    //for 13
    $('.13').change(e => {
        if ($('#cashAndFundOutsideBusinessPrev').val() == null || undefined)
            $('#CashAndFundOutsideBusiness').val(eachFieldAdder($('.13'), undefined));
        else
            $('#CashAndFundOutsideBusiness').val(eachFieldAdder($('.13'), $('#cashAndFundOutsideBusinessPrev')));
    });

    //for 15
    $('.15').change(e => {
        if ($('#liabilitiesButsideBusines15Prev').val() == null || undefined)
            $('#LiabilitiesButsideBusines15').val(eachFieldAdder($('.15'), undefined));
        else
            $('#LiabilitiesButsideBusines15').val(eachFieldAdder($('.15'), $('#liabilitiesButsideBusines15Prev')));
    });

    //for 17
    $('.17').change(e => {
        if ($('#netWealth17Prev').val() == null || undefined)
            $('#NetWealth17').val(eachFieldAdder($('.17'), undefined));
        else
            $('#NetWealth17').val(eachFieldAdder($('.17'), $('#netWealth17Prev')));
    });






    //for 19
    $('.19').change(e => {
        $('#OtherFundOutflow19').val(eachFieldAdder($('.19'), undefined));
        //FOR 20
        totalFund18Plus19();
    });





    //for 21
    $('.21').change(e => {
        $('#SourcesOfFund21').val(eachFieldAdder($('.21'), undefined))
        //FOR 20
        totalFund18Plus19();
        shortageOfFund21Minus20();
    });


    //1/5/2021--------t-
    eachFieldAdder($('.21'), $('#sourcesOfFund21Prev'));



    function autoLoaderFor19() {
        const nineteenColumnInputs = $('.19');
        let values = 0;
        nineteenColumnInputs.each((index, element) => {
            values += +$(element).val();
        });
        $('#OtherFundOutflow19').val(values);

    }

    autoLoaderFor19();


    //for 20

    function autoLoaderFor20() {
        setTimeout(() => {
            let total = +$('#ChangeIn18').val() + +$('#OtherFundOutflow19').val();
            $('#TotalFundOutflow20').val(+total).prop('disabled', true);
        }, 100);
    }

    autoLoaderFor20();



    function autoLoaderFor21() {
        setTimeout(() => {
            $('#SourcesOfFund21').val(eachFieldAdder($('.21')));
        }, 100);
    }

    autoLoaderFor21();

    //FOR 22
    function autoLoaderFor22() {
        setTimeout(() => {
            $('#ShortageOfFund22').val(+$('#SourcesOfFund21').val() - +$('#TotalFundOutflow20').val());
        }, 100);
    }

    autoLoaderFor22();

    const inputs = $('input');

    for (let input of inputs) {

        //get previous values from form input fields;
        if ($(input).attr('type') === 'number' && $(input).val() !== '' && $(input).attr('value')) {

            //check total form field ...ShortageOfFund22
            if ($(input).attr('id') !== 'ShortageOfFund22') {
                values.push({ id: $(input).attr('id'), value: +$(input).attr('value') });
            }
        }


        $(input).change(() => {
            let changingInput = $(input);

            let id = changingInput.attr('id');
            let obj = { id, value: +$(input).val() };
            if (values.length > 0) {
                let exists = values.find(x => x.id === id);
                if (typeof (exists) === 'undefined') {
                    values.push(obj);
                } else {
                    let index = values.map(v => v.id).indexOf(id);
                    if (index > -1)
                        values[index].value = +changingInput.val();
                }
            }
            calcFor18();
            //summation();
        });

        //if ($(input).attr('type') === 'number') {
        //    $(input).change(() => {
        //        let changingInput = $(input);
        //        let id = changingInput.attr('id');
        //        let obj = { id, value: +$(input).val() };
        //        if (values.length > 0) {
        //            let exists = values.find(x => x.id === id);
        //            if (typeof (exists) === 'undefined') {
        //                values.push(obj);
        //            } else {
        //                let index = values.map(v => v.id).indexOf(id);
        //                if (index > -1)
        //                    values[index].value = +changingInput.val();
        //            }
        //        }
        //        //summation();
        //    });
        //}
    }

    //05-02-21
    //for calculate prevYear Total minus this year;
    //16-17 column
    function calcFor18() {
        setTimeout(() => {
            let x = +$('#NetWealth16').val();
            let y = +$('#NetWealth17').val();

            if (y === undefined || null)
                return;

            let r = x - y;

            //console.log(x, y, r);
            $('#ChangeIn18').val(r);
        }, 1000)
    }

    function summation() {
        let sum = 0;
        for (let i = 0; i < values.length; i++) {
            sum += +values[i].value;
        }
        ShortageOfFund22.val(sum);
    }

    if (values.length > 0)
        summation();


    $('#prevYearInfoCardHeader').click(e => { $('#prevCardWrap').slideToggle('slow'); })
});



function eachPrevAndCurrentYearTotalAddition() {
    setTimeout(() => {
        const isPrevYearInfoNotNull = ($('#prevYearInfoNotNull').val() === "prevYearInfoNotNull") ?? false;
        const isPrevYearCalculated = $('#isPrevYearCalculated').text() === 'true';
        const prevInfoesArray = ['businessCapitalPrev',
            'totalOf06A06BPrev',
            'agriculturalProperty07Prev',
            'financialAssetsValue08Prev',
            'goldDiamond10Prev',
            'furnitureEquipmentAndElectronicItems11Prev',
            'otherAssetsOfSignificantValue12Prev',
            'cashAndFundOutsideBusinessPrev',
            'grossWealth14Prev',
            'liabilitiesButsideBusines15Prev',
            'netWealth16Prev',
            'netWealth17Prev',
            'changeIn18Prev',
            'otherFundOutflow19Prev',
            'totalFundOutflow20Prev',
            'sourcesOfFund21Prev',
            'shortageOfFund22Prev'];
        let courrentInfoesArray = [];

        if (!isPrevYearInfoNotNull)
            return;
        if (isPrevYearCalculated)
            return;


        prevInfoesArray.forEach(prev => courrentInfoesArray.push(prev[0].toUpperCase()
            + prev.substr(1, prev.length).replace('Prev', '')));

        const date = new Date();
        const currYear = date.getFullYear();
        const prevAssessmentYear = +$('#prevYearInfo').text().trim();
        const AssessmentYear = +$('#AssessmentYear').val().split('-')[2];
        const boolYear1 = AssessmentYear === prevAssessmentYear;
        const boolYear = currYear === prevAssessmentYear;

        console.log(boolYear);



        for (let i = 0; i < courrentInfoesArray.length; i++) {
            let currentYearElem = $('#' + courrentInfoesArray[i]);
            let prevYearElem = $('#' + prevInfoesArray[i]);
            let total = 0;

            //skip 10, 11, 12
            // if (currentYearElem.attr('id') === 'GoldDiamond10'
            //     || 'FurnitureEquipmentAndElectronicItems11'
            //     || 'OtherAssetsOfSignificantValue12'){
            //     currentYearElem.val(0);
            //     continue;
            // }

            if (currentYearElem !== 'undefined' && prevYearElem !== 'undefined') {
                //if(boolYear)
                total = +currentYearElem.val() + +prevYearElem.val();
                currentYearElem.val(total);
            }
        }


        //5-2-2021 
        // for column 17
        //debugger

        if (AssessmentYear > prevAssessmentYear) {
            $('#NetWealth17').val($('#netWealth16Prev').val() ?? 0);
        }
    }, 400);
}

eachPrevAndCurrentYearTotalAddition();


function setStateMentAsOnDate() {
    setTimeout(() => {
        var today = new Date();
        var dd = String(today.getDate()).padStart(2, '0');
        var mm = String(today.getMonth() + 1).padStart(2, '0'); //January is 0!
        var yyyy = today.getFullYear();
        today = yyyy + '-' + mm + '-' + dd;
        $('#statementAsOn').val(today)
    }, 100);
}

setStateMentAsOnDate();

function getAssesmentAndCurrentYearInfo() {
    const assesmentYear = document.getElementById('prevYearInfo').innerText;
    const date = new Date();
    console.log(date.getFullYear());
}