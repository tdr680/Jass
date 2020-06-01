using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Value
{
    public int nebenfarbe;
    public int trumpf;
    public int obenabe;
    public int undenufe;
}

[System.Serializable]
public struct Seq
{
    public int nebenfarbe;
    public int trumpf;
    public int obenabe;
    public int undenufe;
}

[CreateAssetMenu(fileName = "New Rank", menuName = "Rank")]
public class Rank : ScriptableObject
{
    public Value value;
    public char label;
    public Seq seq;

    public override string ToString()
    {
        return label + " - "
             + " nebenfarbe: " + value.nebenfarbe 
             + " / trumpf: "   + value.trumpf 
             + " / obenabe: "  + value.obenabe
             + " / undenufe: " + value.undenufe;
    }

    public int Seq(Game game, Suit suit)
    {
        switch (game)
        {
            case Game.Undeufe:
                return seq.undenufe;
            case Game.Obenabe:
                return seq.obenabe;
            default:
                if (suit.IsTrumpf())
                    return seq.trumpf;
                else
                    return seq.nebenfarbe;
        }
    }

    public int Value(Game game, Suit suit)
    {
        switch (game)
        {
            case Game.Undeufe:
                return value.undenufe;
            case Game.Obenabe:
                return value.obenabe;
            default:
                if (suit.IsTrumpf())
                    return value.trumpf;
                else
                    return value.nebenfarbe;
        }
    }
}

