
function isEmail(emailStr) {
    var emailPat = /^(.+)@(.+)$/
    var specialChars = "\\(\\)<>@,;:\\\\\\\"\\.\\[\\]"
    var validChars = "\[^\\s" + specialChars + "\]"
    var quotedUser = "(\"[^\"]*\")"
    var ipDomainPat = /^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/
    var atom = validChars + '+'
    var word = "(" + atom + "|" + quotedUser + ")"
    var userPat = new RegExp("^" + word + "(\\." + word + ")*$")
    var domainPat = new RegExp("^" + atom + "(\\." + atom + ")*$")
    var matchArray = emailStr.match(emailPat)
    if (matchArray == null) {
        return false
    }
    var user = matchArray[1]
    var domain = matchArray[2]

    // See if "user" is valid
    if (user.match(userPat) == null) {
        return false
    }
    var IPArray = domain.match(ipDomainPat)
    if (IPArray != null) {
        // this is an IP address
        for (var i = 1; i <= 4; i++) {
            if (IPArray[i] > 255) {
                return false
            }
        }
        return true
    }
    var domainArray = domain.match(domainPat)
    if (domainArray == null) {
        return false
    }

    var atomPat = new RegExp(atom, "g")
    var domArr = domain.match(atomPat)
    var len = domArr.length

    if (domArr[domArr.length - 1].length < 2 ||
        domArr[domArr.length - 1].length > 3) {
        return false
    }

    // Make sure there's a host name preceding the domain.
    if (len < 2) {
        return false
    }

    // If we've gotten this far, everything's valid!
    return true;
}

//kiểm tra chỉ nhập số
function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
    // onkeypress = "return isNumberKey(event, this);"
}

$(".updatecartmobile").change(function () {
    var object = {
        soluonggiohang: $(this).attr('value'),
        masanphamgiohang: $(this).attr("id")
    }
    setInterval(function () {
        $('.table-cart').loading('toggle');
        $.ajax({
            url: "/Cart/UpdateCart",
            dataType: "json",
            type: "post",
            data: object,
            success: function (data) {
                if (data == 1) {
                    location.href = "/gio-hang";
                }
                else {
                    location.href = "/gio-hang";
                    return false;
                }
            },
            error: function (ex) {
                alert("Error: " + ex.error);
            }
        });
    }, 2000);

    return false;

});

$(".updatecart").bind('keyup change click', function (e) {
    var action = $(this);
    var object = {
        soluonggiohang: action.val(),
        masanphamgiohang: action.data('id')
    }
    setInterval(function () {
        $('.table-cart').loading('toggle');
        $.ajax({
            url: "/Cart/UpdateCart",
            dataType: "json",
            type: "post",
            data: object,
            success: function (data) {
                if (data == 1) {
                    location.href = "/gio-hang";
                }
                else {
                    location.href = "/gio-hang";
                    return false;
                }
            },
            error: function (ex) {
                alert("Error: " + ex.error);
            }
        });
    }, 2000);

    return false;
});

$("#btdathang").click(function () {
    var flag = true;
    var object = {
        Xungho: $("#selectXungho option:selected").val(),
        Hoten: $("#txtHoten").val(),
        SDT: $("#txtSDT").val(),
        Mail: $("#txtMail").val(),
        Diachi: $("#txtDiachi").val(),
        GhiChuKhac: $("#txtGhiChuKhac").val()
    }
    $.each(object, function (key, item) {
        if ($("#txt" + key).val() == "") {
            $.toast({
                heading: 'Thông báo',
                text: 'Các thông tin giao hàng vui lòng khách nhập đầy đủ',
                icon: 'info',
                position: 'top-right',
                stack: false
            })
            return false;
        }
    });

    if (!isEmail(object.Mail))
    {
        $.toast({
            heading: 'Thông báo',
            text: 'Nhập email không hợp lệ',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        return false;
    }

    if (flag == true) {
        setInterval(function () {
            $('#btdathang').loading('toggle');
            $.ajax({
                url: "/Thanhtoan/CreateDonhang",
                type: "post",
                dataType: "json",
                data: object,
                success: function (data) {
                    if (data == 1) {
                        location.href = "/da-dat-hang";
                    }
                },
                error: function (ex) {
                    alert(ex.error);
                }

            });
        }, 2000);

    }
    return true;

});