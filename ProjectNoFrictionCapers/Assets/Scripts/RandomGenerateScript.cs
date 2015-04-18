using UnityEngine;
using System.Collections;

public class RandomGenerateScript : MonoBehaviour {

    public GameObject[] spawn;
    public GameObject parent;
    public int Spawns;

    GameObject[][] slots = new GameObject[10][];
    int[][] slotsTaken = new int[10][];
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
        slotsTaken[0] = new int[10];
        slotsTaken[1] = new int[10];
        slotsTaken[2] = new int[10];
        slotsTaken[3] = new int[10];
        slotsTaken[4] = new int[10];
        slotsTaken[5] = new int[10];
        slotsTaken[6] = new int[10];
        slotsTaken[7] = new int[10];
        slotsTaken[8] = new int[10];
        slotsTaken[9] = new int[10];

        int rand1 = Random.Range(5,40);
        Spawns = rand1;
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
                        if (slotsTaken[j][k] != 1)
                        {
                            int rand4 = Random.Range(0, spawn.Length);
                            Quaternion randRot = new Quaternion(0, Random.Range(0f, 1f), 0, 1);
                            GameObject newObj = (GameObject)Instantiate(spawn[rand4], slots[j][k].transform.position, randRot);
                            newObj.transform.parent = parent.transform;
                            newObj.transform.position = new Vector3(newObj.transform.position.x, parent.transform.position.y, newObj.transform.position.z);
                            slotsTaken[j][k] = 1;
                        }
                        else
                        {
                            rand3 = Random.Range(k, 9);
                        }
                    }
                }
            }
        }

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
