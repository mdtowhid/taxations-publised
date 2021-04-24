// import { grandTotal } from '../../Scripts/TotalIncome.js';
// const totalIncome = grandTotal();


 console.log('from surcharge!');

const totalAssets = +$('#totalAssets').text().trim();
let percent = 0;
let surcharge = 0;

// //const totalIncome = +$('#totalIncome').text().trim();

// const calculatePercentage = (amount, percentage) =>
//     +(percentage / 100) * amount;

// const threeCrore = 30000000;
// const fiveCrore = 50000000;
// const tenCrore = 100000000;
// const fifteenCrore = 150000000;
// const twentyCrore = 200000000;
// let template = ``;
// let res = 0;

//2706155
function surchargeCalculation() {

    if(totalAssets < 30000000)
        return;

    if(totalAssets === 30000000){
        console.log('1nd');
        surcharge = 0;
        return;
    }

    if(totalAssets >= 30000000 && totalAssets < 50000000){
        console.log('2nd');
        surcharge = (10/100)*totalIncome;
        percent = 10;
        if(surcharge > 30000)
            surcharge = 30000;
        return surcharge;
    }

    if(totalAssets >= 50000000 && totalAssets < 100000000){
        console.log('3nd');
        surcharge = (15/100)*totalIncome;
        percent = 15;
        if(surcharge > 30000)
            surcharge = 30000;
        return surcharge;
    }

    if(totalAssets >= 100000000 && totalAssets < 150000000){
        console.log('4d');
        surcharge = (20/100)*totalIncome;
        percent = 20;
        console.log(surcharge);
        if(surcharge > 50000)
            surcharge = 50000;
        console.log(surcharge);
        
        return surcharge;
    }

    if(totalAssets >= 150000000 && totalAssets < 200000000){
        console.log('5d');
        surcharge = (25/100)*totalIncome;
        percent = 25;
        if(surcharge > 50000)
            surcharge = 50000;
        return surcharge;
    }

    if(totalAssets > 200000000){
        console.log('6nd');
        surcharge = (30/100)*totalIncome;
        percent = 30;
        if(surcharge > 50000)
            surcharge = 50000;
        return surcharge;
    }


}
surchargeCalculation();

setTimeout(() => {
    $('#NetWealthSurcharge').val(surcharge)
    console.log('surcharge % is '+ percent);
}, 200);


// export const exportSurcharge = surchargeCalculation();

// template = `
//             <span>Total Asset ${totalAssets}</span>
//             | <span>Surcharge Rate: ${percent}%</span>
//             | <span>Minimum Surcharge ${Math.ceil(surcharge)}</span>
//         `;
// $('#grandTotal').html(template).addClass('font-weight-bolder alert alert-success');

// $(e=>{
//     setTimeout(() => {
//         let model={
//             UserId: $('#userId').val(),
//             SurchargeValue: surcharge,
//             SurchargePercentage: percent
//         };
        
//         $.post('/incomeTax/AddSurcharge/', { model }, data=>{
//             if(data!=null)
//                 console.log(data);
//         });
//     }, 2000);
// })