namespace SimpleCardGame;

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

    //Робимо огляд карт кожного гравця та визначаємо в кого найменша козирна карта, цей гравець розпочне гру
    public Player getPlayerWithLowestCard()
    {
        Player playerWithLowestCard = null;
        Card lowestTrumpCard = null;

        var lowestTrumpCards =
            players.ToDictionary(player => player, player => player.getLowestTrumpCard(gameTrumpCard.Suit))
                .Where(kvp => kvp.Value != null)
                .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        playerWithLowestCard = lowestTrumpCards.OrderBy(pair => pair.Value).Select(pair => pair.Key).FirstOrDefault();

        if (playerWithLowestCard == null)
        {
            var lowestCards =
                players.ToDictionary(player => player, player => player.getLowestCard())
                    .Where(kvp => kvp.Value != null)
                    .ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
            playerWithLowestCard = lowestCards.OrderBy(pair => pair.Value).Select(pair => pair.Key).FirstOrDefault();
        }
        
        return playerWithLowestCard;
    }

    public void PlayRound()
    {
        
    }

    // Отримати список найменших не козирних карт гравця
    // список - тому що він може мати дві "однакові" карти
    public List<Card> getLowestNonTrumpCards(Player player, Suit trumpSuit)
    {
        var nonTrumpCards = player.Hand.Where(card => card.Suit != trumpSuit);
        
        if (nonTrumpCards.Count() == 0)
        {
            return new List<Card>();
        }
        
        var lowestNonTrumpCard = nonTrumpCards.OrderBy(card => card).First();

        var lowestNonTrumpCards = player.Hand.Where(card => card.Suit != trumpSuit && card.CompareTo(lowestNonTrumpCard) == 0);

        return lowestNonTrumpCards.ToList();
    }
    
    // Отримати список найменшу козирну карту гравця
    public Card getLowestTrumpCard(Player player, Suit trumpSuit)
    {
        var trumpCards = player.Hand.Where(card => card.Suit == trumpSuit);
        
        if (trumpCards.Count() == 0)
        {
            return null;
        }
        
        var lowestTrumpCard = trumpCards.OrderBy(card => card).First();

        return lowestTrumpCard;
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
