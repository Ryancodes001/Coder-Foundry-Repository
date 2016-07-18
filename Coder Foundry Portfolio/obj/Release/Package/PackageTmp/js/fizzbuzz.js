$(document).ready(function() {

$('#fizzButton').click(function(event) {
     event.preventDefault();

	var input1 = $('#fizzInput1').val()
	var input2 = $('#fizzInput2').val()



for (var i=1; i <= 100; i++){

   if (i % input1===0 && i % input2 ===0) {
     $('#fizzOutput').append("FizzBuzz" + "<br/>");
         
        }else if (i % input1 === 0){
         $('#fizzOutput').append("Fizz" + "<br/>");
        }
       
        else if (i % input2 === 0){
           $('#fizzOutput').append("Buzz" + "<br/>");
        }
        
        else{
            $('#fizzOutput').append(i + "<br/>");
        };
    };
    
});

});