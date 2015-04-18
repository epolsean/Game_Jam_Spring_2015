using UnityEngine;
using System.Collections;

public class RandomGenerateScript : MonoBehaviour {

    public GameObject spawn;

    GameObject[][] slots = new GameObject[10][];
    public GameObject[] slot0;
    public GameObject[] slot1;
    public GameObject[] slot2;
    public GameObject[] slot3;
    public GameObject[] slot4;
    public GameObject[] slot5;
    public GameObject[] slot6;
    public GameObject[] slot7;
    public GameObject[] slot8;
    public GameObject[] slot9;

	// Use this for initialization
	void Start () {
        slots[0] = slot0;
        slots[1] = slot1;
        slots[2] = slot2;
        slots[3] = slot3;
        slots[4] = slot4;
        slots[5] = slot5;
        slots[6] = slot6;
        slots[7] = slot7;
        slots[8] = slot8;
        slots[9] = slot9;

        int rand1 = Random.Range(0,20);

        for (int i = 0; i < rand1; i++)
        {
            int rand2 = Random.Range(0, 9);
            int rand3 = Random.Range(0, 9);
            for (int j = 0; j < 10; j++)
            {
                for (int k = 0; k < 10; k++)
                {
                    if (j == rand2 && k == rand3)
                    {
                        Quaternion randRot = new Quaternion(Random.Range(0f,1f),0,Random.Range(0f,1f),1);
                        Instantiate(spawn, slots[j][k].transform.position, randRot);
                    }
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
