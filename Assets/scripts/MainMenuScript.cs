using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public GameObject InstructionScreen;
    bool instructionOnScreen = false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && !instructionOnScreen){
            SceneManager.LoadScene("1");
        }
        if(Input.GetButton("Fire3") && instructionOnScreen){
            InstructionScreen.SetActive(false);
            instructionOnScreen = false;
        }
        if(Input.GetButton("Fire4") && !instructionOnScreen){
            InstructionScreen.SetActive(true);
            instructionOnScreen = true;
        }
    }
}
