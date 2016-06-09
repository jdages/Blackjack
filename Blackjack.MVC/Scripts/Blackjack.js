$()
    .ready(function() {
        $('#go')
            .click(function() {
                LoadGame();
            });
    });

function LoadGame() {
    $.ajax({
        url: 'http://localhost:5370/api/game',
        method: 'post',
        data:{
            NumbersOfDecksInShoe: $('#NumbersOfDecksInShoe').val(),
            DealerHitsSoftSeventeen: $('#DealerHitsSoftSeventeen').find(':selected').val(),
            Players:[]
        }
    });
}