using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueReader : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    Dialogue dialogue;
    
    bool isDialogue = true;
    bool isNext = true;

    int currentDialogueId = 10001;
    int contextCount = 0;
    private void Update()
    {
        if (isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    isNext = false;
                    dialogue = DatabaseManager.instance.GetDialogue(currentDialogueId);
                    
                    ShowDialogue();
                }
            }
        }
    }
    public void ShowDialogue()
    {
        txt_Dialogue.text = "";
        txt_Name.text = "";
        //HideUI

        StartCoroutine(TypeWriter());
    }
    IEnumerator TypeWriter()
    {
        SettingUI(true);
        string t_ReplaceText = dialogue.contexts[contextCount];

        t_ReplaceText = t_ReplaceText.Replace("'", ",");
        switch (dialogue.character)
        {
            case Character.CharacterType.player:
                txt_Name.text = "정우"; break;
            case Character.CharacterType.char1:
                txt_Name.text = "가은"; break;
            case Character.CharacterType.char2:
                txt_Name.text = "윤서"; break;
            case Character.CharacterType.char3:
                txt_Name.text = "엄"; break;
            case Character.CharacterType.char4:
                txt_Name.text = "리원"; break;
        }

        txt_Dialogue.text = t_ReplaceText;
                    ++contextCount;
        // 같은 인물 대화가 끝나면
        if (contextCount >= dialogue.contexts.Length)
        {
            contextCount = 0;
            if (dialogue.nextId == 0) currentDialogueId++;
            else currentDialogueId = dialogue.nextId;
        
        }
            isNext = true;
        yield return null;
    }
    void SettingUI(bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }
}
