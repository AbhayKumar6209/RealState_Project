// Quarter Engineer



$(document).ready(function () {
	$('#fullPayment').hide();
	$('#emiPayment').hide();
	$('#_paymodeBank').hide();
	$('#_paymodeCard').hide();
});

function _plantype(element) {
	var _type = element.value.toUpperCase();
	if (_type == 'FULL PAYMENT') {
		$('#fullPayment').show();
		$('#emiPayment').hide();
	}
	else if (_type == "EMI PLAN") {
		$('#fullPayment').hide();
		$('#emiPayment').show();
	}
}

function _payMode(element) {
	var _mode = element.value.toUpperCase();
	if (_mode == 'CHEQUE' || _mode == 'DD' || _mode == 'NEFT/RTGS' || _mode == 'CASH CREDIT IN A/C') {
		$('#_paymodeBank').show();
		$('#_paymodeCard').hide();
	}
	else if (_mode == 'CARD') {
		$('#_paymodeBank').hide();
		$('#_paymodeCard').show();
	}
}


$(document).ready(function () {
	$('#plotTransferDiv').hide();
	$('#transButtons').hide();
	$('#bookingId').change(function () {
		if (this.value != '' && this.value != null && this.value != ' ') {
			$('#plotTransferDiv').show();
			$('#transButtons').show();
		}
		else {
			$('#plotTransferDiv').hide();
			$('#transButtons').hide();
		}
	});
});






