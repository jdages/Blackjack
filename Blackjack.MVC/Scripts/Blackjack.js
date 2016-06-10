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
        var message = '';
        for (i = 0; i < result.length; i++) {
            message += result[i].Name + ' won ' + (result[i].EndingBalance - result[i].StartingBalance);
        }
        alert(message);
    });
}

//function AddResult(result) {
//    var outcomes = []; 
//    for (i = 0; i < result.length; i++) {
//        outcomes.push({
//            Name : result[i].Name,
//            StartingBalance: result[i].StartingBalance,
//            EndingBalance: result[i].EndingBalance,
//            Wins: result[i].Wins,
//            Losses: result[i].Losses,
//            Pushes:result[i].Pushes
//        });
//    }
//    $.ajax({
//        url: '/home/Results',
//        method: 'post',
//        data:outcomes
//    }).done(function(markup) {
//        var message = '';
//        for (i = 0; i < markup.length; i++) {
//            message += markup[i].Name + ' won ' + (markup.EndingBalance - markup.StartingBalance);
//        }
//        alert(message);
//    });
//}

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
        var row = $(playerRows[i]);
        playerData.push({
            Name: row.find('#Name').val(),
            StartingBalance: row.find('#StartingBalance').val(),
            HitSoftSeventeen: row.find('#HitSoftSeventeen').find(':selected').val()
        });
    }
    return playerData;
}

