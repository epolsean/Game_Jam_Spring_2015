using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Advertisements;
using System.Collections;

public class GameAndUIController : MonoBehaviour
{
    public GameObject levelComplete;

    void Awake()
    {
        //if (Advertisement.isSupported)
        //{
        //    Debug.Log("platform supported for ads");
        //    Advertisement.allowPrecache = true;
        //    Advertisement.Initialize("32757", false);
        //}
        //else
        //{
        //    Debug.Log("Platform not supported");
        //}
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            levelComplete.SetActive(true);
            if (Advertisement.isReady())
            {
                Advertisement.Show();
            }
        }
    }

    public void UnPause()
    {

    }

    public void Pause()
    {

    }
}
