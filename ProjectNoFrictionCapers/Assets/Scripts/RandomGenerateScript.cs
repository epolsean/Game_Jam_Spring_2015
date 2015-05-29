using UnityEngine;
using System.Collections;

public class RandomGenerateScript : MonoBehaviour {

    public GameObject[] spawn;
    public GameObject parent;
    public int SpawnsMin;
    public int SpawnsMax;
    public int columns;
    public int rows;

    GameObject[][] slots;
    int[][] slotsTaken;
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
    public GameObject[] slot10;
    public GameObject[] slot11;
    public GameObject[] slot12;
    public GameObject[] slot13;
    public GameObject[] slot14;
    public GameObject[] slot15;
    public GameObject[] slot16;
    public GameObject[] slot17;
    public GameObject[] slot18;
    public GameObject[] slot19;

	// Use this for initialization
	void Start () {
        slots = new GameObject[columns][];
        slotsTaken = new int[columns][];
        if(columns >= 1 && slot0 != null)    {  slots[0] = slot0;     slotsTaken[0] = new int[slot0.Length];    }
        if(columns >= 2 && slot1 != null)    {  slots[1] = slot1;     slotsTaken[1] = new int[slot1.Length];    }
        if(columns >= 3 && slot2 != null)    {  slots[2] = slot2;     slotsTaken[2] = new int[slot2.Length];    }
        if(columns >= 4 && slot3 != null)    {  slots[3] = slot3;     slotsTaken[3] = new int[slot3.Length];    }
        if(columns >= 5 && slot4 != null)    {  slots[4] = slot4;     slotsTaken[4] = new int[slot4.Length];    }
        if(columns >= 6 && slot5 != null)    {  slots[5] = slot5;     slotsTaken[5] = new int[slot5.Length];    }
        if(columns >= 7 && slot6 != null)    {  slots[6] = slot6;     slotsTaken[6] = new int[slot6.Length];    }
        if(columns >= 8 && slot7 != null)    {  slots[7] = slot7;     slotsTaken[7] = new int[slot7.Length];    }
        if(columns >= 9 && slot8 != null)    {  slots[8] = slot8;     slotsTaken[8] = new int[slot8.Length];    }
        if(columns >= 10 && slot9 != null)   {  slots[9] = slot9;     slotsTaken[9] = new int[slot9.Length];    }
        if(columns >= 11 && slot10 != null)  {  slots[10] = slot10;   slotsTaken[10] = new int[slot10.Length];  }
        if(columns >= 12 && slot11 != null)  {  slots[11] = slot11;   slotsTaken[11] = new int[slot11.Length];  }
        if(columns >= 13 && slot12 != null)  {  slots[12] = slot12;   slotsTaken[12] = new int[slot12.Length];  }
        if(columns >= 14 && slot13 != null)  {  slots[13] = slot13;   slotsTaken[13] = new int[slot13.Length];  }
        if(columns >= 15 && slot14 != null)  {  slots[14] = slot14;   slotsTaken[14] = new int[slot14.Length];  }
        if(columns >= 16 && slot15 != null)  {  slots[15] = slot15;   slotsTaken[15] = new int[slot15.Length];  }
        if(columns >= 17 && slot16 != null)  {  slots[16] = slot16;   slotsTaken[16] = new int[slot16.Length];  }
        if(columns >= 18 && slot17 != null)  {  slots[17] = slot17;   slotsTaken[17] = new int[slot17.Length];  }
        if(columns >= 19 && slot18 != null)  {  slots[18] = slot18;   slotsTaken[18] = new int[slot18.Length];  }
        if(columns >= 20 && slot19 != null)  {  slots[19] = slot19;   slotsTaken[19] = new int[slot19.Length];  }

        int rand1 = Random.Range(SpawnsMin,SpawnsMax);
        for (int i = 0; i < rand1; i++)
        {
            int rand2 = Random.Range(0, columns-1);
            int rand3 = Random.Range(0, rows-1);
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    if (j == rand2 && k == rand3)
                    {
                        if (Physics.OverlapSphere(slots[j][k].transform.position, 1.4f).Length > 10)
                        {
                            slotsTaken[j][k] = 1;
                        }
                        if (slotsTaken[j][k] != 1)
                        {
                            int rand4 = Random.Range(0, spawn.Length);
                            Quaternion randRot = new Quaternion(0, Random.Range(0f, 1f), 0, 1);
                            GameObject newObj = (GameObject)Instantiate(spawn[rand4], slots[j][k].transform.position, randRot);
                            newObj.transform.parent = parent.transform;
                            newObj.transform.position = new Vector3(newObj.transform.position.x, parent.transform.position.y+0.15f, newObj.transform.position.z);
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
