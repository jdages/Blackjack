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
            Players:GetPlayerData()
        }
    });
}

function AddPlayer() {
    $.ajax({
        url: '/home/AddPlayer',
        method: 'post'
    }).done(function (markup) { $('#players').append(markup); });
}

function GetPlayerData() {
    var playerRows = $('#players').find('.row');
    var playerData = [];
    for (i = 0; i < playerRows.length; i++) {
        playerData.push({
            Name: $(playerRows[i]).find('#Name').val(),
            StartingBalance: 23,
            HitSoftSeventeen:true
        });
    }
    return playerData;
}