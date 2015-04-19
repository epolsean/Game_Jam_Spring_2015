using UnityEngine;
using System.Collections;

public class NextRoomCollision : MonoBehaviour {

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "ThiefDude")
        {
            GameAndUIController.HitTrigger = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "ThiefDude")
        {
            GameAndUIController.HitTrigger = true;
        }
    }
}
