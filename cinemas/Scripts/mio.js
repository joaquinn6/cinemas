    $('.input-group.date').datepicker({
        format: "dd/mm/yyyy",
        maxViewMode: 0,
        language: "es",
        todayHighlight:true,
        daysOfWeekDisabled: "0",
        autoclose: true,
        todayHighlight: true
    });

$( function() {
    $("#datepicker").datepicker();

    $('.loadAjax').click(function (event) {
        $("#ajaxAc").load(event.target.id);
        $('html,body').animate({
            scrollTop: $("#ajaxAc").offset().top
        }, 2000);
    });


    $('.loadAjaxDetalles').click(function (event) {
        $("#ajaxDe").load(event.target.id);
        $('html,body').animate({
            scrollTop: $("#ajaxDe").offset().top
        }, 2000);
    });



    $('#close1').click(function () {
        $('.modal').hide();
        $('.modal #yvideo1').attr("src", jQuery(".modal #yvideo1").attr("src"));
    });
    $('#close2').click(function () {
        $('.modal').hide();
        $('.modal #yvideo2').attr("src", jQuery(".modal #yvideo2").attr("src"));
    });
});


