function isNumberKey(evt) {
    var charCode = (evt.which) ? evt.which : event.keyCode
    if (charCode > 31 && (charCode < 48 || charCode > 57))
        return false;
    return true;
    // onkeypress = "return isNumberKey(event, this);"
}
function DeleteConfirmation() {
    if (confirm("Are you sure,Bạn muốn xóa giỏ hàng đã chọn ?") == true)
        return true;
    else
        return false;
}

$(document).ready(function () {
    load();
    $.ajax({
        type: "GET",
        url: "/Home/Get_ThuonghieuNsx",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, item) {
                $("#Selectbangdangky2TH").append("<option value=\"" + item.Id + "\">" + item.Name + "</option>");
                $("#Selectbangdangky1TH").append("<option value=\"" + item.Id + "\">" + item.Name + "</option>");
            });
        },
        error: function (ex) {
            alert(ex.responseText);
        }
    });
});

$("#Selectbangdangky2TH").change(function () {
    var select2 = $("#Selectbangdangky2TH option:selected").val();
    if (select2 == "") { select2 = 0 }
    $.ajax({
        url: "Home/Get_DongThuonghieuNsx",
        type: "GET",
        data: { Id: select2 },
        dataType: "JSON",
        success: function (data) {
            var html = "";
            html += '<select name="Selectbangdangky2DM" id="Selectbangdangky2DM">';
            if (data.length == 0) {
                html += "<option value=''>Chọn dòng máy</option>";
            }
            else {
                $.each(data, function (key, item) {
                    html += "<option value=\"" + item.Id + "\">" + item.Name + "</option>";
                });
            }
            html += '</select>';
            $("#Showselect2").html(html);
        },
        error: function (er) {
            alert(er.responseText);
        }
    });
});

$("#Selectbangdangky1TH").change(function () {
    var select1 = $("#Selectbangdangky1TH option:selected").val();
    if (select1 == "") { select1 = 0 }
    $.ajax({
        url: "Home/Get_DongThuonghieuNsx",
        type: "GET",
        data: { Id: select1 },
        dataType: "JSON",
        success: function (data) {
            var html = "";
            html += '<select name="Selectbangdangky1DM" id="Selectbangdangky1DM">';
            if (data.length == 0) {
                html += "<option value=''>Chọn dòng máy</option>";
            }
            else {
                $.each(data, function (key, item) {
                    html += "<option value=\"" + item.Id + "\">" + item.Name + "</option>";
                });
            }
            html += '</select>';
            $("#Showselect1").html(html);
        },
        error: function (er) {
            alert(er.responseText);
        }
    });
});

function load() {
    var html2 = "";
    html2 += '<select name="Selectbangdangky2DM" id="Selectbangdangky2DM">';
    html2 += "<option value=''>Chọn dòng máy</option>";
    html2 += '</select>';
    $("#Showselect2").html(html2);

    var html1 = "";
    html1 += '<select name="Selectbangdangky1DM" id="Selectbangdangky1DM">';
    html1 += "<option value=''>Chọn dòng máy</option>";
    html1 += '</select>';
    $("#Showselect1").html(html1);
}

$("#createdangky1").click(function () {
    var flag = true;
    var object = {
        Thuonghieu: $("#Selectbangdangky1TH option:selected").text(),
        Dongmay: $("#Selectbangdangky1DM option:selected").text(),
        Soseri: $("#Dk1Soseri").val(),
        Hovaten: $("#Dk1Hovaten").val(),
        Sodienthoai: $("#Dk1Sodienthoai").val(),
        Noidungsuachua: $("#Dk1Noidungsuachua").val(),
        Images1: $("#Dk1file_name_Images1").val(),
        Images2: $("#Dk1file_name_Images2").val(),
        Giaban: "0",
        Index: "1",
        //Ngaygoi: "",
        Active: "false"
    }
    if (object.Noidungsuachua == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Nội dung không bỏ trống',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    if (object.Sodienthoai == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Số điện thoại không bỏ trống',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    if (object.Hovaten == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Họ và tên không bỏ trống',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    if (object.Soseri == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Số seri không bỏ trống',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    if ($("#Selectbangdangky1DM option:selected").val()== "") {
        $.toast({
            heading: 'Thông báo',
            text: 'chưa chọn dòng máy',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }

    if ($("#Selectbangdangky1TH option:selected").val() == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Chưa chọn thương hiệu',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    //console.log(object);

    if (flag == true) {
        $.ajax({
            url: "/Quanlywebsite/DientuInfoAdmin/Insert",
            data: object,
            type: "POST",
            dataType: "JSON",
            success: function (data) {
                $.toast({
                    heading: 'Thông báo',
                    text: 'Bạn đã gửi thông tin thành công',
                    icon: 'info',
                    position: 'mid-center',
                    stack: false
                })
                $.each(object, function (key, item) {
                    $("#Dk1" + key).val("");
                });
                $(".error1").remove();
                $(".error2").remove();
                $(".error3").remove();
                $(".error4").remove();
            },
            error: function (ex) {
                alert(ex.responseText);
            }

        });
    }

});

$("#createdangky2").click(function () {
    var flag = true;
    var object = {
        Thuonghieu: $("#Selectbangdangky2TH option:selected").text(),
        Dongmay: $("#Selectbangdangky2DM option:selected").text(),
        Soseri: $("#Dk2Soseri").val(),
        Hovaten: $("#Dk2Hovaten").val(),
        Sodienthoai: $("#Dk2Sodienthoai").val(),
        Noidungsuachua: $("#Dk2Noidungsuachua").val(),
        Images1: $("#Dk2file_name_Images1").val(),
        Images2: $("#Dk2file_name_Images2").val(),
        Giaban: $("#Dk2Giaban").val(),
        Index: "2",
        //Ngaygoi: "",
        Active: "false"
    }
    if (object.Noidungsuachua == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Nội dung không bỏ trống',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    if (object.Giaban == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Giá bán không bỏ trống',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    if (object.Soseri == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Số seri không bỏ trống',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    if ($("#Selectbangdangky2DM option:selected").val() == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'chưa chọn dòng máy',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }

    if ($("#Selectbangdangky2TH option:selected").val() == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Chưa chọn thương hiệu',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        flag = false;
    }
    //console.log(object);

    if (flag == true) {
        $.ajax({
            url: "/Quanlywebsite/DientuInfoAdmin/Insert",
            data: object,
            type: "POST",
            dataType: "JSON",
            success: function (data) {
                $.toast({
                    heading: 'Thông báo',
                    text: 'Bạn đã gửi thông tin thành công',
                    icon: 'info',
                    position: 'mid-center',
                    stack: false
                })
                $.each(object, function (key, item) {
                    $("#Dk2" + key).val("");
                });
                $(".error1").remove();
                $(".error2").remove();
                $(".error3").remove();
                $(".error4").remove();
            },
            error: function (ex) {
                alert(ex.responseText);
            }

        });
    }
});

$(document).ready(function () {
    $('#Dk1Images1').fileupload({
        dataType: 'json',
        url: '/Home/UploadFiles',
        autoUpload: true,
        done: function (e, data) {
            if (data.result.data == "1") {
                $.toast({
                    heading: 'Thông báo',
                    text: 'File tải quá lớn',
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
            }
            if (data.result.data == "2") {
                $.toast({
                    heading: 'Thông báo',
                    text: 'File tải không đúng định dạng',
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
            }

            else {
                $(".error1").remove();
                $('#Dk1file_name_Images1').val("");
                $('#Dk1file_name_Images1').val("/Uploads/images/UploadInfo/" + data.result.name);
                //document.getElementById("Dk1Images1").disabled = true;
                $("#Dk1Images1").after("<span class='error1'>Đã chọn File</span>");
                // $('.file_type').html(data.result.type);
                // $('.file_size').html(data.result.size);
            }
            
        }

    });
    //.on('fileuploadprogressall', function (e, data) {
    //    var progress = parseInt(data.loaded / data.total * 100, 10);
    //    $('.progress .progress-bar').css('width', progress + '%');
    //});
}); //upload images1 dk1

$(document).ready(function () {
    $('#Dk1Images2').fileupload({
        dataType: 'json',
        url: '/Home/UploadFiles',
        autoUpload: true,
        done: function (e, data) {
            if (data.result.data == "1") {
                $.toast({
                    heading: 'Thông báo',
                    text: 'File tải quá lớn',
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
            }
            if (data.result.data == "2") {
                $.toast({
                    heading: 'Thông báo',
                    text: 'File tải không đúng định dạng',
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
            }

            else {
                $(".error2").remove();
                $('#Dk1file_name_Images2').val("");
                $('#Dk1file_name_Images2').val("/Uploads/images/UploadInfo/" + data.result.name);
                //document.getElementById("Dk1Images2").disabled = true;
                $("#Dk1Images2").after("<span class='error2'>Đã chọn File</span>");
                // $('.file_type').html(data.result.type);
                // $('.file_size').html(data.result.size);
            }
            
        }

    });
    //.on('fileuploadprogressall', function (e, data) {
    //    var progress = parseInt(data.loaded / data.total * 100, 10);
    //    $('.progress .progress-bar').css('width', progress + '%');
    //});
});//upload images2 dk1

$(document).ready(function () {
    $('#Dk2Images1').fileupload({
        dataType: 'json',
        url: '/Home/UploadFiles',
        autoUpload: true,
        done: function (e, data) {
            if (data.result.data == "1") {
                $.toast({
                    heading: 'Thông báo',
                    text: 'File tải quá lớn',
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
            }
            if (data.result.data == "2") {
                $.toast({
                    heading: 'Thông báo',
                    text: 'File tải không đúng định dạng',
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
            }

            else {
                $(".error3").remove();
                $('#Dk2file_name_Images1').val("");
                $('#Dk2file_name_Images1').val("/Uploads/images/UploadInfo/" + data.result.name);
                //document.getElementById("Dk2Images1").disabled = true;
                $("#Dk2Images1").after("<span class='error3'>Đã chọn File</span>");
                // $('.file_type').html(data.result.type);
                // $('.file_size').html(data.result.size);
            }

        }

    });
    //.on('fileuploadprogressall', function (e, data) {
    //    var progress = parseInt(data.loaded / data.total * 100, 10);
    //    $('.progress .progress-bar').css('width', progress + '%');
    //});
});//upload images1 dk2

$(document).ready(function () {
    $('#Dk2Images2').fileupload({
        dataType: 'json',
        url: '/Home/UploadFiles',
        autoUpload: true,
        done: function (e, data) {
            if (data.result.data == "1") {
                $.toast({
                    heading: 'Thông báo',
                    text: 'File tải quá lớn',
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
            }
            if (data.result.data == "2") {
                $.toast({
                    heading: 'Thông báo',
                    text: 'File tải không đúng định dạng',
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
            }

            else {
                $(".error4").remove();
                $('#Dk2file_name_Images2').val("");
                $('#Dk2file_name_Images2').val("/Uploads/images/UploadInfo/" + data.result.name);
                // document.getElementById("Dk2Images2").disabled = true;
                $("#Dk2Images2").after("<span class='error4'>Đã chọn File</span>");
            }

            // $('.file_type').html(data.result.type);
            // $('.file_size').html(data.result.size);
        }

    });
    //.on('fileuploadprogressall', function (e, data) {
    //    var progress = parseInt(data.loaded / data.total * 100, 10);
    //    $('.progress .progress-bar').css('width', progress + '%');
    //});
});//upload images2 dk2

//Comand search

$("#searchproduct").click(function () {
    var inputsearch = $("#txtsearchproduct").val();
    if (inputsearch == "") {
        $.toast({
            heading: 'Thông báo',
            text: 'Ô tìm kiếm không bỏ trống',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        return false;
    }

});


(function () {
    (function ($) {
        return $.fn.imgPreload = function (options) {
            var delay_completion, i, image_stack, placeholder_stack, replace, settings, spinner_stack, src, x, _i, _len;
            settings = {
                fake_delay: 10,
                animation_duration: 1000,
                spinner_src: '/Images/ajax-loader2.gif'
            };
            if (options) {
                $.extend(settings, options);
            }
            image_stack = [];
            placeholder_stack = [];
            spinner_stack = [];
            window.delay_completed = false;
            delay_completion = function () {
                var x, _i, _len, _results;
                window.delay_completed = true;
                _results = [];
                for (_i = 0, _len = image_stack.length; _i < _len; _i++) {
                    x = image_stack[_i];
                    _results.push($(x).attr('data-load-after-delay') === 'true' ? (replace(x), $(x).removeAttr('data-load-after-delay')) : void 0);
                }
                return _results;
            };
            setTimeout(delay_completion, settings.fake_delay);
            this.each(function () {
                var $image, $placeholder, $spinner_img, offset_left, offset_top;
                $image = $(this);
                offset_top = $image.offset().top;
                offset_left = $image.offset().left;
                $spinner_img = $('<img>');
                $placeholder = $('<img>').attr({
                    src: 'data:image/gif;base64,R0lGODlhAQABA\
                IABAP///wAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw=='
                });
                $placeholder.attr({
                    width: $image.attr('width')
                });
                $placeholder.attr({
                    height: $image.attr('height')
                });
                spinner_stack.push($spinner_img);
                placeholder_stack.push($placeholder);
                image_stack.push($image.replaceWith($placeholder));
                $('body').append($spinner_img);
                $spinner_img.css({
                    position: 'absolute'
                });
                $spinner_img.css('z-index', 9999);
                $spinner_img.load(function () {
                    $(this).css({
                        left: (offset_left + $placeholder.width() / 2) - $(this).width() / 2
                    });
                    return $(this).css({
                        top: (offset_top + $placeholder.height() / 2) - $(this).height() / 2
                    });
                });
                return $spinner_img.attr({
                    src: settings.spinner_src
                });
            });
            i = 0;
            for (_i = 0, _len = image_stack.length; _i < _len; _i++) {
                x = image_stack[_i];
                x.attr({
                    no: i++
                });
                src = x.attr('src');
                x.attr({
                    src: ''
                });
                x.load(function () {
                    if (window.delay_completed) {
                        return replace(this);
                    } else {
                        return $(this).attr('data-load-after-delay', true);
                    }
                });
                x.attr({
                    src: src
                });
            }
            replace = function (image) {
                var $image, no_;
                $image = $(image);
                no_ = $image.attr('no');
                placeholder_stack[no_].replaceWith($image);
                spinner_stack[no_].fadeOut(settings.animation_duration / 2, function () {
                    return $(this).remove();
                });
                return $image.fadeOut(0).fadeIn(settings.animation_duration);
            };
            return this;
        };
    })(jQuery);
}).call(this);

////load img
//$(function () {
//    $('.container img').imgPreload()
//})

//định dạng thành tiền phân cách hàng ngàn
function formatMoneyVND(money) {
    if (money == 0) {
        return 0;
    }
    var tmp = money.toString().split('').reverse().join('');
    var a = [];
    var len = tmp.length;
    var b = true;
    while (b) {
        if (tmp.indexOf(",") > 0) {
            tmp = tmp.replace(",", "");
            b = true;
        }
        else {
            b = false;
        }
    }
    b = true;
    while (b) {
        len = tmp.length;
        if (len % 3 != 0) {
            tmp = tmp.toString() + '0';
            b = true;
        }
        else {
            b = false;
        }
    }
    for (var i = 0; i < tmp.length; i += 3) {
        a.push(tmp[i] + tmp[i + 1] + tmp[i + 2]);
    }
    tmp = a.toString().split('').reverse().join('');
    b = true;
    while (b) {
        if (tmp[0] == 0 || tmp[0] == ',') {
            tmp = tmp.substr(1);
            b = true;
        }
        else {
            b = false;
        }
    }
    return tmp;
}

//click change color in detail product
$(".imgclickmau").click(function () {
    var action = $(this); // khởi tạo hành động
    var Id = action.data('id');
    var object = {
        Idmau: Id,
        Iddungluong: $("#selectDungluong option:selected").val(),
        IdProduct: $("#ctmsp").text()
    }

    $.ajax({
        url: "/Ajaxproduct/AjaxDientuchitiethinh",
        type: "Post",
        dataType: "json",
        data: object,
        success: function (data) {
            if (data == 1) {
                var tenmau = action.attr("alt");
                var dungluong = $("#selectDungluong option:selected").text();
                $.toast({
                    heading: 'Thông báo',
                    text: 'Không có sản phẩm Màu: ' + tenmau + ' với dung lượng: ' + dungluong,
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
                return false;
            }
            else {
                $(".parentctkhuyenmai").text("");
                $(".het-hang").text("");
                // $('#selectDungluong option').removeAttr('selected').filter('[value=' + data.Iddungluong + ']').attr('selected', true);
                var Tinhtrang = "";
                if (data.Tinhtrang == 1) {
                    Tinhtrang = "còn hàng";
                }
                else
                    Tinhtrang = "hết hàng";

                $("#ctIdmausac").text(data.Idmau);
                $("#_resurtImagesmain").attr({ "src": data.Images, "alt": data.Idmau });
                $("#ctpriceban").text(formatMoneyVND(data.Giaban));
                if (data.Giaban == data.Giacu) {
                    $("#ctshowgiancu").addClass("hidden");
                    $("#ctpricecu").text(formatMoneyVND(data.Giacu));
                }
                else {
                    $("#ctshowgiancu").removeClass("hidden");
                    $("#ctpricecu").text(formatMoneyVND(data.Giacu));
                }
                $(".con-hang").text(Tinhtrang);
                $("#ctidtagchitiethinh").text(data.IdTag);
                if (data.Tinhtrang == 0) {
                    $(".het-hang").text("");
                    $(".het-hang").addClass("hidden");
                }
                else {
                    $(".het-hang").removeClass("hidden");
                    var htmlsltk = '';
                    htmlsltk += ' <div class="verdes-element">'
                    htmlsltk += ' <span class="het-hang">';
                    htmlsltk += "<span id='ctslhang'> " + data.Soluong + "</span> chiếc";
                    htmlsltk += "  </span>";
                    htmlsltk += "</div>";

                    $(".het-hang").append(htmlsltk);
                }

                if (data.Phantramkm == 0) {
                    $(".parentctkhuyenmai").text("");
                }
                else {
                    var htmlkm = "";
                    htmlkm += "  <b>";
                    htmlkm += " Tiết kiệm <span class='ctkhuyenmai'>";
                    htmlkm += data.Phantramkm;
                    htmlkm += " </span>%";
                    htmlkm += " </b>";
                    if ($(".parentctkhuyenmai").text() == "")
                        $(".parentctkhuyenmai").append(htmlkm);
                }

                $("#cttenmau").text(data.Tenmau);
                $("#ctIddungluong").text(data.Iddungluong);
            }

        },
        error: function (ex) {
            alert(ex.error);
        }
    });
    return false;
});

$("#selectDungluong").change(function () {
    var action = $(this); // khởi tạo hành động
    var Id = $("#ctIdmausac").text();//action.data('id');
    var object = {
        Idmau: Id,
        Iddungluong: $("#selectDungluong option:selected").val(),
        IdProduct: $("#ctmsp").text()
    }
    //console.log(object);
    $.ajax({
        url: "/Ajaxproduct/AjaxDientuchitiethinh",
        type: "Post",
        dataType: "json",
        data: object,
        success: function (data) {
            if (data == 1) {
                var tenmau = $("#cttenmau").text();
                var dungluong = $("#selectDungluong option:selected").text();
                $.toast({
                    heading: 'Thông báo',
                    text: 'Không có sản phẩm Màu: ' + tenmau + ' với dung lượng: ' + dungluong,
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
                return false;
            }
            else {
                $(".parentctkhuyenmai").text("");
                $(".het-hang").text("");
                // $('#selectDungluong option').removeAttr('selected').filter('[value=' + data.Iddungluong + ']').attr('selected', true);
                var Tinhtrang = "";
                if (data.Tinhtrang == 1) {
                    Tinhtrang = "còn hàng";
                }
                else
                    Tinhtrang = "hết hàng";

                $("#_resurtImagesmain").attr({ "src": data.Images, "alt": data.Idmau });
                $("#ctpriceban").text(formatMoneyVND(data.Giaban));
                if (data.Giaban == data.Giacu) {
                    $("#ctshowgiancu").addClass("hidden");
                    $("#ctpricecu").text(formatMoneyVND(data.Giacu));
                }
                else {
                    $("#ctshowgiancu").removeClass("hidden");
                    $("#ctpricecu").text(formatMoneyVND(data.Giacu));
                }
                $(".con-hang").text(Tinhtrang);
                $("#ctidtagchitiethinh").text(data.IdTag);
                if (data.Tinhtrang == 0) {
                    $(".het-hang").text("");
                    $(".het-hang").addClass("hidden");
                }
                else {
                    $(".het-hang").removeClass("hidden");
                    var htmlsltk = '';
                    htmlsltk += ' <div class="verdes-element">'
                    htmlsltk += ' <span class="het-hang">';
                    htmlsltk += "<span id='ctslhang'> " + data.Soluong + "</span> chiếc";
                    htmlsltk += "  </span>";
                    htmlsltk += "</div>";

                    $(".het-hang").append(htmlsltk);
                }

                if (data.Phantramkm == 0) {
                    $(".parentctkhuyenmai").text("");
                }
                else {
                    var htmlkm = "";
                    htmlkm += "  <b>";
                    htmlkm += " Tiết kiệm <span class='ctkhuyenmai'>";
                    htmlkm += data.Phantramkm;
                    htmlkm += " </span>%";
                    htmlkm += " </b>";
                    if ($(".parentctkhuyenmai").text() == "")
                        $(".parentctkhuyenmai").append(htmlkm);
                }

                $("#cttenmau").text(data.Tenmau);
                $("#ctIddungluong").text(data.Iddungluong);
            }

        },
        error: function (ex) {
            alert(ex.error);
        }
    });
    return false;
});

//code cart add

function CreateCart() {
    var object = {
        IDsanpham: $("#ctmsp").text(),
        Tensanpham: $("#cttensanpham").text(),
        Soluong: "",
        Giaban: $("#ctpriceban").text(),
        Size: "",
        IdTag: $("#ctidtagchitiethinh").text(),
        Mausac: $("#_resurtImagesmain").attr("alt"),
        Dungluong: $("#selectDungluong option:selected").text(),
        IdDungluong: $("#selectDungluong option:selected").val(),
        Hinhanh: $("#_resurtImagesmain").attr("src"),
        danhmucsanpham: "",
        chitietsanpham: "",
        Giamthem: "",
        phantramkm: $(".ctkhuyenmai").text(),
        Baohanh: $("#ctbaohanh").text(),
        Giacu: $("#ctpricecu").text(),
        tinhtrang: $(".con-hang").text()
    }
    if (object.tinhtrang == "hết hàng") {
        $.toast({
            heading: 'Thông báo',
            text: 'Sản phẩm này đã hết hàng',
            icon: 'info',
            position: 'top-right',
            stack: false
        })
        return false;
    }

    $.ajax({
        url: "/Cart/CreatCart",
        dataType: "json",
        type: "post",
        data: object,
        success: function (data) {
            if (data == 1) {
                $("body").addClass("loading");
                setTimeout(function () {
                    location.href = "/gio-hang/";
                    return false;
                    $("body").removeClass("loading");
                }, 1000);
            }
            else
            {
                var tenmau = $("#cttenmau").text();
                var dungluong = $("#selectDungluong option:selected").text();
                $.toast({
                    heading: 'Thông báo',
                    text: 'Không có sản phẩm Màu: ' + tenmau + ' với dung lượng: ' + dungluong,
                    icon: 'info',
                    position: 'top-right',
                    stack: false
                })
                return false;
            }
        },
        error: function (ex) {
            alert("Error: " + ex.error);
        }
    });
}

$("#btnOnlineBuyNow").click(function () {
    CreateCart();
    return false;
});

$("#btnOnlineBuyNowfooter").click(function () {
    CreateCart();
    return false;
});

$(".updatecart").click(function () {
    var action = $(this);
    var object = {
        soluonggiohang: action.val(),
        masanphamgiohang: action.data('id')

    }
    console.log(object);
    $("body").addClass("loading");
    setTimeout(function () {
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
        $("body").removeClass("loading");
    }, 1000);



    return false;
});

//load dung luong
var ctIddungluong = $("#ctIddungluong").text();
$('#selectDungluong option').removeAttr('selected').filter('[value=' + ctIddungluong + ']').attr('selected', true);
