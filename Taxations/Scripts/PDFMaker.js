function getPDF(filename) {
	var HTML_Width = $("#downloadWrapper").width();
	var HTML_Height = $("#downloadWrapper").height();
	var top_left_margin = 15;
	var PDF_Width = HTML_Width + (top_left_margin * 2);
	var PDF_Height = "1429"; //(PDF_Width * 2.5) + (top_left_margin * 2);
	var canvas_image_width = HTML_Width;
	var canvas_image_height = HTML_Height;

	var totalPDFPages = Math.ceil(HTML_Height / PDF_Height) - 1;


	html2canvas($("#downloadWrapper")[0], { allowTaint: true }).then(function (canvas) {
		canvas.getContext('2d');

		console.log(canvas.height + "  " + canvas.width);

		var imgData = canvas.toDataURL("image/jpeg", 1.0);
		var pdf = new jsPDF('p', 'pt', [PDF_Width, PDF_Height]);
		pdf.addImage(imgData, 'JPG', top_left_margin, top_left_margin, canvas_image_width, canvas_image_height);


		for (var i = 1; i <= totalPDFPages; i++) {
			pdf.addPage(PDF_Width, PDF_Height);
			pdf.addImage(imgData, 'JPG', top_left_margin, -(PDF_Height * i)
				+ (top_left_margin * 4), canvas_image_width, canvas_image_height);
		}

		pdf.save(filename + ".pdf");
	});
};