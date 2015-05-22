using UnityEngine;
using System.Collections;

public class StatTracker : MonoBehaviour 
{
    public static int TotalCoins = 0;
    public static int Level1_Complete = 0;
    public static int Level2_Complete = 0;
    public static int Level3_Complete = 0;
    public static int Level4_Complete = 0;
    public static int Level5_Complete = 0;
    public static int Level6_Complete = 0;
    public static int Level7_Complete = 0;
    public static int Level8_Complete = 0;
    public static int Level9_Complete = 0;

    // Use this for initialization
    void Start()
    {
        SetStats();
    }

    public void ClearStats()
    {
        PlayerPrefs.DeleteKey("FirstPlay");
        PlayerPrefs.SetInt("TotalCoins", 0);
        PlayerPrefs.SetInt("Level1_Complete", 0);
        PlayerPrefs.SetInt("Level2_Complete", 0);
        PlayerPrefs.SetInt("Level3_Complete", 0);
        PlayerPrefs.SetInt("Level4_Complete", 0);
        PlayerPrefs.SetInt("Level5_Complete", 0);
        PlayerPrefs.SetInt("Level6_Complete", 0);
        PlayerPrefs.SetInt("Level7_Complete", 0);
        PlayerPrefs.SetInt("Level8_Complete", 0);
        PlayerPrefs.SetInt("Level9_Complete", 0);
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

        //Check for Level_ 4 complete
        if (PlayerPrefs.HasKey("Level4_Complete"))
        {
            Level4_Complete = PlayerPrefs.GetInt("Level4_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level4_Complete", Level4_Complete);
        }

        //Check for Level_ 5 complete
        if (PlayerPrefs.HasKey("Level5_Complete"))
        {
            Level5_Complete = PlayerPrefs.GetInt("Level5_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level5_Complete", Level5_Complete);
        }

        //Check for Level_ 6 complete
        if (PlayerPrefs.HasKey("Level6_Complete"))
        {
            Level6_Complete = PlayerPrefs.GetInt("Level6_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level6_Complete", Level6_Complete);
        }

        //Check for Level_ 7 complete
        if (PlayerPrefs.HasKey("Level7_Complete"))
        {
            Level7_Complete = PlayerPrefs.GetInt("Level7_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level7_Complete", Level7_Complete);
        }

        //Check for Level_ 8 complete
        if (PlayerPrefs.HasKey("Level8_Complete"))
        {
            Level8_Complete = PlayerPrefs.GetInt("Level8_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level8_Complete", Level8_Complete);
        }

        //Check for Level_ 9 complete
        if (PlayerPrefs.HasKey("Level9_Complete"))
        {
            Level9_Complete = PlayerPrefs.GetInt("Level9_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level9_Complete", Level9_Complete);
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

        //Check for Level_ 4 complete
        if (PlayerPrefs.HasKey("Level4_Complete"))
        {
            Level4_Complete = PlayerPrefs.GetInt("Level4_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level4_Complete", Level4_Complete);
        }

        //Check for Level_ 5 complete
        if (PlayerPrefs.HasKey("Level5_Complete"))
        {
            Level5_Complete = PlayerPrefs.GetInt("Level5_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level5_Complete", Level5_Complete);
        }

        //Check for Level_ 6 complete
        if (PlayerPrefs.HasKey("Level6_Complete"))
        {
            Level6_Complete = PlayerPrefs.GetInt("Level6_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level6_Complete", Level6_Complete);
        }

        //Check for Level_ 7 complete
        if (PlayerPrefs.HasKey("Level7_Complete"))
        {
            Level7_Complete = PlayerPrefs.GetInt("Level7_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level7_Complete", Level7_Complete);
        }

        //Check for Level_ 8 complete
        if (PlayerPrefs.HasKey("Level8_Complete"))
        {
            Level8_Complete = PlayerPrefs.GetInt("Level8_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level8_Complete", Level8_Complete);
        }

        //Check for Level_ 9 complete
        if (PlayerPrefs.HasKey("Level9_Complete"))
        {
            Level9_Complete = PlayerPrefs.GetInt("Level9_Complete");
        }
        else
        {
            PlayerPrefs.SetInt("Level9_Complete", Level9_Complete);
        }
    }
}
