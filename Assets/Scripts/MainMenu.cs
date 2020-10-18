using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public string playGame;

    public void PlayGame()
    {
        Application.LoadLevel(playGame);
    }
}
