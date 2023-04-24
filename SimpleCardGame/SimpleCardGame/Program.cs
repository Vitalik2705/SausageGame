using SimpleCardGame;

Deck testDeck = new Deck(36);

Game game = new Game(new List<Player>{new Player("Petro"), new Player("Mariyka"), new Player("Vitaliy")}, 52);
game.DealCards(52);
Console.WriteLine("FIRST PLAYER: " + game.getPlayerWithLowestCard());
Console.WriteLine("TRUMP CARD: " + game.GameTrumpCard);

List<Player> players = game.Players;


foreach (Player player in players)
{
    Console.WriteLine(player);
}

foreach (Player player in players)
{
    List<Card> playerNonTrumpCards = game.getLowestNonTrumpCards(player, game.GameTrumpCard.Suit);
    Console.WriteLine(player.Name);
    foreach (var card in playerNonTrumpCards)
    {
        Console.WriteLine(card);
    }
}

Console.WriteLine("---------Lowest trump card for each player---------");
foreach (Player player in players)
{
    Card playerLowestTrumpCard = game.getLowestTrumpCard(player, game.GameTrumpCard.Suit);
    Console.WriteLine(player.Name);
    Console.WriteLine(playerLowestTrumpCard);
}