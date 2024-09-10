using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Card", menuName = "Game/Card")]

public class ScriptableCard : ScriptableObject
{
    [Tooltip("Number that will appear visually and determine movement amount")]
    public int number { get; private set; }

    [Tooltip("Color to determin if it can be played")]
    public GameEnums.Colors color {  get; private set; }

    [Tooltip("Whether the card is special or not")]
    public bool isSpecial { get; private set; }

    [Tooltip("Special Type")]
    public GameEnums.Special specialType { get; private set; }
    
}
