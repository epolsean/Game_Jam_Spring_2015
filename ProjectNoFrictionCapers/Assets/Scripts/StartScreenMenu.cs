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
    public GameObject IntroButton;

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
        if(GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip != Resources.Load<AudioClip>("Music/MenuMusic"))
        {
            GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/MenuMusic");
            GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        }
        if (PlayerPrefs.HasKey("FirstPlay"))
        {
            IntroButton.SetActive(true);
        }
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
        if (PlayerPrefs.HasKey("FirstPlay"))
        {
            Application.LoadLevel("LevelSelect");
        }
        else
        {
            PlayerPrefs.SetInt("FirstPlay", 1);
            GoToIntro();
        }
    }

    public void GoToIntro()
    {
        Application.LoadLevel("Intro");
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
