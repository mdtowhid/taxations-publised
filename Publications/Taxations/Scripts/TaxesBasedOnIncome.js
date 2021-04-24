export const allowanceForMale = 250000;
export const allowanceForFemale = 300000;
const allowanceForAutistic = 400000;
const allowanceForgazetted = 425000;
const allowanceForLegalGardian = 10;

export const gender = $("#gender").text().toLowerCase().trim();
export const totalIncome = +$("#total").val();
export const autistic = ($("#autistic").text().toLowerCase().trim() === 'true');
const fredomFighter = "A gazetted war-wounded freedom fighter";
const withDisability = "A person with disability";
const aged = "Aged 65 years or more";
const parentLegalDisability = "A parent/legal guardian of a personwith disability";
const tickedOnBoxes = $('#tickedOnBoxes').text().trim().split(',');

export const calculatePercentage = (amount, percentage) =>
    +(percentage / 100) * amount;

export const ageCalculation = () => {
    let input = $('#DateOfBirth').val();
    var dob = new Date(input);
    var today = new Date();
    var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
    return age;
}


$('input').each((i, el) => {
    $(el).change(function () {
        setTimeout(() => {
            //console.log($("#total").val());
            calculateTaxes(+$("#total").val());
        }, 100);
    });
});

function calculateTaxes(amount){
    forMaleCalculations(amount);
    forFemaleCalculations(amount);
}

calculateTaxes(totalIncome);

function forMaleCalculations(amount){
    let taxableValue = 0;
    let tickedStatus = {};
    if(gender === 'male'){
        taxableValue = amount - allowanceForMale;
        
        if(autistic){
            taxableValue = amount - allowanceForAutistic;
        }

        if(tickedOnBoxes.length > 0 && tickedOnBoxes[0].length > 0){
            tickedStatus = getAllowanceByTickedBoxes();
            if(tickedStatus !== {})
                taxableValue = amount - tickedStatus.allowance;
            console.log(taxableValue);
        }

        if(taxableValue>0){
            const res = totalTaxCalculation(taxableValue);
            $('#grossTaxBeforeTaxRebate').val(Math.floor(res.r));
            $('#grossTaxBeforeTaxRebateMaxPercentage').val(res.maxPercentage);
        }
    }
}

function forFemaleCalculations(amount){
    let taxableValue = 0;
    let tickedStatus = {};

    if(gender === 'female'){
        taxableValue = amount - allowanceForFemale;

        if(autistic){
            taxableValue = amount - allowanceForAutistic;
        }

        if(tickedOnBoxes.length > 0 && tickedOnBoxes[0].length > 0){
            tickedStatus = getAllowanceByTickedBoxes();
            if(tickedStatus !== {})
                taxableValue = amount - tickedStatus.allowance;
            console.log(taxableValue);
        }

        if(taxableValue>0){
            const res = totalTaxCalculation(taxableValue);
            console.log(res);
            $('#grossTaxBeforeTaxRebate').val(Math.floor(res.r));
            $('#grossTaxBeforeTaxRebateMaxPercentage').val(res.maxPercentage);
        }
    }
}

function totalTaxCalculation(amount){
    let r = 0;
    let c1 = amount - 400000;
    let c2 = c1 - 500000;
    let c3 = c2 - 600000;
    let c4 = c3 - 3000000;
    let maxPercentage = 0;

    if (c1 > 0) {
        r += calculatePercentage(400000, 10);
        console.log('cat1');
        if (c2 < 0) {
            r += calculatePercentage(c1, 15);
            maxPercentage = 15;
            return { r, maxPercentage };
        }
    } else {
        r += calculatePercentage(amount, 10);
        return { r, maxPercentage: 10 };
    }

    if(c2>0){
        r += calculatePercentage(500000, 15);
        if(c3<0){
            r += calculatePercentage(c2, 20);
            maxPercentage = 20;
            return {r, maxPercentage};
        }
    }

    if(c3>0){
        r += calculatePercentage(600000, 20);
        if(c4<0){
            r += calculatePercentage(c3, 25);
            maxPercentage = 25;
            return {r, maxPercentage};
        }
    }

    if(c4>0){
        r += calculatePercentage(3000000, 25);
        r+=calculatePercentage(c4, 30);
        maxPercentage = 15;
        return {r, maxPercentage};
    }

    return { r, maxPercentage };
}

function getAllowanceByTickedBoxes(){
    for(let i = 0;i < tickedOnBoxes.length;i++){
        let allowance = 0;
        if(tickedOnBoxes[i] === fredomFighter){
            console.log('2nd condition');
            return {allowance:425000, status: 'FREEDOM_FIGHTER'};
        }

        if(tickedOnBoxes[i] === withDisability){
            console.log('3rd condition');
            return {allowance:400000, status: 'WITH_DISABILITY'};
        }

        //age
        if(tickedOnBoxes[i] === aged || ageCalculation() >= 65){
            console.log('4th condition');
            return {allowance:300000, status: 'AGED'};
        }

        if(tickedOnBoxes[i] === parentLegalDisability){
            console.log('5th condition');
            if(ageCalculation() < 65){
                if(gender==='male'){
                    allowance = 300000;
                }
                if(gender==='female'){
                    allowance = 350000;
                }
                return {allowance, status: 'MALE_OR_FEMALE_LEGAL_DISABILITY'};
            }else if(ageCalculation() >= 65){
                return {allowance:350000, status: 'MALE_OR_FEMALE_LEGAL_DISABILITY_AGED'};
            }
            
        }
        
    }
}