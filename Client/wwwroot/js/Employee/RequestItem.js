$(document).ready(function () {
    $("#tableDataReqItem").DataTable({
        ajax: {

            url: "https://localhost:7095/api/Item",
            dataSrc: "data",
        },

        columns: [

            {
                data: "id",

            },
            {
                data: "name",
            },
            {
                data: "quantity",

            }


        ],
        dom: 'Bfrtip',
        buttons: ['colvis', 'copy', 'excel', 'pdf', 'print']
    });


});

function NewRequestItem() {
    let data;
    let id = 0;
    let accountId = $('#input-userId').val();
    let item = $(`#input-item`).val();
    let qty = $('#input-quantity').val();
    let startDate = $(`#input-start-date`).val();
    let endDate = $(`#input-end-date`).val();
    let notes = $(`#input-notes`).val();
    let status = 3;


    data = {
        "id": id,
        "accountId": accountId,
        "itemid": item,
        "quantity": qty,
        "startDate": startDate,
        "endDate": endDate,
        "notes": notes,
        "statusId": status,
    };
    console.log(data);
    Swal.fire({
        title: 'Do you want to save the changes?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'yes, save',
        denyButtonText: `Don't save`,
    }).then((result) => {
        console.log(result)
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: `https://localhost:7095/api/RequestItem/NewRequest`,
                data: JSON.stringify(data),
                dataType: 'json',
                headers: {
                    'Content-Type': 'application/json'
                },
                success: function () {
                    Swal.fire('Saved!', '', 'success').then(function () {
                        location.reload();
                    })
                },
                error: function (xhr, ajaxOption, theownError) {
                    Swal.fire('error delete');
                }
            });
        }
    });
}
   /* Swal.fire({
        title: 'Do you want to save the changes?',
        showDenyButton: true,
        showCancelButton: true,
        confirmButtonText: 'yes, save',
        denyButtonText: `Don't save`,
    }).then((result) => {
        console.log(result)
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: 'https://localhost:7095/api/RequestItem/NewRequest',
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                datatype: "json"
            }).done((success) => {
                Swal.fire(

                    'Success',
                    'Request Item Success ! Check Your Email For Further Information',
                    'success'
                );

                $.ajax({
                    url: "https://localhost:7095/api/Item"
                }).done((result) => {

                    $("#input-quantity").val(null);
                    $("#input-start-date").val(null);
                    $("#input-end-date").val(null);
                    $("#input-notes").val(null);
                }).fail((error) => {
                    alert("error");
                });
            }).fail((failed) => {
                Swal.fire('Error', 'Something Went Wrong', 'error');

            });
        }
    })
}*/
        
        

/*function format(d) {
    // `d` is the original data object for the row
    return '<table cellpadding="5" cellspacing="0" border="0" style="padding-left:50px;">' +
        '<tr>' +
        '<td>Request Id:</td>' +
        '<td>' + d.id + '</td>' +
        '</tr>' +
        '<tr>' +
        '<td>Quantity of Requested Item:</td>' +
        '<td>' + d.quantity + ' items</td>' +
        '</tr>' +
        '<tr>' +
        '<td>Notes for the Request:</td>' +
        '<td>' + d.notes + '</td>' +
        '</tr>' +
        '</table>';
}*/


/*$(document).ready(function () {
    $.ajax({
        url: "https://localhost:44395/API/Items"
    }).done((result) => {
        itemAvailable = `<label class="form-control-label" for="input-item">Item</label>
                        <select name="Item" id="input-item" class="form-control form-control-alternative">
                            <option value="" hidden>Choose Item...</option>
                            <option value="1" title="Available ${result.data[0].quantity} Items">Bus</option>
                            <option value="2" title="Available ${result.data[1].quantity} Items">Camera</option>
                            <option value="3" title="Available ${result.data[2].quantity} Items">Car</option>
                           
                        </select>`
        $(".item-available").html(itemAvailable);
    }).fail((error) => {
        alert("error");
    });

    var dataReqItem = $('#tableDataReqItem').DataTable({
        "responsive": true,
        "dom": 'Bfrtip',
        "buttons": [
            { extend: 'excel', text: '<i class="fas fa-file-excel" style="color:green;"></i>', titleAttr: 'Excel' },
            { extend: 'pdf', text: '<i class="fas fa-file-pdf" style="color:crimson;"></i>', titleAttr: 'PDF' },
            { extend: 'print', text: '<i class="fas fa-print"></i>', titleAttr: 'Print' }
        ],
        "ajax": {
            "url": "https://localhost:44389/Employee/Get",
            "datatype": "json",
            "dataSrc": ""
        },
        "columns": [
            {
                'data': 'null',
                'render': function (data, type, row, meta) {
                    return meta.row + meta.settings._iDisplayStart + 1;
                }
            },
            { 'data': 'id' },
            { 'data': 'item' },
            {
                'data': 'startDate',
                'render': function (data) {
                    return moment(data).format('DD-MM-YYYY')
                }
            },
            {
                'data': 'endDate',
                'render': function (data) {
                    return moment(data).format('DD-MM-YYYY')
                }
            },
            { 'data': 'quantity' },
            { 'data': 'status' },
            { 'data': 'notes' },
            {
                'className': 'details-control',
                'orderable': false,
                'data': null,
                'defaultContent': ''
            }
        ],
        "columnDefs": [
            {
                "searchable": false,
                "orderable": false,
                "targets": 0
            },
            {
                "targets": [1],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [5],
                "visible": false,
                "searchable": false
            },
            {
                "targets": [7],
                "visible": false,
                "searchable": false
            }
        ],
        "order": [[1, "desc"]]
    });

    // Add event listener for opening and closing details
    $('#tableDataReqItem tbody').on('click', 'td.details-control', function () {
        var tr = $(this).closest('tr');
        var row = dataReqItem.row(tr);

        if (row.child.isShown()) {
            row.child.hide();
            tr.removeClass('shown');
        }
        else {
            row.child(format(row.data())).show();
            tr.addClass('shown');
        }
    });

    dataReqItem.on('order.dt search.dt', function () {
        dataReqItem.column(0, { search: 'applied', order: 'applied' }).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});*/

/*$('#daterange').daterangepicker({
    //options
    locale: {
        format: 'DD MMM YYYY'
    }
}, function (start, end, label) {
    $('#input-start-date').val(start.format('MM-DD-YYYY'));
    $('#input-end-date').val(end.format('MM-DD-YYYY'));
});

function RequestNewItem() {
    $('#daterange').daterangepicker({
        //options
        locale: {
            format: 'DD MMM YYYY'
        }
    }, function (start, end, label) {
        $('#input-start-date').val(start.format('MM-DD-YYYY'));
        $('#input-end-date').val(end.format('MM-DD-YYYY'));
    });
    var Item = new Object();
    Item.accountId = $('#input-userId').val();
    Item.itemId = $('#input-item').val();
    Item.startDate = $('#input-start-date').val();
    Item.endDate = $('#input-end-date').val();
    Item.quantity = $('#input-quantity').val();
    Item.notes = $('#input-notes').val();
    $.ajax({
        type: "POST",
        url: 'https://localhost:44395/API/RequestItems/NewRequest',
        data: JSON.stringify(Item),
        contentType: "application/json; charset=utf-8",
        datatype: "json"
    }).done((success) => {
        Swal.fire(
            'Success',
            'Request Item Success ! Check Your Email For Further Information',
            'success'
        );
        $('#tableDataReqItem').DataTable().ajax.reload();
        $.ajax({
            url: "https://localhost:44395/API/Items"
        }).done((result) => {
            itemAvailable = `<label class="form-control-label" for="input-item">Item</label>
                        <select name="Item" id="input-item" class="form-control form-control-alternative">
                            <option value="" hidden>Choose Item...</option>
                            <option value="7" title="Available ${result.data[6].quantity} Items">Bus</option>
                            <option value="3" title="Available ${result.data[2].quantity} Items">Camera</option>
                            <option value="6" title="Available ${result.data[5].quantity} Items">Car</option>
                            <option value="5" title="Available ${result.data[4].quantity} Items">HDMI Cable</option>
                            <option value="1" title="Available ${result.data[0].quantity} Items">Laptop</option>
                            <option value="12" title="Available ${result.data[11].quantity} Items">Log Book</option>
                            <option value="11" title="Available ${result.data[10].quantity} Items">Marker</option>
                            <option value="8" title="Available ${result.data[7].quantity} Items">Motorcycle</option>
                            <option value="13" title="Available ${result.data[12].quantity} Items">Multi Purpose Building (Small)</option>
                            <option value="9" title="Available ${result.data[8].quantity} Items">Pick Up Car</option>
                            <option value="2" title="Available ${result.data[1].quantity} Items">Projector</option>
                            <option value="4" title="Available ${result.data[3].quantity} Items">VGA Cable</option>
                            <option value="10" title="Available ${result.data[9].quantity} Items">White Board</option>
                        </select>`
            $(".item-available").html(itemAvailable);
            $("#input-start-date").val(null);
            $("#input-end-date").val(null);
            $("#input-quantity").val(null);
            $("#input-notes").val(null);
        }).fail((error) => {
            alert("error");
        });
    }).fail((failed) => {
        Swal.fire('Error', 'Something Went Wrong', 'error');
    });
}*/
