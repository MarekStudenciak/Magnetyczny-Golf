using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public GameObject GameOverScreen;
    public GameObject RestartPrompt;
    public string nextLevel = "1";
    bool levelCleared = false;
    int restartReadiness = 0;

    void FixedUpdate()
    {
        if(Input.GetButton("Fire1") && levelCleared){
            SceneManager.LoadScene(nextLevel);
        }

        if(restartReadiness>0){
            restartReadiness -= 1;
        }

        if(restartReadiness == 1){
            RestartPrompt.SetActive(false);
        }

        if(Input.GetButton("Fire4")){
        //if(Input.GetKey(KeyCode.Space)){
            if(levelCleared || (restartReadiness>0 && restartReadiness<450)){
                restartGame();
            } else {
                RestartPrompt.SetActive(true);
                restartReadiness = 500;
            }
        }

    }

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

    public void mainMenu()
    {
        SceneManager.LoadScene("main_menu");
    }

    public void sample()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void gameOver()
    {
        GameOverScreen.SetActive(true);
        levelCleared = true;
    }
}
