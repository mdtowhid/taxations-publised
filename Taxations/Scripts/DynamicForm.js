$(() => {
    $('#offBottomForm .data-indicators').height($('#offBottomForm').height());

    const dpsAddBtn = $('#dpsAddBtn');
    const dpsForm = $('#dpsForm');
    const dpsFetchedInfoes = $('#dpsFetchedInfoes');
    const dpsInfoStatus = $('#dpsInfoStatus');
    const initalBankAddingInstructions = $('#initalBankAddingInstructions');

    const formTemplate = `
                    <div class="row p-1 m-0 border mt-3 dps-form-field">
                        <span 
                              class="dps-form-field-cancel mb-2" id="cancelForm">
                            &times;
                        </span>
                        <div class="col-md-12">
                            <p class="mb-0 font-weight-bolder">Deposit Information</p>
                        </div>
                        <div class="col-md-6 m-0 p-2 p-0">
                            <input type="text" id="bankName" class="form-control bank-names" placeholder="name"/>
                        </div>
                        <div class="col-md-6 m-0 p-2 p-0">
                            <input type="number" id="amounts" class="form-control amounts" placeholder="amount"/>
                        </div>
                        
                        <div class="col-md-12">
                            <p id="error" class="alert alert-danger mr-0 mb-0 font-weight-bolder text-danger d-none">
                                Informations must be required.
                            </p>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12">
                            <button id="dpsSubmitBtn"
                                class="btn btn-md btn-outline-success mt-3">Add</button>
                        </div>
                    </div>
                `;

    const cancelDpsForm = () => {
        document.querySelector('#cancelForm').addEventListener('click', e => {
            dpsForm.empty();
            dpsAddBtn.show();
        });
    };

    const submitXHR = (formData) => {
        $.ajax({
            url: "CreateDpsInfo/ParticularsOfTaxCredit",
            type: "POST",
            data: { dpsInfo: formData },
            dataType: "json",
            success: function (data) {
                fetchDpsInfoes();
                setTimeout(() => {
                    dpsInfoStatus.html("");
                    dpsAddBtn.show();
                    dpsForm.empty();
                }, 2000);
            },
            error: function () {
                dpsInfoStatus.html("Oops! The bank name is same as prevoius one.")
                    .addClass('alert alert-warning font-weight-bolder mt-3');

                setTimeout(() => {
                    dpsInfoStatus.html("");
                    dpsAddBtn.show();
                    dpsForm.empty();
                }, 2000);
            }
        });
    };

    const submitBankInformations = () => {
        document.querySelector('#dpsSubmitBtn')
            .addEventListener('click', e => {
                const bankName = document.querySelector('#bankName').value;
                const amounts = document.querySelector('#amounts').value;
                const error = document.querySelector('#error');

                if (bankName.length <= 0 || amounts.length <= 0) {
                    error.classList.remove('d-none');
                    setTimeout(() => {
                        error.classList.add('d-none');
                    }, 3000);
                } else {
                    let obj = {
                        UserId: $('#UserId').val(),
                        BankName: bankName,
                        Amount: amounts
                    }
                    submitXHR(obj);
                }
            });
    };

    dpsAddBtn.click(e => {
        dpsAddBtn.hide();
        dpsForm.html(formTemplate);
        cancelDpsForm();
        submitBankInformations();
    });


    const deleteBankInfo = () => {
        document.querySelectorAll('.banks').forEach((el, k) => {
            let id = el.getAttribute('id');
            document.getElementById(id).addEventListener('click', e => {
                if (confirm("Want to delete this record?")) {
                    $.ajax({
                        url: "DeleteDpsInfo/ParticularsOfTaxCredit",
                        type: "POST",
                        data: { Id: id },
                        dataType: "json",
                        success: function (data) {
                            fetchDpsInfoes();
                        },
                        error: function () {

                        }
                    });
                }
            });
        });
    }

    deleteBankInfo();

    function fetchDpsInfoes() {
        const FIXED_VALUE = 60000;
        $.ajax({
            url: "DpsInfoes/ParticularsOfTaxCredit",
            type: "GET",
            dataType: "json",
            success: function (data) {
                console.log(data)
                dpsFetchedInfoes.empty();
                let infoTemplate = ``;
                if (data.length == 0) {
                    $('#ContributionToDeposit').val(0);
                    dpsFetchedInfoes
                        .text('Please add deposit information.')
                        .addClass('font-weight-bolder text-danger border shadow p-3');
                }

                if (data.length > 0) {
                    let max = data.reduce((prev, curr) => +prev.Amount > +curr.Amount ? prev : curr);
                    infoTemplate += `<hr class="m-0"/><h4 class="border-bottom p-3 text-info mb-0">Deposit Information(s)</h4>`
                    data.forEach((v) => {
                        infoTemplate += `
                                        <p class="border-bottom m-0 p-3 font-weight-bolder">
                                            ${v.BankName} | Amount: ${v.Amount}
                                            <span id="${v.Id}" class="banks float-right font-weight-bolder text-danger" style="cursor: pointer">&times;</span>
                                        </p>
                                    `;
                    });

                    dpsFetchedInfoes.html(infoTemplate).removeClass('text-danger border shadow p-3');
                    //$('#ContributionToDeposit').val(max);
                    //$('#ContributionToDeposit').val(60000);

                    let total = 0;
                    for (var i = 0; i < data.length; i++) {
                        total += +data[i].Amount;
                    }


                    if (total > FIXED_VALUE) {
                        $('#ContributionToDeposit').val(60000);
                    } else {
                        $('#ContributionToDeposit').val(total);
                    }

                    console.log(total);
                    deleteBankInfo();
                }
            }
        });
    }
    fetchDpsInfoes();

    $('#closer').click(e => initalBankAddingInstructions.css('display', 'none'));

});