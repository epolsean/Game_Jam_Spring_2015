using UnityEngine;
using System.Collections;

public class EndSceneController : MonoBehaviour 
{

    public GameObject panel1;
    public GameObject panel2;
    float delay;

	// Use this for initialization
	void Start () 
    {
        delay = 6.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (delay > 0)
        {
            delay -= Time.deltaTime;
        }
        else
        {
            if(panel1.GetComponent<CanvasGroup>().alpha>0)
                panel1.GetComponent<CanvasGroup>().alpha -= Time.deltaTime;
            if (panel1.GetComponent<CanvasGroup>().alpha < 1)
                panel2.GetComponent<CanvasGroup>().alpha += Time.deltaTime;
        }

	
	}
}
