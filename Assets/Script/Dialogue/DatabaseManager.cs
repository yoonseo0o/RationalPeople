using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager instance;
    [SerializeField] string Dialogue_FileName;
    [SerializeField] string Choices_FileName;
    Dictionary<int, Dialogue> dialogueDic = new Dictionary<int, Dialogue>();
    Dictionary<int, Choices> choicesDic = new Dictionary<int, Choices>();

    public static bool isFinish = false;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
            DialogueParser dialogueParser = GetComponent<DialogueParser>();
            ChoicesParser choicesParser = GetComponent<ChoicesParser>();

            Dialogue[] dialogues = dialogueParser.Parse(Dialogue_FileName);
            Choices[] choices = choicesParser.Parse(Choices_FileName);
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(dialogues[i].id, dialogues[i]);
            }
            for (int i = 0; i < choices.Length; i++)
            {
                choicesDic.Add(choices[i].id, choices[i]);
            }
            isFinish = true;
        }
    }
    public Dialogue GetDialogue(int _dialogueId)
    {
        return dialogueDic[_dialogueId];
    }
    public Choices GetChoices(int _choicesId)
    {
        return choicesDic[_choicesId];
    }
}