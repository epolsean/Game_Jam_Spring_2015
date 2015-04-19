using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelector : MonoBehaviour 
{
    public static bool UpdateMap = true;
    public GameObject map;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    public Sprite draw1Finish;
    public Sprite draw2Finish;

    public Sprite completed;
    public Sprite unlocked;
    public Sprite locked;

    // Use this for initialization
    void Start()
    {
        StatTracker.updateStats();
        if (StatTracker.Level1_Complete == 1)
        {
            level1.GetComponent<Image>().sprite = completed;
            if (StatTracker.Level2_Complete != 1 && UpdateMap)
            {
                map.GetComponent<Animator>().Play("MapDraw1-2");
                UpdateMap = false;
            }
            else if (StatTracker.Level2_Complete != 1 && !UpdateMap)
            {
                map.GetComponent<Animator>().enabled = false;
                map.GetComponent<Image>().sprite = draw1Finish;
            }
            level2.GetComponent<Image>().sprite = unlocked;
            level2.GetComponent<Button>().interactable = true;
            level3.GetComponent<Image>().sprite = locked;
        }
        if (StatTracker.Level2_Complete == 1)
        {
            level1.GetComponent<Image>().sprite = completed;
            if (StatTracker.Level3_Complete != 1 && UpdateMap)
            {
                map.GetComponent<Animator>().Play("MapDraw2-3");
                UpdateMap = false;
            }
            else if (StatTracker.Level3_Complete != 1 && !UpdateMap)
            {
                map.GetComponent<Animator>().enabled = false;
                map.GetComponent<Image>().sprite = draw2Finish;
            }
            level3.GetComponent<Image>().sprite = unlocked;
            level3.GetComponent<Button>().interactable = true;
        }
        if (StatTracker.Level3_Complete == 1)
        {
            level3.GetComponent<Image>().sprite = completed;
            map.GetComponent<Image>().sprite = draw2Finish;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void Level1()
    {
        LoadingScreen.levelToLoad = "Level1";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level2()
    {
        LoadingScreen.levelToLoad = "Level2";
        Application.LoadLevel("LoadingScreen");
    }

    public void Level3()
    {
        LoadingScreen.levelToLoad = "Level3";
        Application.LoadLevel("LoadingScreen");
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel("StartScreen");
    }
}
