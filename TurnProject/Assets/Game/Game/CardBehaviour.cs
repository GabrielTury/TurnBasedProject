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
    private CardBehaviour(ScriptableCard card)
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

    }
}
