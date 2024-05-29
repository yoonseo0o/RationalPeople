using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueReader : MonoBehaviour
{
    [SerializeField] GameObject go_DialogueBar;
    [SerializeField] GameObject go_ChoicesBar;

    [SerializeField] Text txt_Dialogue;
    [SerializeField] Text txt_Name;
    [SerializeField] Text[] txt_Choice;

    Dialogue dialogue;
    Choices choices;

    bool isDialogue = true;
    bool isNext = true;

    bool t_isIgnore = true;
    char t_isColor= 'ⓦ';
    [SerializeField] private float typingTime = 0.5f;

    int currentId = 10001;
    int contextCount = 0;
    private void Awake()
    {
        for (int i = 0; i < go_ChoicesBar.transform.childCount; i++)
        {
            int index = i;
            go_ChoicesBar.transform.GetChild(i).GetComponent<Button>().onClick.AddListener(() => ChoiceButtonClick(index));
        }
    }
    private void Update()
    {
        if (isNext)
        {
                if (Input.GetKeyDown(KeyCode.Space))
                {
            if (isDialogue)
            {
                    isNext = false;
                    dialogue = DatabaseManager.instance.GetDialogue(currentId);

                    ShowDialogue();
            }
            else
            {
                isNext = false;
                choices = DatabaseManager.instance.GetChoices(currentId);

                ShowChoices();
            }
                }
        }
    }

    public void ShowDialogue()
    {
        SettingUI();
        StartCoroutine(DialogueWriter());
    }
    IEnumerator DialogueWriter()
    {
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

        string t_ReplaceText = dialogue.contexts[contextCount];

        t_ReplaceText = t_ReplaceText.Replace("'", ",");
        t_ReplaceText = t_ReplaceText.Replace("\\n", "\n");
        yield return StartCoroutine(TypingText(t_ReplaceText));
        
        ++contextCount;
        // 같은 인물 대화가 끝나면
        if (contextCount >= dialogue.contexts.Length)
        {
            contextCount = 0;
            if (dialogue.nextId == 0) currentId++;
            else
            {
                currentId = dialogue.nextId;
                if (currentId > 300000)
                    isDialogue = false;
            }
        
        }
            isNext = true;
        yield return null;
    }
    IEnumerator TypingText(string _text)
    {
        for (int textCount = 0; textCount < _text.Length; textCount++)
        {
            switch(_text[textCount])
            {
                case 'ⓦ':
                    t_isColor = 'ⓦ'; t_isIgnore = true;
                    continue;
                case 'ⓨ':
                    t_isColor = 'ⓨ'; t_isIgnore = false;
                    continue;
            }
            if (!t_isIgnore)
            {
                switch (t_isColor)
                {
                    case 'ⓨ':
                        txt_Dialogue.text += "<color=#FFE300>" + _text[textCount] + "</color>";
                        break;
                }
            }
            else
                txt_Dialogue.text += _text[textCount];

            yield return new WaitForSeconds(typingTime);
        }
    }

    public void ShowChoices()
    {
        SettingUI();
        StartCoroutine(ChoicesWriter());
    }
    IEnumerator ChoicesWriter()
    {
        for (int i = 0; i < txt_Choice.Length; i++)
        {
            txt_Choice[i].text = choices.choice[i].text;
        }
        yield return null;
    }
    void SettingUI()
    {
        if(isDialogue)
        {
            go_DialogueBar.SetActive(true);
            go_ChoicesBar.SetActive(false);
            txt_Dialogue.text = "";
            txt_Name.text = "";
        }
        else
        {
            go_ChoicesBar.SetActive(true);
            go_DialogueBar.SetActive(false);
            for (int i = 0; i < txt_Choice.Length; i++)
            {
                txt_Choice[i].text = "";
            }
        }
    }
    public void ChoiceButtonClick(int index)
    {
        string log = "";
        // 캐릭터들을 따로 선언하는 곳이 필요할 듯 
        switch (choices.choice[index].character)
        {
            case Character.CharacterType.player:
                log += "정우"; break;
            case Character.CharacterType.char1:
                log += "가은"; break;
            case Character.CharacterType.char2:
                log += "윤서"; break;
            case Character.CharacterType.char3:
                log += "엄"; break;
            case Character.CharacterType.char4:
                log += "리원"; break;
        }
        log += "의 게이지가 " + choices.choice[index].impactValue + "만큼 변동되었습니다.";
        Debug.Log(log);
        currentId = choices.choice[index].nextDialogueId;
        isDialogue = true;
        isNext = true;

        dialogue = DatabaseManager.instance.GetDialogue(currentId);
        ShowDialogue();
    }
}
