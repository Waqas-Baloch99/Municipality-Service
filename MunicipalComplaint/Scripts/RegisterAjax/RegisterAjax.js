$('#btnUserModalClose').on('click', function () {
        $('#Register').modal('hide');
    });

    // Fill Tehsil Dropdown in UC form
$(document).ready(function () {
        $('#BtnUpdate').hide();
    $('#H2').hide();
        //Datatable
        $(".sidebar-menu .active").removeClass('active');
        $('#register').addClass("active");

        $('#provinceDrop').change(function () {
            var id = $(this).val();
            $.ajax({
        //type: "GET",
        url: "/AdminPanel/drop",
                cache: false,
                type: "POST",
                //data: data,
                data: {id: id },
                success: function (re) {

        console.log(re);
    var s = '<option value="selected disabled" > --Select District --</option>';
                    for (var i = 0; i < re.length; i++) {
        s += '<option value= "' + re[i].Value + '" > ' + re[i].Text + '</option> ';
    }
                    $("#districtDrop").html(s);

                }
            })
        });

        $('#usertbl').DataTable({
            "paging": true,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": true,
        });


    });
    //End of Fill Tehsil Dropdown in UC form
   
    function updateuser(id) {
        $('#BtnRegister').hide();
    $('#BtnUpdate').show();
        $('#H2').show();
        $('#H1').hide();
        var id = id;
        $.ajax({
        type: "POST",
            url: "/AdminPanel/ChkUpdateUser",
            data: {id: id },
            success: function (re) {
        $('#userid').val(re.UserId);
    $('#Username').val(re.Username);
                $("#districtDrop").val(re.DistrictId);
                $('#Email').val(re.Email);
                $('#CNIC').val(re.CNIC);
                $('#Contact').val(re.Contact);
                $('#Address').val(re.Address);
                $("#roleDrop ").val(re.Type);
                $("#usermodel").click()
            }
        });
    }
    $('#usermodel').click(function () {
        $('#BtnUpdate').hide();
    $('#H2').hide();
        $('#BtnRegister').show();
        $('#H1').show();
        var Username = $('#Username').val("");
        var disId = $("#districtDrop ").val("");
        var Email = $('#Email').val("");
        var CNIC = $('#CNIC').val("");
        var Contact = $('#Contact').val("");
        var Address = $('#Address').val("");
        var Type = $("#roleDrop ").val("");
    });


    function sendUpdateForm() {
        var Uid = $('#userid').val();
        var Username = $('#Username').val();
        var disId = $("#districtDrop :selected").val();
        var Email = $('#Email').val();
        var CNIC = $('#CNIC').val();
        var Contact = $('#Contact').val();
        var Address = $('#Address').val();
        var Type = $("#roleDrop :selected").val();

        $.ajax({
        type: "POST",
            url: "/AdminPanel/UpdateUser",
            //data: data,
            data: {
        UserId: Uid,
                Username: Username,
                DistrictId: disId,
                Contact: Contact,
                CNIC: CNIC,
                Email: Email,
                Address: Address,
                Type: Type
            },
            success: function (re) {

        swal({
            title: "Good job!",
            text: "Successfully Updated!",
            icon: "success",
            button: true,

        }).then((value) => {
            //swal("Reloading Informtion, Please wait...");
            location.reload();
        });
    }
        });

    }
    function suspenduser(id) {
        $.ajax({
            type: "POST",
            url: "/AdminPanel/BlockUser",
            //data: data,
            data: {
                id: id
            },
            success: function (re) {
                swal({
                    title: "Good job!",
                    text: "Successfully Blocked!",
                    icon: "success",
                    button: true,
                }).then((value) => {
                    //swal("Reloading Informtion, Please wait...");
                    location.reload();
                });
            }
        });
    }

    function unblockuser(id) {
        $.ajax({
            type: "POST",
            url: "/AdminPanel/UnblockUser",
            data:
            {
                id: id
            },
            success: function (re) {
                swal({
                    title: "Good job!",
                    text: "Successfully Unblocked",
                    icon: "success",
                    button: true,
                }).then((value) => {
                    //swal("Reloading Informtion, Please wait...");
                    location.reload();
                });
            }
        })
    }
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });