$(document).ready(function () {

    $('#software').click(function () {
        $('#softwareDiv').show();
        $('#humanDiv').hide();
        $('#financeDiv').hide();

    });

    $('#human').click(function () {
        $('#humanDiv').show();
        $('#softwareDiv').hide();
        $('#financeDiv').hide();

    });

    $('#finance').click(function () {
        $('#financeDiv').show();
        $('#humanDiv').hide();
        $('#softwareDiv').hide();


    });

});

//bu kýsým çalýþmýyor normalde týkladýðýmýzda renginin de deðiþmesi lazým deðiþmedi
// ya da ben yanlýþ yazdým o kýsmý tam anlamlandýramadým
//burayý sorarsýn 
$('.service-category li').on('click', function () {

    $('li').removeClass('active');
    $(this).addClass('active');

});
