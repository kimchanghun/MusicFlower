using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroScript : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("02.Lobby");
    }
}
