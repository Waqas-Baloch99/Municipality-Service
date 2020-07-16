function deleteProvince(id) {
    var id = id;

    swal({
        title: "Are you sure?",
        text: "Once deleted,  you'r all record related to Province will be delete!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "POST",
                    url: "/AdminPanel/DelProvince",
                    //data: data,
                    data: { id: id },
                    success: function (re) {
                        swal({
                            title: "Good job!",
                            text: "Poof! Your Record has been deleted!!",
                            icon: "success",
                            button: true,

                        }).then((value) => {

                            location.reload();
                        });
                    }
                });

            } else {
                swal("Your Record is safe!")
            }
        });
}

//District Delete

function deleteDistrict(id) {
    var id = id;

    swal({
        title: "Are you sure?",
        text: "Once deleted,  you'r all record related to District will be delete!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "POST",
                    url: "/AdminPanel/DelDistrict",
                    //data: data,
                    data: { id: id },
                    success: function (re) {
                        swal({
                            title: "Good job!",
                            text: "Poof! Your Record has been deleted!!",
                            icon: "success",
                            button: true,

                        }).then((value) => {

                            location.reload();
                        });
                    }
                });

            } else {
                swal("Your Record is safe!")
            }
        });


}

//Tehsil Delete

function deleteTehsil(id) {
    var id = id;

    swal({
        title: "Are you sure?",
        text: "Once deleted,  you'r all record related to Tehsil will be delete!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "POST",
                    url: "/AdminPanel/DelTehsil",
                    //data: data,
                    data: { id: id },
                    success: function (re) {
                        swal({
                            title: "Good job!",
                            text: "Poof! Your Record has been deleted!!",
                            icon: "success",
                            button: true,

                        }).then((value) => {

                            location.reload();
                        });
                    }
                });

            } else {
                swal("Your record is safe!")
            }
        });


}

//Delete Uc

function deleteUc(id) {
    var id = id;

    swal({
        title: "Are you sure?",
        text: "Once deleted, you'r all record related to Town will be delete!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                $.ajax({
                    type: "POST",
                    url: "/AdminPanel/DelUc",
                    //data: data,
                    data: { id: id },
                    success: function (re) {
                        swal({
                            title: "Good job!",
                            text: "Poof! Your Record has been deleted!!",
                            icon: "success",
                            button: true,

                        }).then((value) => {

                            location.reload();
                        });
                    }
                });

            } else {
                swal("Your Record is safe!")
            }
        });


}