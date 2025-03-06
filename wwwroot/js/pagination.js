$(document).ready(function () {
    $('#datatable').DataTable({
        paging: true,           // Enable pagination
        pageLength: 5,          // Set the default number of rows per page
        lengthChange: true,     // Allow users to change the page length
        searching: true,        // Enable search functionality
        ordering: true,         // Enable ordering of columns
        info: true,             // Show information about total records
        autoWidth: false,       // Disable automatic column width calculation
        responsive: true        // Make the table responsive
    });
});