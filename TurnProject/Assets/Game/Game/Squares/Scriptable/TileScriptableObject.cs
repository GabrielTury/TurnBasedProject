using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( fileName = "TileInfo", menuName = "Game/Tile Info")]
public class TileScriptableObject : ScriptableObject
{
    [SerializeField]
    private GameObject visualObject;
    public GameObject GetVisual() => visualObject;

    [SerializeField]
    private GameEnums.Colors tileColor;
    public GameEnums.Colors GetColor() => tileColor;

    [SerializeField]
    private GameEnums.TileSpecial special;
    public GameEnums.TileSpecial GetSpecial() => special;
}
