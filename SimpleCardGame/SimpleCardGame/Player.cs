namespace SimpleCardGame;

public class Player
{
    public string Name { get; }
    public List<Card> Hand { get; }

    public Player(string name)
    {
        Name = name;
        Hand = new List<Card>();
    }

    public void AddCardToHand(Card card)
    {
        Hand.Add(card);
    }

    public void RemoveCardFromHand(Card card)
    {
        Hand.Remove(card);
    }

    public void ClearHand()
    {
        Hand.Clear();
    }
}
