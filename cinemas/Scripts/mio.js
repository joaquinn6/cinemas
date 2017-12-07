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

    
});

$("#close1").click(function () {
    var src = $("#yvideo1").attr("src");
    $("#yvideo1").attr("src", "");
    $("#yvideo1").attr("src", src);
});
