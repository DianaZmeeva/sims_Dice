using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartLevelScript : MonoBehaviour {

    public Button startButton, exitButton;
    public Dropdown choosedice;
    Dropdown dice;
    public Text warning;

    void Start () {
        Button start = startButton.GetComponent<Button>();
        start.onClick.AddListener(StartLevel);

        dice = choosedice.GetComponent<Dropdown>();

        Button exit = exitButton.GetComponent<Button>();
        exit.onClick.AddListener(Exit);
    }
	
	void StartLevel()
    {
        if (dice.value > 0)
        {
            warning.text = "";

            if (dice.value == 1)
            {
                GameControl.n = dice.value;
            }

            else if (dice.value == 2)
            {
                GameControl.n = dice.value;
            }
            else if (dice.value == 3)
            {
                GameControl.n = dice.value;
            }
            
            SceneManager.LoadScene("SampleScene");
        }
        else
        {
            warning.text= "Choose dice!";
        }
    }

    void Exit()
    {
        Application.Quit();
    }
}


