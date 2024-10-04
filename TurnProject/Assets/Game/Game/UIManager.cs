using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    

    [SerializeField]
    GameObject mainMenu, pawnSelection;
    public void GoToSelection()
    {
        pawnSelection.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
