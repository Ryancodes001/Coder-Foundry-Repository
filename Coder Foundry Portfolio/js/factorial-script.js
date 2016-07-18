$(document).ready(function() {


var inputValue;



$('#factorialButton').click(function(event) {
 	 event.preventDefault();

	inputValue = $('#factorialInput').val()
 	


var answer= inputValue;

for (var i = inputValue; i > 1; i--) { 
	answer = answer * (i -1);
	
}
   


$('#factorialOutput').append(answer);



		});

	});

