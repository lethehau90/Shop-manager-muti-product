//hộp thoại thông báo
    function alert_question_libary() {
        $.messager.alert('Thông báo', 'Hệ thống yêu cầu bạn vui lòng kiểm tra dữ liệu nhập ? </br><strong>Lưa ý:</strong> Chú thích <span style="color: red">màu đỏ</span> không được để trống ! </br> <strong>Mẹo: </strong> Kiểm tra dữ liệu báo <span style="color: red">màu đỏ</span> trên các tab đang có.', 'question');
    }
    function alert_Error_ID() {
        $.messager.alert('Thông báo', 'Lỗi Id trống, không lấy được ID dữ liệu !', 'question');
    }
    function alert_Error_Login() {
        $.messager.alert('Thông báo', '<strong>Lỗi đăng nhập</strong> </br>Tên đăng nhập hoặc mật khẩu không chính xác !', 'question');
    }
    function alert_Deleteone() {
        $.messager.alert('Thông báo', '<strong>Xóa thành công</strong> ', 'question');
    }
    function alert_name_user() {
        $.messager.alert('Thông báo', '<strong>Lỗi ! trùng tên người dùng hoặc tên đăng nhập</strong> ', 'question');
    }
    function alert_name() {
        $.messager.alert('Thông báo', '<strong>Lỗi ! trùng tên</strong> ', 'question');
    }
    function alert_email() {
        $.messager.alert('Thông báo', '<strong>Lỗi ! trùng Email</strong> ', 'question');
    }
    function alert_sl() {
        $.messager.alert('Thông báo', '<strong>Lỗi ! trùng số lượng</strong> ', 'question');
    }
    function alert_tax() {
        $.messager.alert('Thông báo', '<strong>Lỗi ! trùng tên và Vùng</strong> ', 'question');
    }
    function alert_khoanggia() {
        $.messager.alert('Thông báo', '<strong>Lỗi ! Khoảng giá đã có</strong> ', 'question');
    }
    function alert_Insert() {
        $.messager.alert('Thông báo', '<strong>Đã thêm thành công</strong> ', 'question');
    }
    function alert_update() {
        $.messager.alert('Thông báo', '<strong>Đã cập nhật thành công</strong> ', 'question');
    }
    function alert_Role() {
        $.messager.alert('Thông báo', '<strong>Bạn chưa được cấp quyền thực hiện chức năng này</strong> ', 'question');
    }
    function alert_Detenone() {
        $.messager.alert('Thông báo', '<strong>Chưa có dữ liệu nào được chọn</strong> ', 'question');
    }
    function alert_date() {
        $.messager.alert('Thông báo', '<strong>Ngày tháng đâu đó không hợp lệ</strong> ', 'question');
    }
    function alert_thuoctinh() {
        $.messager.alert('Thông báo', '<strong>Đã cập nhật sản phẩm. </br> Tiếp tụp cập nhật thuộc tính và hình ảnh</strong> ', 'question');
    }
    
    function alert_updatesuccess() {
        $.messager.alert('Thông báo', '<strong>Đã cập nhật.</strong> ', 'question');
    }
//end hộp thoại thông báo

    function InvalidMsg(textbox) {
        if (textbox.value == '') {
            textbox.setCustomValidity('Vui lòng ô này không được để trống');
        }
            /* else if (textbox.validity.typeMismatch) {
                     textbox.setCustomValidity('please enter a valid email address');
                 }*/
        else {
            textbox.setCustomValidity('');
        }
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
//thực hiện chekbox All
    function toggle(source) {
        checkboxes = document.getElementsByName('checkRow');
        for (var i = 0, n = checkboxes.length; i < n; i++) {
            checkboxes[i].checked = source.checked;
        }
    }

    function getgender(key) {
        return (key == 1) ? "Nam" : "Nữ";
    };

//kiểm tra Email
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

  //  autocomplete off
    $("input[type='text']").attr('autocomplete', 'off');
    $("input[type='password']").attr('autocomplete', 'off');

//thư viên settimeout
    //$("body").addClass("loading");
    //setTimeout(function () {
    //    $("body").removeClass("loading");
//}, 500);
//thư viện thông báo xóa
    //$('.Delete').click(confirm);
    //function confirm() {
    //    $.jAlert({
    //        'type': 'confirm', 'confirmQuestion': 'Your account will be deleted permanently, Do you want to proceed?', 'onConfirm': function () {
    //            alert('Your account is removed!');
    //        }, 'onDeny': function () {
    //            alert('Your account is safe!');
    //        }
    //    });
    //}
//});

    function  Getdatetime(datetime) // trả về ngày tháng năm
    {
        if (datetime == null || datetime == "") {
            var dmn = new Date();
        }
        else {
            var dmn = datetime;
        }
        var formattedDate = new Date(dmn);
        var d = formattedDate.getDate();
        var m = formattedDate.getMonth();
        m += 1;  // JavaScript months are 0-11
        var y = formattedDate.getFullYear();

        return d + "/" + m + "/" + y;
    }

    function GetdatetimeNodatenow(datetime) // trả về ngày tháng năm
    {
        var dmn = datetime;
        var formattedDate = new Date(dmn);
        var d = formattedDate.getDate();
        var m = formattedDate.getMonth();
        m += 1;  // JavaScript months are 0-11
        var y = formattedDate.getFullYear();
        return d + "/" + m + "/" + y;
    }

    function parseJsonDate(jsonDate) { //trả về json ngày tháng năm

        var fullDate = new Date(parseInt(jsonDate.substr(6)));
        var twoDigitMonth = (fullDate.getMonth() + 1) + ""; if (twoDigitMonth.length == 1) twoDigitMonth = "0" + twoDigitMonth;

        var twoDigitDate = fullDate.getDate() + ""; if (twoDigitDate.length == 1) twoDigitDate = "0" + twoDigitDate;
        var currentDate = twoDigitDate + "/" + twoDigitMonth + "/" + fullDate.getFullYear();

        return currentDate;
    };

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

    var md5 = function (string) {

        function RotateLeft(lValue, iShiftBits) {
            return (lValue << iShiftBits) | (lValue >>> (32 - iShiftBits));
        }

        function AddUnsigned(lX, lY) {
            var lX4, lY4, lX8, lY8, lResult;
            lX8 = (lX & 0x80000000);
            lY8 = (lY & 0x80000000);
            lX4 = (lX & 0x40000000);
            lY4 = (lY & 0x40000000);
            lResult = (lX & 0x3FFFFFFF) + (lY & 0x3FFFFFFF);
            if (lX4 & lY4) {
                return (lResult ^ 0x80000000 ^ lX8 ^ lY8);
            }
            if (lX4 | lY4) {
                if (lResult & 0x40000000) {
                    return (lResult ^ 0xC0000000 ^ lX8 ^ lY8);
                } else {
                    return (lResult ^ 0x40000000 ^ lX8 ^ lY8);
                }
            } else {
                return (lResult ^ lX8 ^ lY8);
            }
        }

        function F(x, y, z) {
            return (x & y) | ((~x) & z);
        }
        function G(x, y, z) {
            return (x & z) | (y & (~z));
        }
        function H(x, y, z) {
            return (x ^ y ^ z);
        }
        function I(x, y, z) {
            return (y ^ (x | (~z)));
        }

        function FF(a, b, c, d, x, s, ac) {
            a = AddUnsigned(a, AddUnsigned(AddUnsigned(F(b, c, d), x), ac));
            return AddUnsigned(RotateLeft(a, s), b);
        };

        function GG(a, b, c, d, x, s, ac) {
            a = AddUnsigned(a, AddUnsigned(AddUnsigned(G(b, c, d), x), ac));
            return AddUnsigned(RotateLeft(a, s), b);
        };

        function HH(a, b, c, d, x, s, ac) {
            a = AddUnsigned(a, AddUnsigned(AddUnsigned(H(b, c, d), x), ac));
            return AddUnsigned(RotateLeft(a, s), b);
        };

        function II(a, b, c, d, x, s, ac) {
            a = AddUnsigned(a, AddUnsigned(AddUnsigned(I(b, c, d), x), ac));
            return AddUnsigned(RotateLeft(a, s), b);
        };

        function ConvertToWordArray(string) {
            var lWordCount;
            var lMessageLength = string.length;
            var lNumberOfWords_temp1 = lMessageLength + 8;
            var lNumberOfWords_temp2 = (lNumberOfWords_temp1 - (lNumberOfWords_temp1 % 64)) / 64;
            var lNumberOfWords = (lNumberOfWords_temp2 + 1) * 16;
            var lWordArray = Array(lNumberOfWords - 1);
            var lBytePosition = 0;
            var lByteCount = 0;
            while (lByteCount < lMessageLength) {
                lWordCount = (lByteCount - (lByteCount % 4)) / 4;
                lBytePosition = (lByteCount % 4) * 8;
                lWordArray[lWordCount] = (lWordArray[lWordCount] | (string.charCodeAt(lByteCount) << lBytePosition));
                lByteCount++;
            }
            lWordCount = (lByteCount - (lByteCount % 4)) / 4;
            lBytePosition = (lByteCount % 4) * 8;
            lWordArray[lWordCount] = lWordArray[lWordCount] | (0x80 << lBytePosition);
            lWordArray[lNumberOfWords - 2] = lMessageLength << 3;
            lWordArray[lNumberOfWords - 1] = lMessageLength >>> 29;
            return lWordArray;
        };

        function WordToHex(lValue) {
            var WordToHexValue = "", WordToHexValue_temp = "", lByte, lCount;
            for (lCount = 0; lCount <= 3; lCount++) {
                lByte = (lValue >>> (lCount * 8)) & 255;
                WordToHexValue_temp = "0" + lByte.toString(16);
                WordToHexValue = WordToHexValue + WordToHexValue_temp.substr(WordToHexValue_temp.length - 2, 2);
            }
            return WordToHexValue;
        };

        function Utf8Encode(string) {
            string = string.replace(/\r\n/g, "\n");
            var utftext = "";

            for (var n = 0; n < string.length; n++) {

                var c = string.charCodeAt(n);

                if (c < 128) {
                    utftext += String.fromCharCode(c);
                }
                else if ((c > 127) && (c < 2048)) {
                    utftext += String.fromCharCode((c >> 6) | 192);
                    utftext += String.fromCharCode((c & 63) | 128);
                }
                else {
                    utftext += String.fromCharCode((c >> 12) | 224);
                    utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                    utftext += String.fromCharCode((c & 63) | 128);
                }

            }

            return utftext;
        };

        var x = Array();
        var k, AA, BB, CC, DD, a, b, c, d;
        var S11 = 7, S12 = 12, S13 = 17, S14 = 22;
        var S21 = 5, S22 = 9, S23 = 14, S24 = 20;
        var S31 = 4, S32 = 11, S33 = 16, S34 = 23;
        var S41 = 6, S42 = 10, S43 = 15, S44 = 21;

        string = Utf8Encode(string);

        x = ConvertToWordArray(string);

        a = 0x67452301;
        b = 0xEFCDAB89;
        c = 0x98BADCFE;
        d = 0x10325476;

        for (k = 0; k < x.length; k += 16) {
            AA = a;
            BB = b;
            CC = c;
            DD = d;
            a = FF(a, b, c, d, x[k + 0], S11, 0xD76AA478);
            d = FF(d, a, b, c, x[k + 1], S12, 0xE8C7B756);
            c = FF(c, d, a, b, x[k + 2], S13, 0x242070DB);
            b = FF(b, c, d, a, x[k + 3], S14, 0xC1BDCEEE);
            a = FF(a, b, c, d, x[k + 4], S11, 0xF57C0FAF);
            d = FF(d, a, b, c, x[k + 5], S12, 0x4787C62A);
            c = FF(c, d, a, b, x[k + 6], S13, 0xA8304613);
            b = FF(b, c, d, a, x[k + 7], S14, 0xFD469501);
            a = FF(a, b, c, d, x[k + 8], S11, 0x698098D8);
            d = FF(d, a, b, c, x[k + 9], S12, 0x8B44F7AF);
            c = FF(c, d, a, b, x[k + 10], S13, 0xFFFF5BB1);
            b = FF(b, c, d, a, x[k + 11], S14, 0x895CD7BE);
            a = FF(a, b, c, d, x[k + 12], S11, 0x6B901122);
            d = FF(d, a, b, c, x[k + 13], S12, 0xFD987193);
            c = FF(c, d, a, b, x[k + 14], S13, 0xA679438E);
            b = FF(b, c, d, a, x[k + 15], S14, 0x49B40821);
            a = GG(a, b, c, d, x[k + 1], S21, 0xF61E2562);
            d = GG(d, a, b, c, x[k + 6], S22, 0xC040B340);
            c = GG(c, d, a, b, x[k + 11], S23, 0x265E5A51);
            b = GG(b, c, d, a, x[k + 0], S24, 0xE9B6C7AA);
            a = GG(a, b, c, d, x[k + 5], S21, 0xD62F105D);
            d = GG(d, a, b, c, x[k + 10], S22, 0x2441453);
            c = GG(c, d, a, b, x[k + 15], S23, 0xD8A1E681);
            b = GG(b, c, d, a, x[k + 4], S24, 0xE7D3FBC8);
            a = GG(a, b, c, d, x[k + 9], S21, 0x21E1CDE6);
            d = GG(d, a, b, c, x[k + 14], S22, 0xC33707D6);
            c = GG(c, d, a, b, x[k + 3], S23, 0xF4D50D87);
            b = GG(b, c, d, a, x[k + 8], S24, 0x455A14ED);
            a = GG(a, b, c, d, x[k + 13], S21, 0xA9E3E905);
            d = GG(d, a, b, c, x[k + 2], S22, 0xFCEFA3F8);
            c = GG(c, d, a, b, x[k + 7], S23, 0x676F02D9);
            b = GG(b, c, d, a, x[k + 12], S24, 0x8D2A4C8A);
            a = HH(a, b, c, d, x[k + 5], S31, 0xFFFA3942);
            d = HH(d, a, b, c, x[k + 8], S32, 0x8771F681);
            c = HH(c, d, a, b, x[k + 11], S33, 0x6D9D6122);
            b = HH(b, c, d, a, x[k + 14], S34, 0xFDE5380C);
            a = HH(a, b, c, d, x[k + 1], S31, 0xA4BEEA44);
            d = HH(d, a, b, c, x[k + 4], S32, 0x4BDECFA9);
            c = HH(c, d, a, b, x[k + 7], S33, 0xF6BB4B60);
            b = HH(b, c, d, a, x[k + 10], S34, 0xBEBFBC70);
            a = HH(a, b, c, d, x[k + 13], S31, 0x289B7EC6);
            d = HH(d, a, b, c, x[k + 0], S32, 0xEAA127FA);
            c = HH(c, d, a, b, x[k + 3], S33, 0xD4EF3085);
            b = HH(b, c, d, a, x[k + 6], S34, 0x4881D05);
            a = HH(a, b, c, d, x[k + 9], S31, 0xD9D4D039);
            d = HH(d, a, b, c, x[k + 12], S32, 0xE6DB99E5);
            c = HH(c, d, a, b, x[k + 15], S33, 0x1FA27CF8);
            b = HH(b, c, d, a, x[k + 2], S34, 0xC4AC5665);
            a = II(a, b, c, d, x[k + 0], S41, 0xF4292244);
            d = II(d, a, b, c, x[k + 7], S42, 0x432AFF97);
            c = II(c, d, a, b, x[k + 14], S43, 0xAB9423A7);
            b = II(b, c, d, a, x[k + 5], S44, 0xFC93A039);
            a = II(a, b, c, d, x[k + 12], S41, 0x655B59C3);
            d = II(d, a, b, c, x[k + 3], S42, 0x8F0CCC92);
            c = II(c, d, a, b, x[k + 10], S43, 0xFFEFF47D);
            b = II(b, c, d, a, x[k + 1], S44, 0x85845DD1);
            a = II(a, b, c, d, x[k + 8], S41, 0x6FA87E4F);
            d = II(d, a, b, c, x[k + 15], S42, 0xFE2CE6E0);
            c = II(c, d, a, b, x[k + 6], S43, 0xA3014314);
            b = II(b, c, d, a, x[k + 13], S44, 0x4E0811A1);
            a = II(a, b, c, d, x[k + 4], S41, 0xF7537E82);
            d = II(d, a, b, c, x[k + 11], S42, 0xBD3AF235);
            c = II(c, d, a, b, x[k + 2], S43, 0x2AD7D2BB);
            b = II(b, c, d, a, x[k + 9], S44, 0xEB86D391);
            a = AddUnsigned(a, AA);
            b = AddUnsigned(b, BB);
            c = AddUnsigned(c, CC);
            d = AddUnsigned(d, DD);
        }

        var temp = WordToHex(a) + WordToHex(b) + WordToHex(c) + WordToHex(d);

        return temp.toLowerCase();
    }
//alert(md5('mã hóa md5 trong javascript'));

    function change_alias(alias) {
        var str = alias;
        str = str.toLowerCase();
        str = str.replace(/à|á|ạ|ả|ã|â|ầ|ấ|ậ|ẩ|ẫ|ă|ằ|ắ|ặ|ẳ|ẵ/g, "a");
        str = str.replace(/è|é|ẹ|ẻ|ẽ|ê|ề|ế|ệ|ể|ễ/g, "e");
        str = str.replace(/ì|í|ị|ỉ|ĩ/g, "i");
        str = str.replace(/ò|ó|ọ|ỏ|õ|ô|ồ|ố|ộ|ổ|ỗ|ơ|ờ|ớ|ợ|ở|ỡ/g, "o");
        str = str.replace(/ù|ú|ụ|ủ|ũ|ư|ừ|ứ|ự|ử|ữ/g, "u");
        str = str.replace(/ỳ|ý|ỵ|ỷ|ỹ/g, "y");
        str = str.replace(/đ/g, "d");
        str = str.replace(/!|@|\$|%|\^|\*|\(|\)|\+|\=|\<|\>|\?|\/|,|\.|\:|\'| |\"|\&|\#|\[|\]|~/g, "-");
        str = str.replace(/-+-/g, "-"); //thay thế 2- thành 1-
        str = str.replace(/^\-+|\-+$/g, "");//cắt bỏ ký tự - ở đầu và cuối chuỗi
        return str;
    }