$(document).ready(function() {

	var inputString,
		reverseString;

		$('#palindromeButton').click(function(event) {
 	 event.preventDefault(); 
 	 $('#palindromeOutput').empty();

 	 inputString = $('#inputString').val().toLowerCase();
 	 
 	 inputString = inputString.replace(/[^a-z0-9]/g, '');

 	 

 	reverseString = inputString.split("").reverse().join("");
 	

 	 if (inputString == reverseString) {
 		$('#palindromeOutput').append("You've got a fancy Palindrome!");
 	}
 	else {
 		$('#palindromeOutput').append("Ah Ah Ah-You didin't say the magic word-Ah Ah Ah");
 	}



 		});

	});