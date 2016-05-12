function xxx(x){
    console.info(x)
}
console.info('lololo');
$.ajax({
    crossDomain: true,
    url: 'http://nideas.com/test',
    context: document.body
}).done(function(data) {
    $( this ).addClass( 'done' );
    console.info(data);
});