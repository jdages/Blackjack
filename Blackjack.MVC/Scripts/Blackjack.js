$()
    .ready(function() {
        $('#go')
            .click(function() {
                LoadGame();
            });
        $('#addPlayer').click(function() { AddPlayer(); });
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

function AddPlayer() {
    $.ajax({
        url: '/home/AddPlayer',
        method: 'post'
    }).done(function (markup) { $('#players').append(markup); });
}

