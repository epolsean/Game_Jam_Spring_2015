using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WriteText : MonoBehaviour 
{
    public static int whoseTalking = 1;
    public int WhatNumberTalking;
    public string Instructions;
    char[] characters;
    Text InstructionText;

    bool switchText = true;
    float delay = 0.1f;
    float TempDelay = 0.1f;
    int counter = 0;

    bool done = false;
    bool ConversationDone = false;
    bool skipped = false;

	// Use this for initialization
	void Start () 
    {
        skipped = false;
        ConversationDone = false;
        whoseTalking = 1;
        InstructionText = GetComponent<Text>();
        characters = Instructions.ToCharArray();
        InstructionText.text = "";
        counter = 0;
        delay = 0.1f;
        TempDelay = 0.1f;
        switchText = true;
        done = false;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!done)
        {
            if (WhatNumberTalking == whoseTalking)
            {
                if (delay <= 0)
                {
                    delay = TempDelay;
                    switchText = true;
                }
                else
                {
                    delay -= Time.deltaTime;
                }
                if (switchText)
                {
                    if (counter < characters.Length)
                    {
                        if (characters[counter].Equals('$'))
                        {
                            if (whoseTalking == 1)
                            {
                                whoseTalking = 2;
                            }
                            else
                            {
                                whoseTalking = 1;
                            }
                            delay = 0.1f;
                            switchText = true;
                            done = false;
                            counter++;
                        }
                        else if(characters[counter].Equals('@'))
                        {
                            ConversationDone = true;
                        }
                        else
                        {
                            InstructionText.text += characters[counter];
                            counter++;
                        }
                    }
                    else
                    {
                        done = true;
                    }
                    switchText = false;
                }
            }
        }

        if (ConversationDone)
        {
            if (!skipped)
            {
                transform.root.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 0.1f;
            }
            else
            {
                transform.root.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 0.05f;
            }
            if(transform.root.GetComponent<CanvasGroup>().alpha <= 0.25f)
            {
                Application.LoadLevel("LevelSelect");
            }
        }
	}

    public void GotClicked()
    {
        skipped = true;
        done = true;
        InstructionText.text = "";
        for(int i = 0;i<characters.Length;i++)
        {
            if (characters[i].Equals('$'))
            {
                
            }
            else if (characters[i].Equals('@'))
            {
                ConversationDone = true;
            }
            else
            {
                InstructionText.text += characters[i];
            }
        }
        ConversationDone = true;
    }
}
