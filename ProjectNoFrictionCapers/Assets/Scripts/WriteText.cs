using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WriteText : MonoBehaviour 
{
    public static int whoseTalking = 1;
    public int WhatNumberTalking = 1;
    public string Instructions;
    char[] characters;
    Text InstructionText;

    bool switchText = true;
    float delay;
    float letterDelay;
    float switchDelay;
    int counter = 0;

    bool done = false;
    bool ConversationDone = false;

	// Use this for initialization
	void Start () 
    {
        ConversationDone = false;
        whoseTalking = 1;
        InstructionText = GetComponent<Text>();
        InstructionText.fontSize = Screen.width / 65;
        characters = Instructions.ToCharArray();
        InstructionText.text = "";
        counter = 0;
        delay = 0.03f;
        letterDelay = 0.03f;
        switchDelay = 1.0f;
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
                    delay = letterDelay;
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
                            InstructionText.text += "\r\n\n\n\n";
                            delay = switchDelay;
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
            transform.root.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * 0.1f;
            if(transform.root.GetComponent<CanvasGroup>().alpha <= 0.55f)
            {
                Application.LoadLevel("LevelSelect");
            }
        }
	}

    public void GotClicked()
    {
        done = true;
        InstructionText.text = "";
        for(int i = 0;i<characters.Length;i++)
        {
            if (characters[i].Equals('$'))
            {
                InstructionText.text += "\r\n\n\n\n";
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
