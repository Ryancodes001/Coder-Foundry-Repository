$(document).ready(function() {

$('#button').click(function(event) {
     event.preventDefault();

	var input1 = $('#input1').val()
	var input2 = $('#input2').val()



for (var i=1; i <= 100; i++){

   if (i % input1===0 && i % input2 ===0) {
     $('#output1').append("FizzBuzz" + "<br/>");
         
        }else if (i % input1 === 0){
         $('#output1').append("Fizz" + "<br/>");
        }
       
        else if (i % input2 === 0){
           $('#output1').append("Buzz" + "<br/>");
        }
        
        else{
            $('#output1').append(i + "<br/>");
        };
    };
    
});

});