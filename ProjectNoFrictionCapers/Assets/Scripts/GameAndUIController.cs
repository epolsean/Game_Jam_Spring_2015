using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class GameAndUIController : MonoBehaviour
{
    public Text HUDLevelText;
    public GameObject levelComplete;
    public Text WhatRoomAndLevel;
    public GameObject retryLevel;
    public GameObject continueGame;
    public Text timeTakenText;

    public static float timeTaken;
    public static int TotalRooms;
    public static int RoomNumberCheckpoint;
    bool RoomComplete;

    public GameObject MainPausePanel;
    public GameObject areYouSure;

    float startTime;
    bool startedUp;

    public static bool HitTrigger = false;

    void Awake()
    {
        HitTrigger = false;
        timeTaken = 0f;
        RoomNumberCheckpoint = 1;
        RoomComplete = false;
        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.allowPrecache = true;
            Advertisement.Initialize("32757");
        }
    }

    // Use this for initialization
    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        HitTrigger = false;
        startTime = Time.time;
        UpdateRoomText();
        RoomNumberCheckpoint = 1;
        RoomComplete = false;
        timeTaken = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!RoomComplete)
        {
            if (startTime + .01 < Time.time && startedUp == false)
            {
                MainPausePanel.SetActive(false);
                startedUp = true;
            }
            if (Input.GetKeyUp(KeyCode.Escape))
            {
                if (MainPausePanel.activeInHierarchy == true)
                {
                    UnPause();
                }
                else
                {
                    Pause();
                }
            }
            timeTaken += Time.deltaTime;
        }
        if (HitTrigger && !RoomComplete)
        {
            HitTrigger = false;
            RoomComplete = true;
            if (RoomNumberCheckpoint == TotalRooms)
            {
                switch (Application.loadedLevelName)
                {
                    case "Level1":
                        {
                            WhatRoomAndLevel.text = "Level 1 Completed";
                            if (StatTracker.Level1_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level1_Complete", 1);
                            }
                            break;
                        }
                    case "Level2":
                        {
                            WhatRoomAndLevel.text = "Level 2 Completed";
                            if (StatTracker.Level2_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level2_Complete", 1);
                            }
                            break;
                        }
                    case "Level3":
                        {
                            WhatRoomAndLevel.text = "Level 3 Completed";
                            if (StatTracker.Level3_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level3_Complete", 1);
                            }
                            break;
                        }
                }
                StatTracker.updateStats();
            }
            else
            {
                switch (Application.loadedLevelName)
                {
                    case "Level2":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
                    case "Level3":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
                }
            }

            timeTakenText.text = "Time Taken  " + string.Format("{0:00}:{1:00}", (int)(timeTaken / 60) + "m", (int)(timeTaken % 60)+"s ");
            levelComplete.SetActive(true);
            if (Advertisement.isSupported)
            {
                StartCoroutine(ShowAdWhenReady());
            }
            else
            {
                AdFinished();
            }
        }
    }

    void UpdateRoomText()
    {
        switch (Application.loadedLevelName)
        {
            case "Level1":
                {
                    HUDLevelText.text = "Level 1 : Room " + RoomNumberCheckpoint;
                    break;
                }
            case "Level2":
                {
                    HUDLevelText.text = "Level 2 : Room " + RoomNumberCheckpoint;
                    break;
                }
            case "Level3":
                {
                    HUDLevelText.text = "Level 3 : Room " + RoomNumberCheckpoint;
                    break;
                }
        }
    }

    IEnumerator ShowAdWhenReady()
    {
        while (!Advertisement.isReady())
            yield return null;

        Advertisement.Show(null, new ShowOptions
        {
            pause = true,
            resultCallback = result =>
            {
                AdFinished();
            }
        });
    }


    void AdFinished()
    {
        continueGame.SetActive(true);
        retryLevel.SetActive(true);
    }

    public void RestartRoom()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void ContinueGame()
    {
        if (RoomNumberCheckpoint == TotalRooms)
        {
            if (Application.loadedLevelName == "Level2")
            {
                LoadingScreen.levelToLoad = "EndScene";
                Application.LoadLevel("LoadingScreen");
            }
            else
            {
                LoadingScreen.levelToLoad = "LevelSelect";
                Application.LoadLevel("LoadingScreen");
            }
        }
        else
        {
            HitTrigger = false;
            RoomComplete = false;
            RoomNumberCheckpoint++;
            UpdateRoomText();
            timeTaken = 0f;
            levelComplete.SetActive(false);
            continueGame.SetActive(false);
            retryLevel.SetActive(false);
        }
    }

    public void AreYouSure()
    {
        areYouSure.SetActive(true);
    }

    public void GoToLevelSelect()
    {
        Time.timeScale = 1;
        Application.LoadLevel("LevelSelect");
    }

    public void UnPause()
    {
        MainPausePanel.SetActive(false);
        areYouSure.SetActive(false);
        Time.timeScale = 1;
    }

    public void Pause()
    {
        MainPausePanel.SetActive(true);
        areYouSure.SetActive(false);
        Time.timeScale = 0;
    }
}
