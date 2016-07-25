$(document).ready(function() {

$('#fizzButton').click(function(event) {
     event.preventDefault();
     $('#fizzOutput').empty();

	var input1 = $('#fizzInput1').val();
	var input2 = $('#fizzInput2').val();
       
if  (((input1 > 0) && (input1 <= 100)) && ((input2 > 0) && (input2 <= 100))) {



for (var i=1; i <= 100; i++){

   if (i % input1===0 && i % input2 ===0) {
       $('#fizzOutput').append("<font color='green'>FizzBuzz" + "<br/>");
         
        }else if (i % input1 === 0){
            $('#fizzOutput').append("<font color='blue'>Fizz" + "<br/>");
        }
       
        else if (i % input2 === 0){
            $('#fizzOutput').append("<font color='red'>Buzz" + "<br/>");
        }
        
        else{
            $('#fizzOutput').append(i + "<br/>");
        }

     }
    }

    else {
        $('#fizzOutput').append("<font color='green'> Please enter 2 numbers between 1-100</font>")
    }

});

});