$(document).ready(function() {

var input1,
	input2,
	input3,
	input4,
	input5;



 	$('#button').click(function(event) {
 	 event.preventDefault();




	input1 = $('#first').val();
	input2 = $('#second').val();
	input3 = $('#third').val();
	input4 = $('#fourth').val();
	input5 = $('#fifth').val();


	if ($.isNumeric(input1), $.isNumeric(input2), $.isNumeric(input3), $.isNumeric(input4), $.isNumeric(input5)) { 
			
			input1 = parseInt(input1);
			input2 = parseInt(input2);
			input3 = parseInt(input3);
			input4 = parseInt(input4);
			input5 = parseInt(input5);

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
			alert("Those aren't pillows!");
		}


	




		// console.log(answer3);
		// console.log(answer4);
		// console.log(answer1);
		// console.log(answer5);
		// console.log(answer2);
	});



});