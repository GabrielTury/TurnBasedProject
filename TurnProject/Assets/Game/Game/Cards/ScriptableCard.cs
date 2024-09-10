using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Card", menuName = "Game/Card")]

public class ScriptableCard : ScriptableObject
{
    [SerializeField, Tooltip("Number that will appear visually and determine movement amount")]
    private int number;

    public int GetCardNumber() => number;

    [SerializeField, Tooltip("Color to determin if it can be played")]
    private GameEnums.Colors color;

    public GameEnums.Colors GetCardColor() => color;

    [SerializeField, Tooltip("Special Type")]
    private GameEnums.Special specialType ;

    public GameEnums.Special GetSpecialType() => specialType;

    [SerializeField, Tooltip("Image that will show in UI")]
    private Sprite sprite;

    public Sprite GetSprite() => sprite;
    
}
