$(document).ready(function () {
    $('#menu_wrapper ul div').hide();
    $('#menu_wrapper ul li a').click(function () {
        var tmp = $(this).next('div');
       
      //  tmp.slideToggle();
        if ($(tmp).is(':visible')) {
            $(tmp).hide();
           
        }
        else {
            $(tmp).show();
           
        }
        return false;
    });
});