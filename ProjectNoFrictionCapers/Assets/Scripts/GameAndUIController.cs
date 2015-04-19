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

    void Awake()
    {
        timeTaken = 0f;
        RoomNumberCheckpoint = 1;
        RoomComplete = false;
        if (Advertisement.isSupported)
        {
            Debug.Log("platform supported for ads");
            Advertisement.allowPrecache = true;
            Advertisement.Initialize("32757", false);
        }
        else
        {
            Debug.Log("Platform not supported");
        }
    }

    // Use this for initialization
    void Start()
    {
        UpdateRoomText();
        RoomNumberCheckpoint = 1;
        RoomComplete = false;
        timeTaken = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (!RoomComplete)
            timeTaken += Time.deltaTime;
        if (Input.GetKey(KeyCode.L) && !RoomComplete)
        {
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

            timeTakenText.text = "Time Taken : " + string.Format("{0:00}:{1:00}", (int)(timeTaken / 60), (int)(timeTaken % 60));
            levelComplete.SetActive(true);
            Invoke("StartAd", 3.0f);
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

    void StartAd()
    {
        if (Advertisement.isReady())
        {
            Advertisement.Show(null, new ShowOptions
            {
                pause = true,
                resultCallback = result =>
                {
                    AdFinished();
                }
            });
        }
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
            Application.LoadLevel("LevelSelect");
        }
        else
        {
            RoomComplete = false;
            RoomNumberCheckpoint++;
            UpdateRoomText();
            timeTaken = 0f;
            levelComplete.SetActive(false);
            continueGame.SetActive(false);
            retryLevel.SetActive(false);
        }
    }

    public void UnPause()
    {

    }

    public void Pause()
    {

    }
}
