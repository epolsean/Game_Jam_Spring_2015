using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelSelector : MonoBehaviour 
{
    public static bool UpdateMap = false;
    public GameObject map;
    public GameObject level1;
    public GameObject level2;
    public GameObject level3;

    // Use this for initialization
    void Start()
    {
        StatTracker.updateStats();
        if (StatTracker.Level1_Complete == 1)
        {
            if (StatTracker.Level2_Complete != 1 && UpdateMap)
            {
                //map.GetComponent<Animator>().Play("MapDraw1-2");
                UpdateMap = false;
            }
            else if (StatTracker.Level2_Complete != 1 && !UpdateMap)
            {
                //map.GetComponent<Animator>().enabled = false;
                //map.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Map1-2(Finish)");
            }
            level2.GetComponent<Button>().interactable = true;
        }
        if (StatTracker.Level2_Complete == 1)
        {
            if (StatTracker.Level3_Complete != 1 && UpdateMap)
            {
                //map.GetComponent<Animator>().Play("MapDraw2-3");
                UpdateMap = false;
            }
            else if (StatTracker.Level3_Complete != 1 && !UpdateMap)
            {
                //map.GetComponent<Animator>().enabled = false;
                //map.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Map2-3(Finish)");
            }
            level3.GetComponent<Button>().interactable = true;
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public void Level1()
    {
        Application.LoadLevel("Level1");
    }

    public void Level2()
    {
        Application.LoadLevel("Level2");
    }

    public void Level3()
    {
        Application.LoadLevel("Level3");
    }

    public void BackToMainMenu()
    {
        Application.LoadLevel("StartScreen");
    }
}
