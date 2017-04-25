function get_Read(Id) {
    $.ajax({
        url: '/Quanlywebsite/CommentProductAdmin/Get_Read',
        type: "Post",
        dataType: 'json',
        data: { Id: Id },
        success: function (data) {
            /* Before serialize */
            $(".namecomment").text(data.Name);
            $(".viewcomment").html(data.Name + ": ("+ data.Email+")");
            $(".viewContent").html(data.Content);
        },
        error: function (err) {
            alert("Error: " + err.responseText);
        }
    });
}
