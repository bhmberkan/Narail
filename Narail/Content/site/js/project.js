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

//bu k�s�m �al��m�yor normalde t�klad���m�zda renginin de de�i�mesi laz�m de�i�medi
// ya da ben yanl�� yazd�m o k�sm� tam anlamland�ramad�m
//buray� sorars�n 
$('.service-category li').on('click', function () {

    $('li').removeClass('active');
    $(this).addClass('active');

});
