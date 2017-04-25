var Donhang = {
    init: function () {
        Donhang.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Quanlywebsite/Donhangadmin/ChangeStatus",
                data: { IDhd: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.Duyet == "1") {
                        btn.text('Đã Duyệt');
                    }
                    else {
                        btn.text('Chưa Duyệt');
                    }
                }
            });
        });
    }
}
Donhang.init();