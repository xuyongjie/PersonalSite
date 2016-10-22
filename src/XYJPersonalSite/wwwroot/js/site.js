// Write your Javascript code.

$(function () {
    $('#tags').load('/tags/index');
});

$(function () {
    $('#articles-dropdown-ul').load('/blogtypes/index');
});

// $(document).ready(function () {
//     $('#comment_button').click(function () {
//         txt = $('#comment_form').serialize();
//         $.post('/comments/create', txt, function (result) {
//             alert(result);
//         });
//     });
// });
