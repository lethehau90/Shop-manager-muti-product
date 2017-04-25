$(document).ready(function () {
    $('.btn-active').off('click').on('click', function (e) {
        e.preventDefault();
        var btn = $(this);
        var Id = btn.data('id');
        $.ajax({
            url: "/Quanlywebsite/CommentProductAdmin/Active",
            data: { Id: Id },
            dataType: "json",
            type: "POST",
            success: function (response) {
                   if (response.Active == 1) {
                        btn.text('Có');
                    }
                    else if (response.Active == 0) {
                        btn.text('Không');
                    }
                   $("#update_paner_rep").css("display", "none");//ẩn panner
                   $("#update_paner").css("display", "none");//ẩn panner
            }
        });
    });

  
  
});

function getactive(Id,IdProduct)
{
   
    $.ajax({
        url: "/Quanlywebsite/CommentProductAdmin/Active",
        data: { Id: Id },
        dataType: "json",
        type: "POST",
        success: function (response) {
            if (response.Active == 1) {
                $(".activerepcomment"+Id).text('Có');
            }
            else if (response.Active == 0) {
                $(".activerepcomment" + Id).text('Không');
            }
          //  $("#update_paner_rep").css("display", "none");//ẩn panner
            $("#update_paner").css("display", "none");//ẩn panner
        }
    });
}