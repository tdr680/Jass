using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Game
{
    Eicheln,
    Rosen,
    Schellen,
    Schilten,
    Obenabe,
    Undeufe
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Card[] cards;
    public Hand[] hands;
    public Trick[] tricks;
    public Game game;

    public int handOnTurn;
    public int turnsInRound;
    public int round;    
    
    bool paused = false;

    void Start()
    {
        SelectGame();
        cards.Shuffle();
        SortHands();
        Deal();
        handOnTurn = new System.Random().Next(hands.Length);
        turnsInRound = 0;
        round = 0;
        foreach (Trick trick in tricks)
            foreach (Hold hold in trick.holds)
                hold.card = null;
    }

    void SelectGame()
    {
        Array games = Enum.GetValues(typeof(Game));
        game = (Game)games.GetValue(new System.Random().Next(games.Length));
        SuitExtension.game = game;
    }

    void SortHands()
    {
        int n = cards.Length / hands.Length;
        for (int i = 0; i < hands.Length; i++)
            Array.Sort(cards, i * n, n, new CardComparer(cards.Length, game));
    }

    void Deal()
    {
        int c = 0;
        foreach (Hand hand in hands)
            foreach (Hold hold in hand.holds)
                hold.card = cards[c++];
    }

    public bool Turn(Hold hold)
    {
        if (paused)
            return false;

        if (Array.IndexOf(hands, hold.hand) != handOnTurn)
            return false;

        handOnTurn = (handOnTurn + 1) % hands.Length;
        turnsInRound++;
        if (turnsInRound == hands.Length)
            StartCoroutine(TrickCoroutine());

        return true;
    }

    IEnumerator TrickCoroutine()
    {
        paused = true;
        yield return new WaitForSeconds(2);

        int h = 0;
        foreach (Hand hand in hands)
        {
            tricks[round].holds[h].card = hand.draw.card;
            hand.draw.card = null;
            h = (h + 1) % tricks[round].holds.Length;
        }

        turnsInRound = 0;
        round++;
        paused = false;
    }

    void Awake()
    {
        instance = this;
    }
}


public class CardComparer : IComparer<Card>
{
    private int _noOfCards;
    private Game _game;

    public CardComparer(int noOfCards, Game game)
    {
        _noOfCards = noOfCards;
        _game = game;
    }

    public int Compare(Card x, Card y)
    {
        int xSeq = x.Seq(_noOfCards, _game);
        int ySeq = y.Seq(_noOfCards, _game);
        if (xSeq < ySeq)
            return -1;
        if (xSeq > ySeq)
            return 1;
        return 0;
    }
}

static class ShuffleExtension
{
    private static System.Random rng = new System.Random();

    public static void Shuffle<T>(this IList<T> list)
    {  
        int n = list.Count;
        while (n > 1) {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
