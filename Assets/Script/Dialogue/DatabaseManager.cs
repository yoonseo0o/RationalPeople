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

    public static bool isFinish = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DialogueParser theParser = GetComponent<DialogueParser>();

            Dialogue[] dialogues = theParser.Parse(Dialogue_FileName);
            for (int i = 0; i < dialogues.Length; i++)
            {
                dialogueDic.Add(dialogues[i].id, dialogues[i]);
            }
            isFinish = true;
        }
    }
    public Dialogue GetDialogue(int _dialogueId)
    {
        return dialogueDic[_dialogueId];
    }
}