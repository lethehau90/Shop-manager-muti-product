var filter = window.location.search.substring(1); //lấy giá trị request url
switch (filter) {
    case "filter=highlight": //nổi bật
        $("#bt-highlight").removeClass("btn-default").addClass("btn-danger");
        $("#bt-normal").removeClass("btn-danger").addClass("btn-default");
        $("#bt-All").removeClass("btn-danger").addClass("btn-default");
        break;
    case "filter=normal": //bình thường
        $("#bt-normal").removeClass("btn-default").addClass("btn-danger");
        $("#bt-highlight").removeClass("btn-danger").addClass("btn-default");
        $("#bt-All").removeClass("btn-danger").addClass("btn-default");
        break;
    default: //mặt định lấy tất cả
        $("#bt-All").removeClass("btn-default").addClass("btn-danger");
        $("#bt-highlight").removeClass("btn-danger").addClass("btn-default");
        $("#bt-normal").removeClass("btn-danger").addClass("btn-default");
        break;

}