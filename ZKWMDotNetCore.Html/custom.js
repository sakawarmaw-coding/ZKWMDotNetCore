function uuidv4() {
    return ([1e7]+-1e3+-4e3+-8e3+-1e11).replace(/[018]/g, c =>
      (c ^ crypto.getRandomValues(new Uint8Array(1))[0] & 15 >> c / 4).toString(16)
    );
}

function successMessage(message){
    // Swal.fire({
    //     title: "Success!",
    //     text: message,
    //     icon: "success"
    //   });

    Notiflix.Report.success(
        'Success!',
        message,
        'Ok',
    );
}

function errorMessage(message){
    // Swal.fire({
    //     title: "Error!",
    //     text: message,
    //     icon: "error"
    //   });

    Notiflix.Report.failure(
        'Error!',
        message,
        'Ok',
    );
}

function confirmMessage(message) {
    let confirmMessageResult = new Promise(function (success, error) {
        // Swal.fire({
        //     title: "Confirm",
        //     text: message,
        //     icon: "warning",
        //     showCancelButton: true,
        //     confirmButtonText: "Yes"
        // }).then((result) => {
        //     if (result.isConfirmed) {
        //         success(); 
        //     }
        //     else{
        //         error();
        //     }
        // });

        Notiflix.Confirm.show(
            'Confirm',
            message,
            'Yes',
            'No',
            function okCb() {
                success(); // when successful
            },
            function cancelCb() {
                error();  // when error
            }
        );
    
    });

    return confirmMessageResult;
}
