$(document).ready(function () {

    $('.transmitScore').on('click', function () {
        var score = 0;
        var c = 0;
        var a = 0;

        $('input[type=checkbox]').each(function () {
           
            if (Number($(this).val()) > Number(0))
            {
                c++            
            }
            
        });   

        $(':checkbox:checked').each(function () {
            a++
            if ($(this).val() == 0)
            {
                score = 0;
                return

            } else
            {            
                score = Number(score) + Number($(this).val())             
            }
        });
     

        if (Number(c) != Number(a))
        {       
            score = 0;      
        }
          
        $('#Quiz_Selector_score').val(score);

    });

});