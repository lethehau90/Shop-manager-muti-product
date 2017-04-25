$(document).ready(function () {
    $("#TxtVideo").blur(function () {
        var video = $("#TxtVideo").val().split("?v=");
        var Id = video[1];
        var src = "https://youtube.com/embed/" + Id;
        $(".video iframe").attr("src", src);
        return false;
    });
});