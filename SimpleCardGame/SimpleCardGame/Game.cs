namespace SimpleCardGame;

public class Game
{
    private Deck deck;
    private List<Player> players;
    private int currentPlayerIndex;

    public Game(List<string> playerNames, uint amountOfCards = 52)
    {
        deck = new Deck(amountOfCards);
        deck.Shuffle();

        players = new List<Player>();
        foreach (string playerName in playerNames)
        {
            players.Add(new Player(playerName));
        }

        currentPlayerIndex = 0;
    }

    public void DealCards(int numCards)
    {
        for (int i = 0; i < numCards; i++)
        {
            foreach (Player player in players)
            {
                Card card = deck.Deal();
                if (card != null)
                {
                    player.AddCardToHand(card);
                }
            }
        }
    }

    public void PlayRound()
    {

    }

    public void PlayGame()
    {
        while (true)
        {
            Console.WriteLine("It is {0}'s turn", players[currentPlayerIndex].Name);
            PlayRound();
        }
    }
}
