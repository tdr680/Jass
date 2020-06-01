using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Hold : MonoBehaviour, IPointerClickHandler
{
    [SerializeField]
    private Card _card;

    public Text seqText;
    public Text valueText;
    public Image cardImage;

    public Hand hand;

    public Card card
    {
        get => _card;
        set
        {
            _card = value;
            if (_card != null)
            {
                int noOfCards = GameManager.instance.cards.Length;
                int noOfHands = GameManager.instance.hands.Length;
                Game game = GameManager.instance.game;
                cardImage.sprite = _card.pic;
                seqText.text = ((_card.Seq(noOfCards, game) % (noOfCards / noOfHands)) + 1).ToString();
                valueText.text = _card.Value(game).ToString();
            }
            else
            {
                cardImage.sprite = null;
                seqText.text = "0";
                valueText.text = "0";
            }
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (hand != null && Array.Exists(hand.holds, element => element == this)) // does this hold belongs to a hand (and not to drawn card or tricks)
        {
            if (GameManager.instance.Turn(this))
            {
                hand.draw.card = card;
                Destroy(this.gameObject);
            }
        }
    }

    void Awake()
    {
        
    }

    void Start()
    {
        hand = transform.parent.GetComponent<Hand>();
    }
}
