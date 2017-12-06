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
    $( "#datepicker" ).datepicker();
  } );