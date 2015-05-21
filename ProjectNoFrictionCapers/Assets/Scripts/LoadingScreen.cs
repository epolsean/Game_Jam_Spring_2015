using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class LoadingScreen : MonoBehaviour
{
    public static string levelToLoad;
    public GameObject loadingText;
    public GameObject spinWheel;
    public GameObject spinWheel2;
    public GameObject spinWheel3;

    float loadTime = 2.0f;
    bool switchText = true;
    float delay = 0.5f;


    // Use this for initialization
    void Start()
    {
        loadTime = 2.0f;
        StartCoroutine(DisplayLoadingScreen(levelToLoad));
    }

    // Update is called once per frame
    void Update()
    {
        spinWheel.transform.Rotate(0, 0, 1);
        spinWheel2.transform.Rotate(0, 0, -0.75f);
        spinWheel3.transform.Rotate(0, 0, 1.1f);
        if (delay <= 0)
        {
            delay = 0.5f;
            switchText = true;
        }
        else
        {
            delay -= Time.deltaTime;
        }
        if (switchText)
        {
            switch (loadingText.GetComponent<Text>().text)
            {
                case "Loading...":
                    {
                        loadingText.GetComponent<Text>().text = "Loading.";
                        break;
                    }
                case "Loading..":
                    {
                        loadingText.GetComponent<Text>().text = "Loading...";
                        break;
                    }
                case "Loading.":
                    {
                        loadingText.GetComponent<Text>().text = "Loading..";
                        break;
                    }
            }
            switchText = false;
        }
    }

    IEnumerator DisplayLoadingScreen(string level)
    {
        while (loadTime > 0)
        {
            loadTime -= Time.deltaTime;
            yield return null;
        }

        AsyncOperation async = Application.LoadLevelAsync(level);
        while (!async.isDone)
        {
            yield return null;
        }
    }
}
