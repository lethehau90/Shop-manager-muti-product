$(document).ready(function () {
    $('#dataTables-example').DataTable({
        responsive: true,
        "language": {
            
            "decimal": "",
            "zeroRecords": "Không có dữ liệu",
            "info": "Hiển thị trang _PAGE_ / _PAGES_",
            "infoEmpty": "Hiển thị 0 đến 0 / 0 dữ liệu",
            "infoFiltered": "(Tìm kiếm _MAX_ tổng dữ liệu)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Hiển thị _MENU_ dữ liệu",
            "loadingRecords": "Vui lòng đợi đang tải...",
            "processing": "Processing...",
            "search": "Tìm kiếm nhanh theo tên mục:",
            "zeroRecords": "Không tìm thấy kết quả",
            "paginate": {
                "first": "Trước",
                "last": "Sau",
                "next": "Tới",
                "previous": "Lùi"
            },
            "aria": {
                "sortAscending": ": Sắp xếp cột tăng dần",
                "sortDescending": ": Sắp xếp cột giảm dần"
            }
           
        }
    });

    //Error pageging
    $('#example').dataTable({
        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]]
    });
   
});