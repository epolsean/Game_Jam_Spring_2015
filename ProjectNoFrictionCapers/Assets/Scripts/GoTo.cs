using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GoTo : MonoBehaviour {

    public GameObject MainMenuPanel;
    public GameObject HowToPlayPanel;
    public GameObject CreditsPanel;

    void Start()
    {
        if(MainMenuPanel != null)
        {
            
        }
    }

    public void HowToPlay()
    {
        
    }


    public void StartScreen()
    {
        
    }

    public void MainMenu()
    {
        Application.LoadLevel("StartScreen");
    }

    public void Credits()
    {
        
    }

    public void Quit()
    {
        Application.Quit();
    }
}
