import * as TotalIncome from '../../Scripts/TotalIncome.js';
import * as Surcharge from '../../Scripts/Surcharge.js';

const totalIncome = TotalIncome.grandTotal();
const payableTax = $('#payableTax');
const rebateOnInvestment = $('#rebateOnInvestment');
const taxPayable = $('#taxPayable');
const surcharge = $('#surcharge');
const bySource = $('#bySource');
const bySourceBank = $('#bySourceBank');
const netPayableTax = $('#netPayableTax');

const rebateOnCalculated = $('#rebateOnCalculated').text().trim();

let calTotal = () => {
    setTimeout(() => {
        let res1 = +taxPayable.val() + +surcharge.val();
        let res2 = res1 - (+bySource.val() + +bySourceBank.val());
        console.log(res1, +taxPayable.val());
        netPayableTax.val(res2);
    }, 1000);
};

calTotal();

payableTax.val(Math.ceil(totalIncome).toFixed(2));
rebateOnInvestment.val(rebateOnCalculated);

let temp = 0;
let totalDeducted = 0;

temp = +totalIncome - +rebateOnCalculated;
taxPayable.val(Math.ceil(temp).toFixed(2));


let payableTaxPlusSurcharge = +taxPayable.val() + +surcharge.val();
netPayableTax.val(
    Math.ceil(
        +payableTaxPlusSurcharge.toFixed(2) - (+bySource.val() + +bySourceBank.val())
    ).toFixed(2)
);

const postFinalValues = () => {
    let values = {
        UserId: $('#userId').text(),
        PayableTax: payableTax.val(),
        RebateOnInvestment: rebateOnInvestment.val(),
        TaxPayable: taxPayable.val(),
        Surcharge: surcharge.val(),
        DeductedSource: bySource.val(),
        DeductedSourceBank: bySourceBank.val(),
        NetPayableTax: netPayableTax.val()
    }
    $.post('/incomeTax/AddFinalValues/', { model: values }, function (data) {
    });
};

postFinalValues();

bySource.change(e => {
    console.log('djskdj')
    totalDeducted = +bySource.val() + +bySourceBank.val();
    temp = payableTaxPlusSurcharge - totalDeducted;
    netPayableTax.val(Math.ceil(temp).toFixed(2));
    calTotal();
    postFinalValues();
});

bySourceBank.change(e => {
    totalDeducted = +bySource.val() + +bySourceBank.val();
    temp = payableTaxPlusSurcharge - totalDeducted;
    netPayableTax.val(Math.ceil(temp).toFixed(2));
    calTotal();
    postFinalValues();
});