using SausageGame
    
Game game = new Game(new List<Player>{new Player("Petro"), new Player("Mariyka"), new Player("Vitaliy")}, 52);
game.DealCards(52);
Console.WriteLine("FIRST PLAYER: " + game.getPlayerWithLowestCard());
Console.WriteLine("TRUMP CARD: " + game.GameTrumpCard);

List<Player> players = game.Players;


foreach (Player player in players)
{
    Console.WriteLine(player);
}