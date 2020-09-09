// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    $(".open-info-modal").click(function () {
        let id = $(this).data("id");

        $.ajax({
            url: "/credits/details/" + id,
            type: "get",
            dataType: "html",
            beforeSend: function () {
                $(".loader").removeClass("d-none");
            },
            success: function (response) {
                $('#creditInfoModal').find(".modal-body").html(response);
            },
            error: function (error) {
                console.log(error);
            },
            complete: function () {
                $(".loader").addClass("d-none");
                $('#creditInfoModal').modal('show');
            }
        });

        $.ajax({
            url: "/credits/detailsjson/" + id,
            type: "get",
            dataType: "json",
            beforeSend: function () {
                $(".loader").removeClass("d-none");
            },
            success: function (response) {
                console.log(response.person.name);
            },
            error: function (error) {
                console.log(error);
            },
            complete: function () {
                $(".loader").addClass("d-none");
                $('#creditInfoModal').modal('show');
            }
        });

       
    });
})