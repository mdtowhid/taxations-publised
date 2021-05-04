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
    //const roundNumber = num => Math.round(num);


    //function deemedFurniture(num) {}
       
    //Step 3...
    $("#BasicPayAmountId").change(function (e) {
        let amount = +$(this).val();
        $("#BasicPayTaxExemptedId").val("0");
        basicPayTaxableId.val(Math.round(amount));
        basicPayTaxableAmount = amount;

        //if (houseRentByOffice === "Yes")
        //    deemedFurniture(0);
        if (houseRentByOffice === "No") {
            $('#DeemedIncomeFurnishedTaxable').val(0);
        }
    });

    //Step 4...
    $("#SpecialPayAmountId").change(function (e) {
        let amount = +$(this).val();
        $("#SpecialPayTaxExemptedId").val("0");
        specialPayTaxableId.val(roundNumber(amount));
    });

    //Step 5...
    $("#ArrearPayAmountId").change(function (e) {
        let amount = $(this).val();
        $("#ArrearPayTaxExemptedId").val("0");
        arrearPayTaxableId.val(roundNumber(amount));
    });

    //Step 6...
    $("#DearnessAllowanceAmountId").change(function (e) {
        let amount = $(this).val();
        $("#DearnessAllowanceTaxExemptedId").val("0");
        dearnessAllowanceTaxableId.val(roundNumber(amount));
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
        //roundNumber()
        if (houseRentAllowanceAmount > res1)
            $('#HouseRentAllowanceTaxExemptedId').val(roundNumber(res1));
        else if (res1 > houseRentAllowanceAmount)
            $('#HouseRentAllowanceTaxExemptedId').val(roundNumber(houseRentAllowanceAmount))



        let result = houseRentAllowanceAmount - +$('#HouseRentAllowanceTaxExemptedId').val();
        $('#HouseRentAllowanceTaxableId')
            .val(roundNumber(result));
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
            $('#MedicalAllowanceTaxExemptedId').val(roundNumber(res1));
        } else if (amount < res1) {
            $('#MedicalAllowanceTaxExemptedId').val(roundNumber(amount));
        }

        let result = amount - +$('#MedicalAllowanceTaxExemptedId').val();
        $('#MedicalAllowanceTaxableId').val(roundNumber(result));
    });

    //Step 9...
    $("#ConveyanceAllowanceAmount").change(function (e) {
        let amount = +$(this).val();
        const fixedExempted = 30000;
        if (amount > fixedExempted)
            $('#ConveyanceAllowanceTaxable').val(roundNumber(amount - fixedExempted));
        else
            $('#ConveyanceAllowanceTaxable').val(0);
    });

    //Step 10...
    $("#FestivalAllowanceAmount").change(function (e) {
        let amount = $(this).val();
        $("#FestivalAllowanceTaxExempted").val("0");
        $('#FestivalAllowanceTaxable').val(roundNumber(amount));
    });

    //Step 11...
    $("#AllowanceStaffAmount").change(function (e) {
        let amount = $(this).val();
        $("#AllowanceStaffTaxExempted").val("0");
        allowanceStaffTaxable.val(roundNumber(amount));
    });

    //Step 12...
    $("#LeaveAllowanceAmount").change(function (e) {
        let amount = +$(this).val();
        $("#LeaveAllowanceTaxExempted").val("0");
        leaveAllowanceTaxable.val(roundNumber(amount));
    });

    //Step 13...
    $("#HonorariumAmount").change(function (e) {
        let amount = $(this).val();
        $("#HonorariumTaxExempted").val("0");
        honorariumTaxable.val(roundNumber(amount));
    }
    )
});

//Step 14...
$("#OvertimeAllowanceAmount").change(function (e) {
    let amount = $(this).val();
    $("#OvertimeAllowanceExempted").val("0");
    $('#OvertimeAllowanceTaxable').val(roundNumber(amount));
});

//Step 15...
$("#BonusAmount").change(function (e) {
    let amount = $(this).val();
    $("#BonusExempted").val("0");
    $('#BonusTaxable').val(roundNumber(amount));
});

//Step 16...
$("#OtherAllowancesAmount").change(function (e) {
    let amount = $(this).val();
    $("#OtherAllowancesExempted").val("0");
    $('#OtherAllowancesTaxable').val(roundNumber(amount));
});

//Step 17...
$("#EmployerContributionAmount").change(function (e) {
    let amount = $(this).val();
    $("#EmployerContributionExempted").val("0");
    $('#EmployerContributionTaxable').val(roundNumber(amount));
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
    $('#InterestAccruedTaxable').val(roundNumber(subs));
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


//deemedFurniture(0);

//Step 21...
$("#OtherIfAnyAmount").change(function (e) {
    let amount = $(this).val();

    $("#OtherIfAnyExempted").val("0");
    $('#OtherIfAnyTaxable').val(roundNumber(amount));
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
                    
                $('#total').val(roundNumber(ctotal));
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
            $('#total').val(roundNumber(ctotal));    
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
        $('#TotalTaxExempted').val(roundNumber(taxExamptedPrevValue));
    else
        $('#TotalTaxExempted').val(roundNumber(bsum));
}

bTotal(true);


const atotal = () => {
    let t = 0;
    $('.a').each((i, el) => {
        t += +$(el).val();
    });
    $('#amountTotal').val(roundNumber(t));
}

atotal();

$('.a').each((i, el) => {
    $(el).change(() => {
        atotal();
    })
});


function roundNumber(num) { return Math.round(num) }


