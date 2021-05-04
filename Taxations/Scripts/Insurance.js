$(() => {
    const btnOpeInsuranceForm = $('#btnOpeInsuranceForm');
    const insuranceForm = $('#insuranceForm');
    const companyName = $('#companyName');
    const userId = $('#UserId');
    const insuraceAmount = $('#insuraceAmount');
    const insuranceBtnSubmit = $('#insuranceBtnSubmit');
    const insuranceList = $('#insuranceList');
    const insuranceError = $('#insuranceError');
    const lifeInsurance = $('#LifeInsurance');

    const getInsurances = () => {
        $.get('GetInsurances/ParticularsOfTaxCredit', (insurences, status) => {
            let template = ``;

            setTimeout(() => {
                let total = 0;
                insurences.forEach(insurance => total += +insurance.Amount);
                document.getElementById('LifeInsurance').value = total;
            }, 1000);

            if (insurences.length === 0) {
                template += `Please add insurance information.`;
                insuranceList.html(`<li class="list-group-item">${template}</li>`)
                    .addClass('text-danger font-weight-bolder');
            }

            if (status == 'success' && insurences.length > 0) {
                insurences.forEach(insurence => {
                    template += `
                       <li class="list-group-item">
                            <p class="m-0">
                                Company Name: ${insurence.CompanyName} | Amount: ${insurence.Amount}
                                <span class="deleteInsurance" id="${insurence.Id}">&times;<span>
                            </p>
                       </li> 
                    `;
                    insuranceList.html(template).removeClass('text-danger').addClass('font-weight-bolder');
                });
                deleteInsuranceInformations();
            }
        });
    }

    getInsurances();

    const deleteInsuranceInformations = () => {
        document.querySelectorAll('.deleteInsurance').forEach((el, k) => {
            let id = el.getAttribute('id');
            document.getElementById(id).addEventListener('click', e => {
                if (confirm("Want to delete this record?")) {
                    $.post('DeleteInsurance/ParticularsOfTaxCredit', { id }, (data, status) => {
                        if (data === "deleted") {
                            getInsurances();
                        }
                    });
                }
            });
        });
    }

    insuranceForm.hide();
    btnOpeInsuranceForm.click(e => insuranceForm.toggle());

    insuranceBtnSubmit.click(() => {
        let error = '';

        let obj = {
            UserId: userId.val(),
            Amount: insuraceAmount.val(),
            CompanyName: companyName.val(),
            Year: ''
        }

        console.log(obj)

        if (obj.Amount === '')
            error = 'Amount can not be empty.'

        if (obj.CompanyName === '')
            error = 'Company name can not be empty.'

        if (error) {
            insuranceError.text(error).addClass('text-danger');
            return;
        }

        $.post('SaveInsurance/ParticularsOfTaxCredit', { model: obj }, (data, status) => {
            getInsurances();

            insuraceAmount.val('');
            companyName.val('')
        });
    });


})