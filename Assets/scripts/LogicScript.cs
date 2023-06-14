using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject GameOverScreen;

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void lvl1()
    {
        SceneManager.LoadScene("level_1");
    }

    public void l1()
    {
        SceneManager.LoadScene("1");
    }

    public void l2()
    {
        SceneManager.LoadScene("2");
    }

    public void l3()
    {
        SceneManager.LoadScene("3");
    }

    public void l4()
    {
        SceneManager.LoadScene("4");
    }

    public void l5()
    {
        SceneManager.LoadScene("5");
    }

    public void sample()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void gameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
