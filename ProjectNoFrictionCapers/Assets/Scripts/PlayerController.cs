using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public GameObject shoeGripUI;
    public GameObject shoeHint;
    Vector3 lastLooking;
    float shoeGrip;
    // Use this for initialization
    void Start()
    {
        shoeGrip = 0f;
        lastLooking = transform.forward;
    }

    // Update is called once per frame
    void Update() 
    {
        if (Mathf.Abs(GetComponent<Rigidbody>().velocity.x) >= 0.1f || Mathf.Abs(GetComponent<Rigidbody>().velocity.z) >= 0.1f)
        {
            transform.forward = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
            lastLooking = transform.forward;
        }
        else
        {
            transform.forward = lastLooking;
        }

        if (shoeGripUI)
        {
            if (Input.GetMouseButton(0) && shoeGrip > 0)
            {
                ToggleFrictionOn();
            }
            else
            {
                ToggleFrictionOff();
            }

            if (shoeGrip > 0)
            {
                shoeGripUI.GetComponent<Slider>().value = shoeGrip;
            }
            else
            {
                shoeGripUI.SetActive(false);
            }
        }
	}

    public void ToggleFrictionOn()
    {
        GetComponent<Collider>().material.frictionCombine = PhysicMaterialCombine.Maximum;
        shoeGrip -= Time.deltaTime*10;
    }

    public void ToggleFrictionOff()
    {
        GetComponent<Collider>().material.frictionCombine = PhysicMaterialCombine.Minimum;
    }

    public void ShoeHintOn()
    {
        shoeHint.SetActive(true);
        Time.timeScale = 0f;
    }

    public void ShoeHintOff()
    {
        shoeHint.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "StickyShoes")
        {
            if(shoeHint)
            {
                ShoeHintOn();
            }
            shoeGrip = 100f;
            shoeGripUI.SetActive(true);
            Destroy(other.gameObject);
        }
    }
}
