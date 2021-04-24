$(() => {
    const calcBtn = $('#calcBtn');
    const operands = $('.operands');
    const operators = $('.operators');
    const calcResult = $('#calcResult');
    const inputNumbers = $('#inputNumbers');
    const equalTo = $('#equalTo');
    const result = $('#result');
    const calcHistory = $('#calcHistory');
    let number = '';
    let operatorClicked = false;
    let clickedOperator = '';
    let splitterArray = [];
    let total = 0;
    let ans = 0;


    //THE CALCULATIONS
    const calculation = (numbArray) => {
        if (clickedOperator !== '') {
            //Addition
            if (clickedOperator === "+")
                for (const numb of numbArray)
                    total += +numb;
            //Substraction
            if (clickedOperator === "-")
                total = numbArray[0] - numbArray[1];
            //Multiplication
            if (clickedOperator === "*")
                total = numbArray[0] * numbArray[1];
            //Divide
            if (clickedOperator === "/")
                total = numbArray[0] / numbArray[1];

            result.text(total);
            calcHistory.text(numbArray[0] + ` ${clickedOperator} ` + numbArray[1] + ` = `);
            splitterArray = [];
            total = 0;
            ans = total;
        }
    }

    //EACH OPERENDS
    $.each(operands, (i, operand) => {
        $(operand).click(() => {
            number += $(operand).text();
            inputNumbers.text(number);
        });
    });

    //EACH OPERATORS...
    $.each(operators, (i, operator) => {
        $(operator).click(() => {
            const operatorText = $(operator).text();
            if (inputNumbers.text().length > 0 && !operatorClicked) {
                number += operatorText;
                inputNumbers.text(number);
                operatorClicked = true;
            }
        });
    });

    //EQUL BUTTON HANDLER
    equalTo.click(() => {
        splitter();
        calculation(splitterArray);
    });

    //SPLIT THE USER INUTS DATA
    function splitter() {
        const inputValues = inputNumbers.text();
        splitterArray = inputValues.split("+");

        if (splitterArray.length > 1)
            clickedOperator = '+';
        else {
            splitterArray = inputValues.split('-');
            if (splitterArray.length > 1)
                clickedOperator = '-';
            else {
                splitterArray = inputValues.split('*');
                if (splitterArray.length > 1)
                    clickedOperator = '*';
                else {
                    splitterArray = inputValues.split('/');
                    if (splitterArray.length > 1)
                        clickedOperator = '/';
                }
            }
        }
    }

    //BUTTON CAL OPENER
    calcBtn.click(() => $('.calc-wrapper').toggleClass('active'));
    //BUTTON CAL CLOSER
    $('.calc-menu').click(e => $('.calc-wrapper').removeClass('active'));

    //CANCEL BUTTON
    $('.calc-clear').click(e => {
        number = '';
        inputNumbers.text('0');
        operatorClicked = false;
        result.text(0);
        $('#equalTo').prop('disabled', false);

    });
});