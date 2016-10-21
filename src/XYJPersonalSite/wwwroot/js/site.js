// Write your Javascript code.

$(function () {
    $('#tags').load('/tags/index');
});

// $(document).ready(function () {
//     $('#comment_button').click(function () {
//         txt = $('#comment_form').serialize();
//         $.post('/comments/create', txt, function (result) {
//             alert(result);
//         });
//     });
// });
