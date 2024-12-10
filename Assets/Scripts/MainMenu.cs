using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audio; // Define audioPlayer inside the class

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("MiniGame");
    }

    public void PlayGame1()
    {
        SceneManager.LoadSceneAsync("Minigame 1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void exitButton()
    {
        if (audio != null)
        {
            audio.Play();
        }
    }
    public void OpenGithub()
    {
        Application.OpenURL("https://github.com/ElMario90/FinalVersion");
    }
        public void OpenGithub1()
    {
        Application.OpenURL("https://github.com/matiasmelinte67/MainVersion");
    }

}
