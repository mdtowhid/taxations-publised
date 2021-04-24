// const incomeTaxTable = $('#incomeTaxTable');
export const allowanceForMale = 250000;
export const allowanceForFemale = 300000;
export const gender = $("#gender").text().toLowerCase().trim();
// export const totalIncome = +$("#totalIncome").text();
export const totalIncome = +$("#total").val();
export const autistic = $("#autistic").text().toLowerCase().trim();



let total = 0;
export let taxableInfoes = [];
let taxableIncomeTaxes = [];
let taxableAmount = 0;

const fredomFighter = "A gazetted war-wounded freedom fighter";
const withDisability = "A person with disability";
const aged = "Aged 65 years or more";
const parentLegalDisability = "A parent/legal guardian of a personwith disability";

const tickedOnBoxes = $('#tickedOnBoxes').text().trim().split(',');

console.log("----",totalIncome, gender, autistic, tickedOnBoxes);


const calculatePercentage = (amount, percentage) =>
    +(percentage / 100) * amount;

export const ageCalculation = () =>{
    let input = $('#DateOfBirth').val();
    var dob = new Date(input);
    var today = new Date();
    var age = Math.floor((today - dob) / (365.25 * 24 * 60 * 60 * 1000));
    return age;
}


export const getTaxableAmount = () => {
    let calculateAge = ageCalculation();
    if(tickedOnBoxes.length === 0){   
        console.log('first condition');
        if (gender === "male" ||  calculateAge>= 65)
            taxableAmount = totalIncome - allowanceForMale;
        else if (gender === "female" || calculateAge >= 65)
            taxableAmount = totalIncome - allowanceForFemale;
    }

    if(gender === 'male' || gender === 'female'){
        for(let i = 0;i < tickedOnBoxes.length;i++){
            if(tickedOnBoxes[i] === fredomFighter){
                console.log('2nd condition');
                taxableAmount = totalIncome - 425000;
            }

            if(tickedOnBoxes[i] === withDisability){
                console.log('3rd condition');
                taxableAmount = totalIncome - 400000;
            }

            //age
            if(tickedOnBoxes[i] === aged || calculateAge >= 65){
                console.log('4th condition');
                taxableAmount = totalIncome - 3000000;
            }

            if(tickedOnBoxes[i] === parentLegalDisability){
                console.log('5th condition');
                if(calculateAge < 65){
                    if(gender==='male'){
                        taxableAmount = totalIncome - 300000;
                    }
                    if(gender==='female'){
                        taxableAmount = totalIncome - 350000;
                    }
                }else if(calculateAge >= 65){
                    taxableAmount = totalIncome - 350000;
                }
                
            }
            
        }
    }

    console.log(taxableAmount)
    return taxableAmount;
}
getTaxableAmount();

const calculation = (amount, percent) => {
    let netTax = calculatePercentage(amount, percent);
    taxableInfoes.push(netTax);

    taxableIncomeTaxes.push({
        TaxableIncome: amount,
        TaxRate: percent,
        NetTax: netTax
    });

}

const taxableInfoBuilder = () => {
    let remaining = taxableAmount - 400000;
    let a = (taxableAmount - 400000) > 0 ? true : false;
    let b = (taxableAmount - 500000) > 0 ? true : false;
    let c = (taxableAmount - 600000) > 0 ? true : false;
    let d = (taxableAmount - 3000000) > 0 ? true : false;
    let e = (remaining < 0) ? true : false;
    let temp = 0;

    if (!a)
        calculation(taxableAmount, 10);

    if (a) {
        calculation(400000, 10);
        temp = remaining;
        remaining -= 500000;


        if (remaining < 0) {
            calculation(temp, 15);
            temp = 0;
        }

        if (b && remaining > 0) {
            calculation(500000, 15);
            temp = remaining;
            remaining -= 600000;

            if (remaining < 0) {
                calculation(temp, 20);
                temp = 0;
            }

            if (c && remaining > 0) {
                calculation(600000, 20);
                temp = remaining;
                remaining -= 3000000;

                if (remaining < 0) {
                    calculation(temp, 25);
                    temp = 0;
                }

                if (d && remaining > 0) {
                    calculation(3000000, 25);

                    if (remaining > 0)
                        calculation(remaining, 30);
                }
            }
        }
    }

    //CALL THE SERVER AND BUILD TABLE...

    setTimeout(e => {
        postDataAndBuildTemplate();
    }, 1000);

    return taxableInfoes;
}

taxableInfoBuilder();

function postDataAndBuildTemplate() {

    console.log(taxableIncomeTaxes);
    //$.post('/incomeTax/TaxableIncomeTaxesHandler/', { models: taxableIncomeTaxes }, function (data) {
        
    //});
}


export const grandTotal = () => {
    total = 0;
    if (taxableInfoes.length > 0) {
        for (let x of taxableInfoes) {
            total += x;
        }
    }
    return (total > 0) ? total : -1;
}