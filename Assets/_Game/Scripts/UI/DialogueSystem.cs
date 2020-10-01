using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {
    public static DialogueSystem Instance { get; set; }
    public GameObject dialoguePanel;
    public string npcName;


    Button continueButton;
    Text dialogueText, nameText;
    int dialogueIndex;

    public List<string> dialogueLines = new List<string>();
    // Use this for initialization
    void Awake ()
    {
        continueButton = dialoguePanel.transform.Find("ContinueButton").GetComponent<Button>();
        dialogueText = dialoguePanel.transform.Find("Text").GetComponent<Text>();
        nameText = dialoguePanel.transform.Find("NpcName").GetChild(0).GetComponent<Text>();
        continueButton.onClick.AddListener(delegate { ContinueDialogue(); } );
        dialoguePanel.SetActive(false);

		if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
	}
	

    public void AddNewDialogue(string[] lines,string npcName)
    {
        dialogueIndex = 0;
        dialogueLines = new List<string>();
        foreach(string line in lines)
        {
            dialogueLines.Add(line);
        }
        this.npcName = npcName; 
        CreateDialogue();

    }

    public void CreateDialogue()
    {
        dialogueText.text = dialogueLines[dialogueIndex];
        nameText.text = npcName;
        dialoguePanel.SetActive(true);

    }

    public void ContinueDialogue()
    {
        if(dialogueIndex < dialogueLines.Count-1)
        {
            dialogueIndex++;
            dialogueText.text = dialogueLines[dialogueIndex];
        }
        else
        {
            dialoguePanel.SetActive(false);
        }

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ContinueDialogue();
        }
    }
}
