using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    public GameEnums.Colors color {  get; private set; }

    public GameEnums.TileSpecial special { get; private set; }

    [SerializeField]
    private TileScriptableObject startInfo;

    private bool canChange = true;

    private void Start()
    {
        if (startInfo != null)
        {
            SetTileInfo(startInfo);
            canChange = false;
        }
    }

    public void ChangeTileColor(int newColorId)
    {
        color = (GameEnums.Colors)newColorId;
    }

    public void SetTileInfo(TileScriptableObject info)
    {
        if (!canChange)
            return;

        color = info.GetColor();
        special = info.GetSpecial();
        gameObject.GetComponent<MeshRenderer>().sharedMaterial = info.GetVisual();
    }
}
