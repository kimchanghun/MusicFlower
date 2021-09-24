using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour
{
    public void GoMainButton()
    {
        SceneManager.LoadScene("03.Main");
    }

    public void BackButton()
    {
        SceneManager.LoadScene("01.Intro");
    }
}
