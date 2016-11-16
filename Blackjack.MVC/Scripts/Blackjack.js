$()
    .ready(function () {
        $('#go')
            .click(function () {
                LoadGame();
            });
        $('#addPlayer').click(function () { AddPlayer(); });
    });

function LoadGame() {
        
    $.ajax({
        url: url+ '/api/game',
        method: 'post',
        crossDomain: true,
        data: {
            NumbersOfDecksInShoe: $('#NumbersOfDecksInShoe').val(),
            DealerHitsSoftSeventeen: $('#DealerHitsSoftSeventeen').find(':selected').val(),
            Players: GetPlayerData()
        }
    }).done(function (result) {
            $.post(
                "/home/Results",
                { result: result },
                function(output) {MarkupOutput(output);}
        );

    });
}

function MarkupOutput(output) {
    $('.player-entry').hide();
    $('#Results').html(output);
}

function AddPlayer() {
    $('#Results').html('<div id="Results"> </div>');
    $.ajax({
        url: '/home/AddPlayer',
        method: 'post'
    }).done(function (markup) { $('#players').append(markup); });
}

function GetPlayerData() {
    var playerRows = $('#players').find('.row');
    var playerData = [];
    for (i = 0; i < playerRows.length; i++) {
        var row = $(playerRows[i]);
        playerData.push({
            Name: row.find('#Name').val(),
            StartingBalance: row.find('#StartingBalance').val(),
            HitSoftSeventeen: row.find('#HitSoftSeventeen').find(':selected').val()
        });
    }
    return playerData;
}

