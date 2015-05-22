using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelector : MonoBehaviour 
{
    public static bool UpdateMap = false;
    public GameObject map1;
    public GameObject map2;
    public GameObject map3;

    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public GameObject level4;
    public GameObject level5;
    public GameObject level6;

    public GameObject level7;
    public GameObject level8;
    public GameObject level9;

    public GameObject City1Panel;
    public GameObject City2Panel;
    public GameObject City3Panel;

    public GameObject City1Button;
    public GameObject City2Button;
    public GameObject City3Button;

    public Sprite draw1Finish;
    public Sprite draw2Finish;

    public Sprite completed;
    public Sprite unlocked;
    public Sprite locked;

    public static int CurrentCity = 1;

    // Use this for initialization
    void Start()
    {
        //UpdateMap = true;
        Screen.sleepTimeout = SleepTimeout.SystemSetting;
        if(GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip != Resources.Load<AudioClip>("Music/MenuMusic"))
        {
            GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/MenuMusic");
            GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        }
        StatTracker.updateStats();
        if (StatTracker.Level1_Complete == 1)
        {
            level1.GetComponent<Image>().sprite = completed;
            if (StatTracker.Level2_Complete != 1 && UpdateMap)
            {
                map1.GetComponent<Animator>().Play("MapDraw1-2");
                UpdateMap = false;
            }
            else if (StatTracker.Level2_Complete != 1 && !UpdateMap)
            {
                map1.GetComponent<Animator>().enabled = false;
                map1.GetComponent<Image>().sprite = draw1Finish;
            }
            level2.GetComponent<Image>().sprite = unlocked;
            level2.GetComponent<Button>().interactable = true;
        }
        if (StatTracker.Level2_Complete == 1)
        {
            level2.GetComponent<Image>().sprite = completed;
            if (StatTracker.Level3_Complete != 1 && UpdateMap)
            {
                map1.GetComponent<Animator>().Play("MapDraw2-3");
                UpdateMap = false;
            }
            else if (StatTracker.Level3_Complete != 1 && !UpdateMap)
            {
                map1.GetComponent<Animator>().enabled = false;
                map1.GetComponent<Image>().sprite = draw2Finish;
            }
            level3.GetComponent<Image>().sprite = unlocked;
            level3.GetComponent<Button>().interactable = true;
        }
        if (StatTracker.Level3_Complete == 1)
        {
            City2Button.GetComponent<Button>().interactable = true;
            City2Button.GetComponent<Image>().sprite = unlocked;
            City2Button.GetComponentInChildren<Text>().text = "City 2";
            level3.GetComponent<Image>().sprite = completed;
            level4.GetComponent<Image>().sprite = unlocked;
            level4.GetComponent<Button>().interactable = true;
            map1.GetComponent<Image>().sprite = draw2Finish;
            GoToCity2();
        }
        if (StatTracker.Level4_Complete == 1)
        {
            level4.GetComponent<Image>().sprite = completed;
            if (StatTracker.Level5_Complete != 1 && UpdateMap)
            {
                GoToCity2();
                map2.GetComponent<Animator>().Play("MapDraw1-2");
                UpdateMap = false;
            }
            else if (StatTracker.Level5_Complete != 1 && !UpdateMap)
            {
                map2.GetComponent<Animator>().enabled = false;
                map2.GetComponent<Image>().sprite = draw1Finish;
            }
            level5.GetComponent<Image>().sprite = unlocked;
            level5.GetComponent<Button>().interactable = true;
        }
        if (StatTracker.Level5_Complete == 1)
        {
            level5.GetComponent<Image>().sprite = completed;
            if (StatTracker.Level6_Complete != 1 && UpdateMap)
            {
                GoToCity2();
                map2.GetComponent<Animator>().Play("MapDraw2-3");
                UpdateMap = false;
            }
            else if (StatTracker.Level6_Complete != 1 && !UpdateMap)
            {
                map2.GetComponent<Animator>().enabled = false;
                map2.GetComponent<Image>().sprite = draw2Finish;
            }
            level6.GetComponent<Image>().sprite = unlocked;
            level6.GetComponent<Button>().interactable = true;
        }
        if (StatTracker.Level6_Complete == 1)
        {
            City3Button.GetComponent<Button>().interactable = true;
            City3Button.GetComponent<Image>().sprite = unlocked;
            City3Button.GetComponentInChildren<Text>().text = "City 3";
            level6.GetComponent<Image>().sprite = completed;
            level7.GetComponent<Image>().sprite = unlocked;
            level7.GetComponent<Button>().interactable = true;
            map2.GetComponent<Image>().sprite = draw2Finish;
            GoToCity3();
        }
        if (StatTracker.Level7_Complete == 1)
        {
            level7.GetComponent<Image>().sprite = completed;
            if (StatTracker.Level8_Complete != 1 && UpdateMap)
            {
                GoToCity3();
                map3.GetComponent<Animator>().Play("MapDraw1-2");
                UpdateMap = false;
            }
            else if (StatTracker.Level8_Complete != 1 && !UpdateMap)
            {
                map3.GetComponent<Animator>().enabled = false;
                map3.GetComponent<Image>().sprite = draw1Finish;
            }
            level8.GetComponent<Image>().sprite = unlocked;
            level8.GetComponent<Button>().interactable = true;
        }
        if (StatTracker.Level8_Complete == 1)
        {
            level8.GetComponent<Image>().sprite = completed;
            if (StatTracker.Level9_Complete != 1 && UpdateMap)
            {
                GoToCity3();
                map3.GetComponent<Animator>().Play("MapDraw2-3");
                UpdateMap = false;
            }
            else if (StatTracker.Level9_Complete != 1 && !UpdateMap)
            {
                map3.GetComponent<Animator>().enabled = false;
                map3.GetComponent<Image>().sprite = draw2Finish;
            }
            level9.GetComponent<Image>().sprite = unlocked;
            level9.GetComponent<Button>().interactable = true;
        }
        if (StatTracker.Level9_Complete == 1)
        {
            level9.GetComponent<Image>().sprite = completed;
            map3.GetComponent<Image>().sprite = draw2Finish;
            GoToCity1();
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void GoToCity1()
    {
        City1Panel.SetActive(true);
        City2Panel.SetActive(false);
        City3Panel.SetActive(false);
    }

    public void GoToCity2()
    {
        City1Panel.SetActive(false);
        City2Panel.SetActive(true);
        City3Panel.SetActive(false);
    }

    public void GoToCity3()
    {
        City1Panel.SetActive(false);
        City2Panel.SetActive(false);
        City3Panel.SetActive(true);
    }

    public void Level1()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level1Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 1;
        LoadingScreen.levelToLoad = "Level1";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level2()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level1Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 1;
        LoadingScreen.levelToLoad = "Level2";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level3()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level1Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 1;
        LoadingScreen.levelToLoad = "Level3";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level4()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level2Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 2;
        LoadingScreen.levelToLoad = "Level4";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level5()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level2Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 2;
        LoadingScreen.levelToLoad = "Level5";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level6()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level2Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 2;
        LoadingScreen.levelToLoad = "Level6";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level7()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level3Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 2;
        LoadingScreen.levelToLoad = "Level7";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level8()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level3Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 2;
        LoadingScreen.levelToLoad = "Level8";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level9()
    {
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().clip = Resources.Load<AudioClip>("Music/Level3Music");
        GameObject.Find("MenuMusic").GetComponent<AudioSource>().Play();
        GameAndUIController.TotalRooms = 2;
        LoadingScreen.levelToLoad = "Level9";
        Application.LoadLevel("LoadingScreen");
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel("StartScreen");
    }
}
