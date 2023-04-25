namespace SausageGame;

public class Game
{
    static private Deck deck;
    private List<Player> players;
    private int currentPlayerIndex;
    private Card gameTrumpCard;

    public Game(List<Player> gamePlayers, uint amountOfCards = 52)
    {
        deck = new Deck(amountOfCards);
        deck.Shuffle();

        players = new List<Player>();
        foreach (Player player in gamePlayers)
        {
            players.Add(player);
        }

        currentPlayerIndex = 0;
        gameTrumpCard = deck.Deal();
    }

    public List<Player> Players
    {
        get => players;
        set => players = value ?? throw new ArgumentNullException(nameof(value));
    }

    public static Deck Deck
    {
        get => deck;
        set => deck = value ?? throw new ArgumentNullException(nameof(value));
    }

    public Card GameTrumpCard
    {
        get => gameTrumpCard;
        set => gameTrumpCard = value ?? throw new ArgumentNullException(nameof(value));
    }

    public void DealCards(int numCards)
    {
        for (int i = 0; i < numCards; i++)
        {
            foreach (Player player in players)
            {
                Card card = deck.Deal();
                if (card != null && player.Hand.Count < 6)
                {
                    player.AddCardToHand(card);
                }
            }
        }
    }
}
