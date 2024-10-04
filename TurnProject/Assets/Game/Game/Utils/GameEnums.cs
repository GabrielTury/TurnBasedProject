using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEnums 
{
    public enum Special
    {
        None = 0,
        ChangeBoard = 1,
        Plus4 = 4

    }

    public enum TileSpecial
    {
        None = 0,
        Plus2 = 1,
        Start = 2,
        DrawSpecialCard = 3
    }

    public enum Colors
    {
        None = 0,
        Blue = 1,
        Green = 2,
        Red = 3,
        Yellow = 4
    }
}
