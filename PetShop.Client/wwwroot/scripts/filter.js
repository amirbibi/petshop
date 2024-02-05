// Filter table in catalog page
$('#categoryDropdown').on('change', function () {
    var selectedCategory = $(this).val();

    if (selectedCategory === 'All') {
        $('tbody tr').show();
    } else {
        $('tbody tr').hide();
        $('tbody tr[data-category="' + selectedCategory + '"]').show();
    }
});
