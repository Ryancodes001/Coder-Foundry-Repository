$(document).ready(function() {


var inputValue;



$('#factorialButton').click(function(event) {
 	 event.preventDefault();

	inputValue = $('#factorialInput').val();
	// $('#factorialInput').empty();
	$('#factorialOutput').empty();
 	


var answer= inputValue;

if ($.isNumeric(inputValue)) {
	for (var i = inputValue; i > 1; i--) { 
	answer = answer * (i -1);
	}
   
}

else {
	$('#factorialOutput').append("<font color='red'> Please enter a number--Controllers Render Views!</font>");
}

$('#factorialOutput').append(answer);





		});

	});

