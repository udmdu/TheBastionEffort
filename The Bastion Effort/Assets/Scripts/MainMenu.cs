using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator animator;

    public void PlayGame()
    {
        animator.SetTrigger("FadeOut");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OnFadeComplete()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LogoFadeComplete()
    {
        animator.SetTrigger("NextScene");
    }

    public void LogoFadeComplete2()
    {
        animator.SetTrigger("NextScene2");
    }
}
