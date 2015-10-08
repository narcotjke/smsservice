$(function () {
    $("#fileUpload").uploadify({
        'swf': '/Uploadify/uploadify.swf',
        'uploader': '/Base/Create',
        'cancelImg': '~/Uploadify/uploadify-cancel.png")',
        'auto': false,
        'multi': true,
        'fileDesc': 'xls, xlsx, csv, txt',
        'fileExt': '*.xls, *xlsx, *csv, *txt'
    });

    $('#uploadFiles').on('click', function () {
        $('#fileUpload').uploadify('upload', '*');
    })
});