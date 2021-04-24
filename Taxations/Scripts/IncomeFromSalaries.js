$(() => {
    let basicPayTaxableAmount = 0;

    const basicPayTaxableId = $('#BasicPayTaxableId');
    const specialPayTaxableId = $("#SpecialPayTaxableId");
    const arrearPayTaxableId = $("#ArrearPayTaxableId");

    const dearnessAllowanceTaxableId = $("#DearnessAllowanceTaxableId");
    const allowanceStaffTaxable = $("#AllowanceStaffTaxable");
    const leaveAllowanceTaxable = $('#LeaveAllowanceTaxable');
    const honorariumTaxable = $('#HonorariumTaxable');
    const houseRentByOffice = $('#HouseRentByOffice').val();
    function calculatePercentage(amount, percentage) {
        return +(percentage / 100) * amount;
    }
        
    //Step 3...
    $("#BasicPayAmountId").change(function (e) {
        let amount = +$(this).val();
        $("#BasicPayTaxExemptedId").val("0");
        basicPayTaxableId.val(amount);
        basicPayTaxableAmount = amount;

        if (houseRentByOffice === "Yes")
            deemedFurniture(0);
        if (houseRentByOffice === "No") {
            $('#DeemedIncomeFurnishedTaxable').val(0);
        }
    });

    //Step 4...
    $("#SpecialPayAmountId").change(function (e) {
        let amount = +$(this).val();
        $("#SpecialPayTaxExemptedId").val("0");
        specialPayTaxableId.val(amount);
    });

    //Step 5...
    $("#ArrearPayAmountId").change(function (e) {
        let amount = $(this).val();
        $("#ArrearPayTaxExemptedId").val("0");
        arrearPayTaxableId.val(amount);
    });

    //Step 6...
    $("#DearnessAllowanceAmountId").change(function (e) {
        let amount = $(this).val();
        $("#DearnessAllowanceTaxExemptedId").val("0");
        dearnessAllowanceTaxableId.val(amount);
    });


    //Step 7...
    $("#HouseRentAllowanceAmountId").change(function (e) {
        let basicPayTaxable = +$('#BasicPayTaxableId').val() * .5;
        let houseRentAllowanceAmount = +$('#HouseRentAllowanceAmountId').val();
        const yearly = 25000 * 12;
        let res1 = 0;


        if (basicPayTaxable > yearly) {
            res1 = yearly;
        } else if (basicPayTaxable < yearly) {
            res1 = basicPayTaxable;
        }

        if (houseRentAllowanceAmount > res1)
            $('#HouseRentAllowanceTaxExemptedId').val(res1);
        else if (res1 > houseRentAllowanceAmount)
            $('#HouseRentAllowanceTaxExemptedId').val(houseRentAllowanceAmount)



        let result = houseRentAllowanceAmount - +$('#HouseRentAllowanceTaxExemptedId').val();
        console.log(result);
        $('#HouseRentAllowanceTaxableId')
            .val(result);
    });

    //Step 8...

    $("#MedicalAllowanceAmountId").change(function (e) {
        let amount = +$(this).val();

        const medicalAllowanceTaxExempted = +$('#MedicalAllowanceTaxExemptedId').val();
        const basicPayTaxable = +$('#BasicPayTaxableId').val() * .10;
        const allowance = 120000;


        let res1 = 0;

        if (basicPayTaxable > allowance) {
            res1 = allowance;
        } else if (basicPayTaxable < allowance) {
            res1 = basicPayTaxable;
        }

        if (amount > res1) {
            $('#MedicalAllowanceTaxExemptedId').val(res1);
        } else if (amount < res1) {
            $('#MedicalAllowanceTaxExemptedId').val(amount);
        }

        let result = amount - +$('#MedicalAllowanceTaxExemptedId').val();
        $('#MedicalAllowanceTaxableId').val(result);
    });

    //Step 9...
    $("#ConveyanceAllowanceAmount").change(function (e) {
        let amount = +$(this).val();
        const fixedExempted = 30000;
        if (amount > fixedExempted)
            $('#ConveyanceAllowanceTaxable').val(amount - fixedExempted);
        else
            $('#ConveyanceAllowanceTaxable').val(0);
    });

    //Step 10...
    $("#FestivalAllowanceAmount").change(function (e) {
        let amount = $(this).val();
        $("#FestivalAllowanceTaxExempted").val("0");
        $('#FestivalAllowanceTaxable').val(amount);
    });

    //Step 11...
    $("#AllowanceStaffAmount").change(function (e) {
        let amount = $(this).val();
        $("#AllowanceStaffTaxExempted").val("0");
        allowanceStaffTaxable.val(amount);
    });

    //Step 12...
    $("#LeaveAllowanceAmount").change(function (e) {
        let amount = +$(this).val();
        $("#LeaveAllowanceTaxExempted").val("0");
        leaveAllowanceTaxable.val(amount);
    });

    //Step 13...
    $("#HonorariumAmount").change(function (e) {
        let amount = $(this).val();
        $("#HonorariumTaxExempted").val("0");
        honorariumTaxable.val(amount);
    }
    )
});

//Step 14...
$("#OvertimeAllowanceAmount").change(function (e) {
    let amount = $(this).val();
    $("#OvertimeAllowanceExempted").val("0");
    $('#OvertimeAllowanceTaxable').val(amount);
});

//Step 15...
$("#BonusAmount").change(function (e) {
    let amount = $(this).val();
    $("#BonusExempted").val("0");
    $('#BonusTaxable').val(amount);
});

//Step 16...
$("#OtherAllowancesAmount").change(function (e) {
    let amount = $(this).val();
    $("#OtherAllowancesExempted").val("0");
    $('#OtherAllowancesTaxable').val(amount);
});

//Step 17...
$("#EmployerContributionAmount").change(function (e) {
    let amount = $(this).val();
    $("#EmployerContributionExempted").val("0");
    $('#EmployerContributionTaxable').val(amount);
});

//Step 18...
$("#InterestAccruedAmount").change(function (e) {
    let amount = parseFloat($(this).val());
    const interestAccruedAmount = $('#InterestAccruedAmount');

    const basicPay = +$('#BasicPayTaxableId').val();
    const dearnessPay = +$('#DearnessAllowanceTaxableId').val();
    let result = (basicPay + dearnessPay) / 3;
    let interestAccruedAmountPerscentage = Math.ceil((14.5 / 100) * amount);

    let min = result < interestAccruedAmountPerscentage ? result : interestAccruedAmountPerscentage;

    $('#InterestAccruedExempted').val(min);

    let subs = Math.ceil(+interestAccruedAmount.val() - min);
    $('#InterestAccruedTaxable').val(subs);
});



//Step 19...
$("#DeemedIncomeTransportAmount").change(function (e) {
    $('#DeemedIncomeTransportTaxable').val(
        Math.round(Math.max(60000, +(5 / 100) * +$('#BasicPayTaxableId').val()))
    );

    $('#DeemedIncomeTransportExempted').val(0);
});

//Step 20...
$("#DeemedIncomeFurnishedAmount").change((e) => {
    let amount = +$("#DeemedIncomeFurnishedAmount").val();
    $('#DeemedIncomeFurnishedTaxable').val(Math.round(+(25 / 100) * +$('#BasicPayTaxableId').val()));

    $('#DeemedIncomeFurnishedExempted').val(0);
});

function deemedFurniture(amount) {
    //debugger;
    //let basicPay = +$('#BasicPayTaxableId').val();
    //let hr = $('#HouseRentByOffice').val();
    //if ((basicPay !== null || basicPay !== 'undefined') && hr !== 'No') {
    //    let basicTwentyFive = (25 / 100) * +basicPay;

    //    if (+amount <= 0 || +amount === '') {
    //        $('#DeemedIncomeFurnishedExempted').val(basicTwentyFive);
    //        $('#DeemedIncomeFurnishedTaxable').val(basicTwentyFive);
    //    } else {
    //        $('#DeemedIncomeFurnishedExempted').val('0');
    //    }
    //}
}

deemedFurniture(0);

//Step 21...
$("#OtherIfAnyAmount").change(function (e) {
    let amount = $(this).val();

    $("#OtherIfAnyExempted").val("0");
    $('#OtherIfAnyTaxable').val(amount);
});

$("#particularincomeSalariesSubmitBtn").click((e) => {
    //FOR B COLUMN
    //TAX EAXAMPTED
    let t = 0;
    $('.b').each((i, v) => {
        let val = $(v).val().trim();

        if (val.length > 0 && val !== '' && val !== '0')
            if (!isNaN(val))
                t += +val;

    });

    $('#TotalTaxExempted').val(t);

});

$("input").css("text-align", "center");

$("input").each((i, el) => {
    $(el).change(() => {
        bTotal(false);
        calculateCTotal();
    });
});

function calculateCTotal() {
    let ctotal = 0;
    let empState = $('#EmployeementStatus');
    if (empState.val().trim() === 'pvt') {
        ctotal = 0;
        $('.t').each((i, el) => {
            setTimeout(()=>{
                let val = +$(el).val();
                if (!isNaN(val))
                    ctotal += val;
                    
                $('#total').val(ctotal);
            }, 30);
                
        });
        return;
    }

    if (empState.val().trim() === 'govt') {
        $('.a').each((i, v) => {
            $(v).prop('disabled', true);
            $('#BasicPayAmountId').prop('disabled', false);
            $('#FestivalAllowanceAmount').prop('disabled', false);
            $('#BonusAmount').prop('disabled', false);
        });
        setTimeout(()=>{
            ctotal = +$('#BasicPayTaxableId').val() +
                +$('#FestivalAllowanceTaxable').val() +
                +$('#BonusTaxable').val();
            $('#total').val(ctotal);    
        }, 30);
    }
}

calculateCTotal();

//FOR column B

function bTotal(bol) {
    let bsum = 0;
    const taxExamptedPrevValue = $('#taxExamptedPrevValue').text();
    var conveyanceAllowanceTaxable = 0;
    $('.b').each((i, el) => {

        conveyanceAllowanceTaxable = +$('#ConveyanceAllowanceTaxable').val();
        let val = +$(el).val();
        if (!isNaN(val))
            bsum += val;
    });

    // console.log(bsum);

    if (bol && taxExamptedPrevValue.length > 0)
        $('#TotalTaxExempted').val(taxExamptedPrevValue);
    else
        $('#TotalTaxExempted').val(bsum);
}

bTotal(true);


const atotal = () => {
    let t = 0;
    $('.a').each((i, el) => {
        t += +$(el).val();
    });
    $('#amountTotal').val(t);
}

atotal();

$('.a').each((i, el) => {
    $(el).change(() => {
        atotal();
    })
})
