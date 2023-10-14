// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
//chỉnh nội dung trong bảng
const tds = document.querySelectorAll('.table_user td');

tds.forEach(td => {
    td.addEventListener('mouseover', () => {
        td.classList.add('full-content');
    });

    td.addEventListener('mouseout', () => {
        td.classList.remove('full-content');
    });
});