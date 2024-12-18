
    // Fill District Dropdown in Tehsil form

    $(document).ready(function () {
        $('#upProvince').hide();
    $('#H2').hide();
        $('#upDistrict').hide();
        $('#H2Dist').hide();
        $(".sidebar-menu .active").removeClass('active');
        $('#area').addClass("active");

        $("#proTehI").change(function () {
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
    var s = '<option value="-1">-- Select District --</option>';
                    for (var i = 0; i < re.length; i++) {
        s += '<option value="' + re[i].Value + '">' + re[i].Text + '</option>';
    }
                    $("#districtDrop").html(s);

                }
            })
        });
    });

    //End of Fill District Dropdown in Tehsil form
    // Fill District Dropdown in UC form

    $(document).ready(function () {
        $("#proUcI").change(function () {
            var id = $(this).val();
            $.ajax({
                //type: "GET",
                url: "/AdminPanel/drop",
                cache: false,
                type: "POST",
                //data: data,
                data: { id: id },
                success: function (re) {

                    console.log(re);
                    var s = '<option value="-1">-- Select District --</option>';
                    for (var i = 0; i < re.length; i++) {
                        s += '<option value="' + re[i].Value + '">' + re[i].Text + '</option>';
                    }
                    $("#districtUcDrop").html(s);

                }
            })
        });
    });

    //End of Fill District Dropdown in UC form

    // Fill Tehsil Dropdown in UC form
    $(document).ready(function () {
        $("#districtUcDrop").change(function () {
            var id = $(this).val();
            $.ajax({
                //type: "GET",
                url: "/AdminPanel/dropUC",
                cache: false,
                type: "POST",
                //data: data,
                data: { id: id },
                success: function (re) {

                    console.log(re);
                    var s = '<option value="-1">-- Select Distric --</option>';
                    for (var i = 0; i < re.length; i++) {
                        s += '<option value="' + re[i].Value + '">' + re[i].Text + '</option>';
                    }
                    $("#tehsilUcDrop").html(s);

                }
            })
        });
    });

    //End of Fill Tehsil Dropdown in UC form


    //UC Ajax End
   // getProvince Data for Update
    function getProForUp(id) {
        $('#H1').hide();
    $('#H2').show();
        $('#subProvince').hide();
        $('#upProvince').show();
        var id = id;
        $.ajax({
        type: "POST",
            url: "/AdminPanel/chkProForUp",
            //data: data,
            data: {id: id },
            success: function (re) {
        console.log(re);
    $("#pName").val(re.ProvinceName);
                $('#pId').val(re.ProvinceId);
                $('#addProvince').click();
            }
        });

    }

    function updateProvince(){
        var proName = $s('#pName').val();
        var proId = $('#pId').val();
        $.ajax({
        type: "POST",
            url: "/AdminPanel/updateProvince",
            //data: data,
            data: {
        ProvinceName: proName,
                ProvinceId: proId
            },
            success: function (re) {
        swal({
            title: "Good job!",
            text: "Successfully Updated!",
            icon: "success",
            button: true,

        }).then((value) => {

            location.reload();
        });
    }

        })
    }

    //open Province model button  to hide some Data
    $('#addProvince').click(function () {
        $('#upProvince').hide();
    $('#H2').hide();
        $('#subProvince').show();
        $('#H1').show();
        $('#pName').val('');
        $('#pId').val('');

    })
    //open District model button to hide some Data
    $('#AddDistrictBtn').click(function () {
        $('#upDistrict').hide();
    $('#H2Dist').hide();
        $('#subDistrict').show();
        $('#H1Dist').show();
        $('#districtName').val('');

        $('#disIdModel').val('');

    })
    function getDistForUp(id) {
        $('#H1Dist').hide();
    $('#H2Dist').show();
        $('#subDistrict').hide();
        $('#upDistrict').show();
        var id = id;
        $.ajax({
        type: "POST",
            url: "/AdminPanel/chkDisForUp",
            //data: data,
            data: {id: id },
            success: function (re) {
        console.log(re);
    $('#districtName').val(re.DistrictName);
                $("#proI").val(re.ProvinceId);
                $('#disIdModel').val(re.DistrictId);
                $('#AddDistrictBtn').click();
            }
        });

    }
    function updateDistrict() {
        var disId = $('#disIdModel').val();
            var disName = $('#districtName').val();
            var proId = $("#proI :selected").val();
            console.log(proId);
            $.ajax({
        type: "POST",
                url: "/AdminPanel/UpdateDistrict",
                //data: data,
                data: {
        DistrictName: disName,
                    ProvinceId: proId,
                    DistrictId: disId
                },
                success: function (re) {

        swal({
            title: "Good job!",
            text: "Successfully Inserted!",
            icon: "success",
            button: true,

        }).then((value) => {

            location.reload();
        });
    }
            })


    }

    //get Tehsil For Update
    function getTehForUp(id) {
        $('#H1Teh').hide();
    $('#H2Teh').show();
        $('#subTeh').hide();
        $('#upTeh').show();
        var id = id;
        $.ajax({
        type: "POST",
            url: "/AdminPanel/chkTehForUp",
            //data: data,
            data: {id: id },
            success: function (re) {
        console.log(re);
    $('#TehsilName').val(re.TehsilName);
                $('#TehIdForUp').val(re.TehsilId);
                  //  $("#districtDrop").val(re.DistrictId);
                    $('#AddTehsilBtn').click();
                }
            });

    }
    //Update Tehsil
    function UpdateTehsil() {
      
        var tehName = $('#TehsilName').val();
        var disId = $("#districtDrop :selected").val();
        var TehId = $('#TehIdForUp').val();

            $.ajax({
        type: "POST",
                url: "/AdminPanel/UpdateTehsil",
                //data: data,
                data: {
        TehsilName: tehName,
                    TehsilId: TehId,
                    DistrictId: disId
                },
                success: function (re) {

        swal({
            title: "Good job!",
            text: "Tehsil Successfully Updted!",
            icon: "success",
            button: true,

        }).then((value) => {

            location.reload();
        });
    }
            })
    }
    //Add Tehsil Button to open Model
    $('#AddTehsilBtn').click(function () {
        $('#H1Teh').show();
    $('#H2Teh').hide();
        $('#subTeh').show();
        $('#upTeh').hide();
        $('#TehsilName').val('');
        $('#TehIdForUp').val('');

    });

    function UpdateUC() {

        var ucName = $('#UCName').val();
        var tehId = $("#tehsilUcDrop :selected").val();
        var ucId = $('#txtUcId').val();
        $.ajax({
        type: "POST",
            url: "/AdminPanel/UpdateUc",
            //data: data,
            data: {
        UCName: ucName,
                UcId: ucId,
                TehsilId: tehId
            },
            success: function (re) {

        swal({
            title: "Good job!",
            text: "Town Successfully Updated!",
            icon: "success",
            button: true,

        }).then((value) => {

            location.reload();
        });
    }
        })
    }

    function getUcForUp(id) {
        $('#H1Uc').hide();
    $('#H2Uc').show();
            $('#subUc').hide();
            $('#upUc').show();
            var id = id;
            $.ajax({
        type: "POST",
                url: "/AdminPanel/chkUcForUp",
                //data: data,
                data: {id: id },
                success: function (re) {
        console.log(re);
    $('#UCName').val(re.UCName);
                    $('#txtUcId').val(re.UcId);
                    $("#tehsilUcDrop :selected").val(re.TehsilId);
                    //  $("#districtDrop").val(re.DistrictId);
                    $('#AddUcBtn').click();
                }
            });
    }

    $('#AddUcBtn').click(function () {
        $('#UCName').val("");
    $('#txtUcId').val("");
        $("#tehsilUcDrop :selected ").val();
        $('#H1Uc').show();
        $('#H2Uc').hide();
        $('#subUc').show();
        $('#upUc').hide();
    })
