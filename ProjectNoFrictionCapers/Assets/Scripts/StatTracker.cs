using UnityEngine;
using System.Collections;

public class StatTracker : MonoBehaviour {

    public static int TotalCoins = 0;
    public static int Level1_Complete = 0;
    public static int Level2_Complete = 0;
    public static int Level3_Complete = 0;

    // Use this for initialization
    void Start()
    {
        SetStats();
    }

    public void ClearStats()
    {
        PlayerPrefs.SetInt("TotalCoins", 0);
        PlayerPrefs.SetInt("Level1_Complete", 0);
        PlayerPrefs.SetInt("Level2_Complete", 0);
        PlayerPrefs.SetInt("Level3_Complete", 0);
    }

    public static void updateStats()
    {
        //Check for coins earned
        if (PlayerPrefs.HasKey("TotalCoins"))
        {
            TotalCoins = PlayerPrefs.GetInt("TotalCoins");
        }
        else
        {
            PlayerPrefs.SetInt("TotalCoins", TotalCoins);
        }

        //Check for Level_ 1 complete
        if (PlayerPrefs.HasKey("Level1_Complete"))
        {
            Level1_Complete = PlayerPrefs.GetInt("Level1_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level1_Complete", Level1_Complete);
        }

        //Check for Level_ 2 complete
        if (PlayerPrefs.HasKey("Level2_Complete"))
        {
            Level2_Complete = PlayerPrefs.GetInt("Level2_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level2_Complete", Level2_Complete);
        }

        //Check for Level_ 3 complete
        if (PlayerPrefs.HasKey("Level3_Complete"))
        {
            Level3_Complete = PlayerPrefs.GetInt("Level3_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level3_Complete", Level3_Complete);
        }
    }


    void SetStats()
    {
        //Check for Level_ 1 complete
        if (PlayerPrefs.HasKey("Level1_Complete"))
        {
            Level1_Complete = PlayerPrefs.GetInt("Level1_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level1_Complete", Level1_Complete);
        }

        //Check for Level_ 2 complete
        if (PlayerPrefs.HasKey("Level2_Complete"))
        {
            Level2_Complete = PlayerPrefs.GetInt("Level2_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level2_Complete", Level2_Complete);
        }

        //Check for Level_ 3 complete
        if (PlayerPrefs.HasKey("Level3_Complete"))
        {
            Level3_Complete = PlayerPrefs.GetInt("Level3_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level3_Complete", Level3_Complete);
        }
    }
}
