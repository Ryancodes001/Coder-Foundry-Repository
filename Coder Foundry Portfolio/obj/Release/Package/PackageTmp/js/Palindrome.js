$(document).ready(function() {

	var inputString,
		reverseString;

		$('#palindromeButton').click(function(event) {
 	 event.preventDefault(); 

 	 inputString = $('#inputString').val();
 	 console.log(inputString);

 	reverseString = inputString.split("").reverse().join("");
 	

 	 if (inputString == reverseString) {
 		alert("You got a fancy Palindrome!");
 	}
 	else {
 		alert("Nice try sucka!");
 	}



 		});

	});