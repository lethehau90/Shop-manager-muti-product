$(document).ready(function () {
    $("#TxtGianhaphang").blur(function () {
        $(this).val(formatMoneyVND($(this).val()));
    });
    $("#TxtGiaban").blur(function () {
        $(this).val(formatMoneyVND($(this).val()));
    });
    $("#TxtGiabankhuyenmai").blur(function () {
        $(this).val(formatMoneyVND($(this).val()));
    });
    $("#TxtGiaban_Event").blur(function () {
        $(this).val(formatMoneyVND($(this).val()));
    });
});