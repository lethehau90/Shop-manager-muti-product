function get_Read_Rep(IdProduct,Id) {
    $.ajax({
        url: '/Quanlywebsite/CommentProductAdmin/Read_Rep',
        type: "Post",
        dataType: 'json',
        data: { IdProduct:IdProduct,Id: Id },
        success: function (data) {
            var row = '';
            
            /* Before serialize */
            $.each(data, function (i,item) {
                row += '<div class="media">';
                        row += '<a class="pull-left" href="#">';
                        row += '<i class="fa fa-comment"></i>';
                        row += '</a>';
                    row += '<div class="media-body">';
                    row += '<h4 class="media-heading">' + item.Name + ': (' + item.Email + ')</h4>';
                    row += '<span>' + item.Content + '</span>';
                    row += '</br>Kích hoạt: <a class="label label-primary activerepcomment'+item.Id+'" onclick="return getactive(' + item.Id + ',' + item.ProId + ')"  data-id=' + item.Id + '>';
                    if (item.Active == 1)
                    {
                        row += "Có";
                    }
                    else
                    {
                        row += "Không";
                    }
                    row += "</a>";
                    row += ' <a class="btn btn-danger btn-xs" onclick="return ClickDelete(' + item.Id + ',' + item.ProId + ')"> <i class="fa fa-trash-o"></i> Delete </a>';
                    row += '</div>';
                    row += '</div>';
                    $("#Rep_comment").html(row);
            });
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
