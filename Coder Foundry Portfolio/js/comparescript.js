$(document).ready(function() {

var input1,
	input2,
	input3,
	input4,
	input5;


 	$('#compareButton').click(function(event) {
 	 event.preventDefault();
    $('#error').empty();
	$('#output1').empty();
	$('#output2').empty();	
	$('#output3').empty();
	$('#output4').empty();
	$('#output5').empty();
	$('#first').empty();
	$('#second').empty();
	$('#third').empty();
	$('#fourth').empty();
	$('#fifth').empty();
	


	input1 = $('#first').val();
	input2 = $('#second').val();
	input3 = $('#third').val();
	input4 = $('#fourth').val();
	input5 = $('#fifth').val();



	if ($.isNumeric(input1)&& $.isNumeric(input2)&& $.isNumeric(input3) && $.isNumeric(input4) && $.isNumeric(input5)){

		
		 
			
			input1 = parseFloat(input1);
			input2 = parseFloat(input2);
			input3 = parseFloat(input3);
			input4 = parseFloat(input4);
			input5 = parseFloat(input5);

			

			var least =Math.min(input1, input2, input3, input4, input5);
			var greatest =Math.max(input1, input2, input3, input4, input5);
			var mean =((input1 + input2 + input3 + input4 + input5) / 5);
			var sum = (input1 + input2 + input3 + input4 + input5);
			var product = (input1 * input2 * input3 * input4 * input5);


			$('#output1').append(least);
			$('#output2').append(greatest);
			$('#output3').append(mean);
			$('#output4').append(sum);
			$('#output5').append(product);
		}

	else {
			$('#error').append("<font color='blue'> Please enter 5 numbers</font>");
		};


		


 		});


 
	
	


	
	});






