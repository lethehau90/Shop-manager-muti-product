﻿function ddlchaChange(val) {
    if (val != "" && val != undefined) {
        getcon(val);
        $("#Selectlevelmuti").removeClass("hidden");
    } else {
        $("#Selectlevelmuti").addClass("hidden");
        $("#Selectlevelmuti")
            .html($("<option>---- Chọn Cấp con</option>")
                .attr("value", "")
                .text(this.Name));
    }
}

function getcon(Id) {
    $.ajax({
        type: "GET",
        url: "/Quanlywebsite/DientuTinhnangAdmin/Loadmenu_Lever_muti",
        data: { Id: Id },
        dataType: "json",
        success: function (data) {
            if (data.Idtinhang != "0") {
                $("#Selectlevelmuti").removeClass("hidden");

                var appenddata = "";

                if (data == null || data == "") {
                    appenddata += "<option value>--không có cấp con-- </option>";
                }
                else {
                    $.each(data, function (key, value) {
                        appenddata += "<option value = '" + value.Idthuoctinh + " '>" + value.Thuoctinh + " </option>";

                    });
                }

                $("#Selectlevelmuti").html(appenddata);
            } else {
                $("#Selectlevelmuti").addClass("hidden");
                var appenddata = "";
                appenddata += "<option value>--Chọn Cấp Con-- </option>";
            }
        },
        error: function (ex) {
            alert("Da co loi xay ra" + ex.responseText);
        }
    });
}





function getcon_leve2(Id) {
    $.ajax({
        type: "GET",
        url: "/Quanlywebsite/DientuTinhnangAdmin/Loadmenu_Lever2_muti_Id",
        data: { Id: Id },
        dataType: "json",
        success: function (data) {
            if (data.Idtinhang != "") {
                $("#Selectlevel2muti_").removeClass("hidden");

                var appenddata = "";

                if (data == null || data == "") {
                    appenddata += "<option value>--không có cấp con-- </option>";
                }
                else {
                    $.each(data, function (key, value) {
                        appenddata += "<option value = '" + value.Idthuoctinh + " '>" + value.Thuoctinh + " </option>";
                    });
                }

                $("#Selectlevel2muti_").html(appenddata);
            } else {
                //   $("#Selectlevel2muti_").addClass("hidden");
                var appenddata = "";
                appenddata += "<option value>--Chọn Cấp Con-- </option>";
            }
        },
        error: function (ex) {
            alert("Da co loi xay ra" + ex.responseText);
        }
    });
}



function getcon_leve1(Id) {
    $.ajax({
        type: "GET",
        url: "/Quanlywebsite/DientuTinhnangAdmin/Loadmenu_Lever1_muti_",
        data: { Id: Id },
        dataType: "json",
        success: function (data) {
            if (data.Level != "") {
                $("#Selectlevel1muti_").removeClass("hidden");

                var appenddata = "";

                if (data == null || data == "") {
                    appenddata += "<option value>--không có cấp con-- </option>";
                }
                else {
                    $.each(data, function (key, value) {
                        appenddata += "<option  value = '" + value.Idthuoctinh + " '>" + value.Thuoctinh + " </option>";
                    });
                }

                $("#Selectlevel1muti_").html(appenddata);
            } else {
                $("#Selectlevel1muti_").addClass("hidden");
                var appenddata = "";
                appenddata += "<option value>--Chọn Cấp Con-- </option>";
            }
        },
        error: function (ex) {
            alert("Da co loi xay ra" + ex.responseText);
        }
    });
}

