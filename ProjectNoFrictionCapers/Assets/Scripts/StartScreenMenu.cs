using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
using System.Collections;

public class StartScreenMenu : MonoBehaviour 
{
    public Text titletext;
    public GameObject MainMenuPanel;
    public GameObject HowToPlayPanel;
    public GameObject CreditsPanel;

    void Awake() 
    {
        if (Advertisement.isSupported) 
        {
            Debug.Log("platform supported for ads");
            Advertisement.allowPrecache = true;
            Advertisement.Initialize ("32757",false);
        } 
        else 
        {
            Debug.Log("Platform not supported");
        }
    }

    void Start()
    {
        GoToMainPanel();
    }

    public void GoToHowToPlay()
    {
        titletext.text = "How to play";
        if (MainMenuPanel != null)
        {
            MainMenuPanel.SetActive(false);
        }
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(true);
        }
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(false);
        }
    }


    public void GoToMainPanel()
    {
        titletext.text = "Frictionless Capers";
        if (MainMenuPanel != null)
        {
            MainMenuPanel.SetActive(true);
        }
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(false);
        }
    }

    public void GoToLevelSelect()
    {
        //if (Advertisement.isReady()) 
        //{
        //    Advertisement.Show(); 
        //} 
        Application.LoadLevel("LevelSelect");
    }

    public void GoToCredits()
    {
        titletext.text = "credits";
        if (MainMenuPanel != null)
        {
            MainMenuPanel.SetActive(false);
        }
        if (HowToPlayPanel != null)
        {
            HowToPlayPanel.SetActive(false);
        }
        if (CreditsPanel != null)
        {
            CreditsPanel.SetActive(true);
        }
    }

    public void Quit()
    {
        Application.Quit();
    }
}
