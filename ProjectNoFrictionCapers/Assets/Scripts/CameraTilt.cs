using UnityEngine;
using System.Collections;

public class CameraTilt : MonoBehaviour {

    public GameObject TiltPlane;
    public GameObject Cam1;
    public GameObject Cam3;

    Vector3 midpoint;

    void FixedUpdate()
    {
        Vector3 distanceBetween = Cam1.transform.position - Cam3.transform.position;
        midpoint = Cam1.transform.position - distanceBetween / 2;
        transform.position = midpoint;
        Quaternion rotation = new Quaternion((Cam1.transform.rotation.x + Cam3.transform.rotation.x) / 2, (Cam1.transform.rotation.y + Cam3.transform.rotation.y) / 2, (Cam1.transform.rotation.z + Cam3.transform.rotation.z) / 2, (Cam1.transform.rotation.w + Cam3.transform.rotation.w) / 2);
        transform.rotation = rotation;
    }
}
