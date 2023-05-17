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

    public void sample()
    {
        SceneManager.LoadScene("SampleScene");
    }


    public void gameOver()
    {
        GameOverScreen.SetActive(true);
    }
}
