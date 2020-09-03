using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{

    public void NarrativeButton()
    {
        SceneManager.LoadScene("Narrative_Scene");
    }

    public void TutorialScreen1()
    {
        SceneManager.LoadScene("TScreen_Original");
    }

    public void TutorialScreen2()
    {
        SceneManager.LoadScene("TScreen_1");
    }

    public void TutorialScreen3()
    {
        SceneManager.LoadScene("TScreen_2");
    }

    public void TutorialScreen4()
    {
        SceneManager.LoadScene("TScreen_3");
    }

    public void TutorialScreen5()
    {
        SceneManager.LoadScene("TScreen_4");
    }

    public void TutorialLevel()
    {
        SceneManager.LoadScene("New_Tutorial");
    }

    public void PlayButton()
    {
        SceneManager.LoadScene("Beta_Milestone");
    }

    public void CreditsButton()
    {
        SceneManager.LoadScene("Credits_Scene");
    }

    public void TitleScreen()
    {
        SceneManager.LoadScene("Title_Scene");
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
