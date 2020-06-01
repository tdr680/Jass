using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Suit
{
    Eicheln,
    Rosen,
    Schellen,
    Schilten
}

[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public Suit suit;
    public Rank rank;
    public Sprite pic;

    public override string ToString()
    {
        return suit + " - " + rank.ToString();
    }

    public int Seq(int noOfCards, Game game)
    {
        return (int)suit * (noOfCards / Enum.GetNames(typeof(Suit)).Length) + rank.Seq(game, suit);
    }

    public int Value(Game game)
    {
        return rank.Value(game, suit);
    }
}

public static class SuitExtension
{
    public static Game game;

    public static bool IsTrumpf(this Suit suit)
    {
        bool isTrumpf = false;
        switch (game)
        {
            case Game.Eicheln:
                if (suit == Suit.Eicheln)
                    isTrumpf = true;
                break;
            case Game.Rosen:
                if (suit == Suit.Rosen)
                    isTrumpf = true;
                break;
            case Game.Schellen:
                if (suit == Suit.Schellen)
                    isTrumpf = true;
                break;
            case Game.Schilten:
                if (suit == Suit.Schilten)
                    isTrumpf = true;
                break;
            default:
                break;
        }
        return isTrumpf;
    }
}
