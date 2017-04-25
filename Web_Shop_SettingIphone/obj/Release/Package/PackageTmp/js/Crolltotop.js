// Java scroll to top

$(function () {
    $.fn.scrollToTop = function () {
        $(this).hide().removeAttr("href");   // Xóa thuộc tính "href" trong phần HTML
        if ($(window).scrollTop() != "0") { $(this).fadeIn("slow") }
        var scrollDiv = $(this);
        $(window).scroll(function () {   // Sự kiện trượt trang web
            if ($(window).width() < 1100) {
                $(".toTop").hide();
                return;
            }
            if ($(document).scrollTop() < $(window).height()) {
                $(".toTop").fadeOut("slow");   // ẩn nút
            } else {
                $(".toTop").fadeIn("slow");    // Hiện nút
            }
        });
        $(this).click(function () { // Sự kiện click nút
            $("html, body").animate({ scrollTop: 0 }, "slow")   // Tạo hiệu ứng chuyển mượt
        })
    }
});
$(function () { $(".toTop").scrollToTop(); });

// Khi resize cửa sổ trình duyệt
$(window).resize(function () {
    if ($(window).width() < 1100) {
        $(".toTop").hide();
        return;
    }
});