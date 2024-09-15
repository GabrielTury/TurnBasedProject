using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameEnums.Colors color {  get; private set; }

    public GameEnums.TileSpecial special { get; private set; }

    public void ChangeTileColor(int newColorId)
    {
        color = (GameEnums.Colors)newColorId;
    }
}
