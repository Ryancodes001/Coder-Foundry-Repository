$(document).ready(function() {


var inputValue;



$('#button').click(function(event) {
 	 event.preventDefault();

	inputValue = $('#input').val()
 	


var answer= inputValue;

for (var i = inputValue; i > 1; i--) { 
	answer = answer * (i -1);
	
}
   


$('#output1').append(answer);



		});

	});

