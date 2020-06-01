https://en.m.wikipedia.org/wiki/Swiss_playing_cards
http://a.trionfi.eu/WWPCM/decks/d00143/d00143.htm

https://en.m.wikipedia.org/wiki/Jass


        /*
        // https://medium.com/@naveenrtr/introduction-to-functional-programming-with-c-b167f15221e1
        //
        Func<int, bool> isMod2 = x => x % 2 == 0;
        var list = Enumerable.Range(1, 10);
        var evenNumbers = list.Where(isMod2);
        foreach (int n in evenNumbers)
            Debug.Log(n);
        */

Shuffle: https://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619

https://stackoverflow.com/questions/7332103/query-an-object-array-using-linq
        /*
        var schellen = from card in cards where card.suit == Suit.Schellen select card;

        var schilten = cards
            .Where(card => card.suit == Suit.Schilten)
            .Select(card => card.ToString());
        */

        /*
        var schellenList = new List<Card>(schellen);
        schellenList.Shuffle();

        foreach (Card card in schellenList)
            Debug.Log(card);
        */

https://stackoverflow.com/questions/42550992/c-sharp-sort-list-by-enum

        IEnumerable<Card> sortedCards = cards.OrderBy(card => card.Seq(cards.Length));

        foreach (Card card in sortedCards)
            Debug.Log(card + " " + card.Seq(cards.Length));

https://github.com/Brackeys/Scriptable-Objects/blob/master/Scriptable%20Objects/Assets/CardDisplay.cs
