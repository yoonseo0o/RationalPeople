using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class DialogueManager : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_DialogueNameBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;

    Dialogue[] dialogues;

    bool isDialogue = true;
    bool isNext = true;

    int lineCount = 0;
    int contextCount = 0;

    private void Start()
    {
        ShowDialogue(DatabaseManager.instance.GetDialogue(1, 6));
    }
    private void Update()
    {
        if(isDialogue)
        {
            if (isNext)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    Debug.Log(lineCount);
                    Debug.Log(contextCount);
                    isNext = false;
                    txt_Dialogue.text = "";
                    ++contextCount;
                    StartCoroutine(TypeWriter());
                }
            }
        }
    }
    public void ShowDialogue(Dialogue[] p_dialogues)
    {
        txt_Dialogue.text = "";
        txt_Name.text = "";
        //HideUI
        dialogues = p_dialogues;

        StartCoroutine(TypeWriter());
    }
    IEnumerator TypeWriter()
    {
        SettingUI(true);
        // 같은 인물 대화가 끝나면
        if (contextCount >= dialogues[lineCount].contexts.Length)
        {
            contextCount = 0;
            ++lineCount;
        }
        // 인물들 대화가 끝나지 않았으면
        if (lineCount < dialogues.Length)
        {
            string t_ReplaceText = dialogues[lineCount].contexts[contextCount];

            t_ReplaceText = t_ReplaceText.Replace("'", ",");

            txt_Name.text = dialogues[lineCount].name;
            txt_Dialogue.text = t_ReplaceText;

            isNext = true;
        }
        // 인물들 대화 종료
        else
        {
            isNext = false;
            SettingUI(false);
        }
        yield return null;

    }
    void SettingUI (bool p_flag)
    {
        go_DialogueBar.SetActive(p_flag);
        go_DialogueNameBar.SetActive(p_flag);
    }
}
