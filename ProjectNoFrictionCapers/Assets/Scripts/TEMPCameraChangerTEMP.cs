using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TEMPCameraChangerTEMP : MonoBehaviour {

    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;

    public GameObject Panel1;
    public GameObject Panel2;
    public GameObject Panel3;

    bool view1;
    bool view2;
    bool view3;
    bool view4;

    Vector2 rectPanel1Min;
    Vector2 rectPanel1Max;
    Vector2 rectPanel2Min;
    Vector2 rectPanel2Max;
    Vector2 rectPanel3Min;
    Vector2 rectPanel3Max;

    Rect rectCam1;
    Rect rectCam2;
    Rect rectCam3;
    Rect fullScreen = new Rect(0, 0, 1, 1);


	// Use this for initialization
	void Start () {
        view1 = true;
        rectCam1 = Cam1.GetComponent<Camera>().rect;
        rectCam2 = Cam2.GetComponent<Camera>().rect;
        rectCam3 = Cam3.GetComponent<Camera>().rect;
        rectPanel1Min = Panel1.GetComponent<RectTransform>().anchorMin;
        rectPanel1Max = Panel1.GetComponent<RectTransform>().anchorMax;
        rectPanel2Min = Panel2.GetComponent<RectTransform>().anchorMin;
        rectPanel2Max = Panel2.GetComponent<RectTransform>().anchorMax;
        rectPanel3Min = Panel3.GetComponent<RectTransform>().anchorMin;
        rectPanel3Max = Panel3.GetComponent<RectTransform>().anchorMax;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void Back()
    {
        if (view1 == true)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(true);
            Panel3.GetComponent<RectTransform>().anchorMin = rectPanel2Min;
            Panel3.GetComponent<RectTransform>().anchorMax = rectPanel2Max;
            Cam3.GetComponent<Camera>().rect = fullScreen;
            view1 = false;
            view4 = true;
            return;
        }
        else if (view2 == true)
        {
            Cam1.SetActive(true);
            Cam2.SetActive(true);
            Cam3.SetActive(true);
            Panel1.SetActive(true);
            Panel2.SetActive(true);
            Panel3.SetActive(true);
            Panel1.GetComponent<RectTransform>().anchorMin = rectPanel1Min;
            Panel1.GetComponent<RectTransform>().anchorMax = rectPanel1Max;
            Panel2.GetComponent<RectTransform>().anchorMin = rectPanel2Min;
            Panel2.GetComponent<RectTransform>().anchorMax = rectPanel2Max;
            Panel3.GetComponent<RectTransform>().anchorMin = rectPanel3Min;
            Panel3.GetComponent<RectTransform>().anchorMax = rectPanel3Max;
            Cam1.GetComponent<Camera>().rect = rectCam1;
            Cam2.GetComponent<Camera>().rect = rectCam2;
            Cam3.GetComponent<Camera>().rect = rectCam3;
            view2 = false;
            view1 = true;
            return;
        }
        else if (view3 == true)
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel1.GetComponent<RectTransform>().anchorMin = rectPanel2Min;
            Panel1.GetComponent<RectTransform>().anchorMax = rectPanel2Max;
            Cam1.GetComponent<Camera>().rect = fullScreen;
            view3 = false;
            view2 = true;
            return;
        }
        else if (view4 == true)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            Cam3.SetActive(false);
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Panel3.SetActive(false);
            Panel2.GetComponent<RectTransform>().anchorMin = rectPanel2Min;
            Panel2.GetComponent<RectTransform>().anchorMax = rectPanel2Max;
            Cam2.GetComponent<Camera>().rect = fullScreen;
            view4 = false;
            view3 = true;
            return;
        }
    }

    public void Forward()
    {
        if (view1 == true)
        {
            Cam1.SetActive(true);
            Cam2.SetActive(false);
            Cam3.SetActive(false);
            Panel1.SetActive(true);
            Panel2.SetActive(false);
            Panel3.SetActive(false);
            Panel1.GetComponent<RectTransform>().anchorMin = rectPanel2Min;
            Panel1.GetComponent<RectTransform>().anchorMax = rectPanel2Max;
            Cam1.GetComponent<Camera>().rect = fullScreen;
            view1 = false;
            view2 = true;
            return;
        }
        else if (view2 == true)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(true);
            Cam3.SetActive(false);
            Panel1.SetActive(false);
            Panel2.SetActive(true);
            Panel3.SetActive(false);
            Panel2.GetComponent<RectTransform>().anchorMin = rectPanel2Min;
            Panel2.GetComponent<RectTransform>().anchorMax = rectPanel2Max;
            Cam2.GetComponent<Camera>().rect = fullScreen;
            view2 = false;
            view3 = true;
            return;
        }
        else if (view3 == true)
        {
            Cam1.SetActive(false);
            Cam2.SetActive(false);
            Cam3.SetActive(true);
            Panel1.SetActive(false);
            Panel2.SetActive(false);
            Panel3.SetActive(true);
            Panel3.GetComponent<RectTransform>().anchorMin = rectPanel2Min;
            Panel3.GetComponent<RectTransform>().anchorMax = rectPanel2Max;
            Cam3.GetComponent<Camera>().rect = fullScreen;
            view3 = false;
            view4 = true;
            return;
        }
        else if (view4 == true)
        {
            Cam1.SetActive(true);
            Cam2.SetActive(true);
            Cam3.SetActive(true);
            Panel1.SetActive(true);
            Panel2.SetActive(true);
            Panel3.SetActive(true);
            Panel1.GetComponent<RectTransform>().anchorMin = rectPanel1Min;
            Panel1.GetComponent<RectTransform>().anchorMax = rectPanel1Max;
            Panel2.GetComponent<RectTransform>().anchorMin = rectPanel2Min;
            Panel2.GetComponent<RectTransform>().anchorMax = rectPanel2Max;
            Panel3.GetComponent<RectTransform>().anchorMin = rectPanel3Min;
            Panel3.GetComponent<RectTransform>().anchorMax = rectPanel3Max;
            Cam1.GetComponent<Camera>().rect = rectCam1;
            Cam2.GetComponent<Camera>().rect = rectCam2;
            Cam3.GetComponent<Camera>().rect = rectCam3;
            view4 = false;
            view1 = true;
            return;
        }
    }
}
