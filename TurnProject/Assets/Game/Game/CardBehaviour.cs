using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CardBehaviour : MonoBehaviour
{
    public int number { get; private set; }
    
    public GameEnums.Colors color { get; private set; }

    public GameEnums.Special special { get; private set; }

    private Sprite s;
    public void CreateCardBehaviour(ScriptableCard card)
    {
        number = card.GetCardNumber();
        color = card.GetCardColor();
        special = card.GetSpecialType();
        s = card.GetSprite();
    }
    private void Awake()
    {
        gameObject.GetComponent<Image>().sprite = s;
    }
    public void OnClicked()
    {
        if (PlayerManager.instance.ismoving)
            return;


        if(special == 0)
            GameEvents.OnMovePlayer(number);
        else
        {
            switch(special)
            {
                case GameEnums.Special.Plus4:
                    ScriptableCard[] cardsToBuy = PlayerManager.instance.GetRandomCards(4);
                    foreach(ScriptableCard card in cardsToBuy)
                    {
                        PlayerManager.instance.GetNextPlayer().BuyCard(card);
                    }
                    break;

                case GameEnums.Special.ChangeBoard:

                    break;
            }
        }


        PlayerManager.instance.ismoving = true;

        GameEvents.OnCardUsed(gameObject);
    }
}
