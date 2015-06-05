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
    public static bool hitCop = false;

    public GameObject room1Items;
    public GameObject room2Items;
    public GameObject room3Items;

    void Awake()
    {
        if(room2Items)
        {
            foreach (Rigidbody rb in room2Items.GetComponentsInChildren<Rigidbody>())
            {
                if (!rb.isKinematic)
                {
                    rb.isKinematic = true;
                }
            }
        }
        if (room3Items)
        {
            foreach (Rigidbody rb in room3Items.GetComponentsInChildren<Rigidbody>())
            {
                if (!rb.isKinematic)
                {
                    rb.isKinematic = true;
                }
            }
        }
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        HitTrigger = false;
        startTime = Time.time;
        UpdateRoomText();
        RoomNumberCheckpoint = 1;
        RoomComplete = false;
        if (!hitCop)
        {
            timeTaken = 0f;
        }
        else
        {
            hitCop = false;
        }
        if (Advertisement.isSupported && !Advertisement.isInitialized)
        {
            Advertisement.allowPrecache = true;
            Advertisement.Initialize("32757");
        }
    }

    // Use this for initialization
    //void Start()
    //{
    //    Screen.sleepTimeout = SleepTimeout.NeverSleep;
    //    HitTrigger = false;
    //    startTime = Time.time;
    //    UpdateRoomText();
    //    RoomNumberCheckpoint = 1;
    //    RoomComplete = false;
    //    if (!hitCop)
    //    {
    //        timeTaken = 0f;
    //    }
    //    else
    //    {
    //        hitCop = false;
    //    }
    //}

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
                                LevelSelector.CurrentCity = 1;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level1_Complete", 1);
                                LevelSelector.CurrentCity = 1;
                            }
                            break;
                        }
                    case "Level2":
                        {
                            WhatRoomAndLevel.text = "Level 2 Completed";
                            if (StatTracker.Level2_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                                LevelSelector.CurrentCity = 1;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level2_Complete", 1);
                                LevelSelector.CurrentCity = 1;
                            }
                            break;
                        }
                    case "Level3":
                        {
                            WhatRoomAndLevel.text = "Level 3 Completed";
                            if (StatTracker.Level3_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                                LevelSelector.CurrentCity = 1;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level3_Complete", 1);
                                LevelSelector.CurrentCity = 2;
                            }
                            break;
                        }
                    case "Level4":
                        {
                            WhatRoomAndLevel.text = "Level 4 Completed";
                            if (StatTracker.Level4_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                                LevelSelector.CurrentCity = 2;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level4_Complete", 1);
                                LevelSelector.CurrentCity = 2;
                            }
                            break;
                        }
                    case "Level5":
                        {
                            WhatRoomAndLevel.text = "Level 5 Completed";
                            if (StatTracker.Level5_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                                LevelSelector.CurrentCity = 2;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level5_Complete", 1);
                                LevelSelector.CurrentCity = 2;
                            }
                            break;
                        }
                    case "Level6":
                        {
                            WhatRoomAndLevel.text = "Level 6 Completed";
                            if (StatTracker.Level6_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                                LevelSelector.CurrentCity = 2;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level6_Complete", 1);
                                LevelSelector.CurrentCity = 3;
                            }
                            break;
                        }
                    case "Level7":
                        {
                            WhatRoomAndLevel.text = "Level 7 Completed";
                            if (StatTracker.Level7_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                                LevelSelector.CurrentCity = 3;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level7_Complete", 1);
                                LevelSelector.CurrentCity = 3;
                            }
                            break;
                        }
                    case "Level8":
                        {
                            WhatRoomAndLevel.text = "Level 8 Completed";
                            if (StatTracker.Level8_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                                LevelSelector.CurrentCity = 3;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level8_Complete", 1);
                                LevelSelector.CurrentCity = 3;
                            }
                            break;
                        }
                    case "Level9":
                        {
                            WhatRoomAndLevel.text = "Level 9 Completed";
                            if (StatTracker.Level9_Complete == 1)
                            {
                                LevelSelector.UpdateMap = false;
                                LevelSelector.CurrentCity = 3;
                            }
                            else
                            {
                                LevelSelector.UpdateMap = true;
                                PlayerPrefs.SetInt("Level9_Complete", 1);
                                LevelSelector.CurrentCity = 3;
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
                    case "Level1":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
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
                    case "Level4":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
                    case "Level5":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
                    case "Level6":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
                    case "Level7":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
                    case "Level8":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
                    case "Level9":
                        {
                            WhatRoomAndLevel.text = "Room " + RoomNumberCheckpoint + " Completed";
                            break;
                        }
                }
            }

            timeTakenText.text = "Time Taken  " + string.Format("{0:00}:{1:00}", (int)(timeTaken / 60) + "m", (int)(timeTaken % 60)+"s ");
            levelComplete.SetActive(true);
            Time.timeScale = 0f;
            if (Advertisement.isSupported && RoomNumberCheckpoint == TotalRooms)
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
                    HUDLevelText.text = "Level 1 : Room " + 1;
                    break;
                }
            case "Level2":
                {
                    HUDLevelText.text = "Level 2 : Room " + 1;
                    break;
                }
            case "Level3":
                {
                    HUDLevelText.text = "Level 3 : Room " + 1;
                    break;
                }
            case "Level4":
                {
                    HUDLevelText.text = "Level 4 : Room " + 1;
                    break;
                }
            case "Level5":
                {
                    HUDLevelText.text = "Level 5 : Room " + RoomNumberCheckpoint;
                    break;
                }
            case "Level6":
                {
                    HUDLevelText.text = "Level 6 : Room " + RoomNumberCheckpoint;
                    break;
                }
            case "Level7":
                {
                    HUDLevelText.text = "Level 7 : Room " + RoomNumberCheckpoint;
                    break;
                }
            case "Level8":
                {
                    HUDLevelText.text = "Level 8 : Room " + RoomNumberCheckpoint;
                    break;
                }
            case "Level9":
                {
                    HUDLevelText.text = "Level 9 : Room " + RoomNumberCheckpoint;
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
        Time.timeScale = 1f;
        if (RoomNumberCheckpoint == TotalRooms)
        {
            if (Application.loadedLevelName == "Level9")
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
            if (RoomNumberCheckpoint == 2 && room2Items && room1Items)
            {
                foreach (Rigidbody rb in room2Items.GetComponentsInChildren<Rigidbody>())
                {
                    if (rb.isKinematic)
                    {
                        rb.isKinematic = false;
                    }
                }
                foreach (Rigidbody rb in room1Items.GetComponentsInChildren<Rigidbody>())
                {
                    if (!rb.isKinematic)
                    {
                        rb.isKinematic = true;
                    }
                }
            }
            else if (RoomNumberCheckpoint == 3 && room3Items && room2Items)
            {
                foreach (Rigidbody rb in room3Items.GetComponentsInChildren<Rigidbody>())
                {
                    if (rb.isKinematic)
                    {
                        rb.isKinematic = false;
                    }
                }
                foreach (Rigidbody rb in room2Items.GetComponentsInChildren<Rigidbody>())
                {
                    if (!rb.isKinematic)
                    {
                        rb.isKinematic = true;
                    }
                }
            }
            UpdateRoomText();
            //timeTaken = 0f;
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
