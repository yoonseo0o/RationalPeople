using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Character;

public class DialogueParser : MonoBehaviour
{
    Character char1;
    private void Awake()
    {
        char1 = new Character();
    }
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); // csv 파일 가져옴
        string[] data = csvData.text.Split(new char[] { '\n' }); // 엔터 기준으로 나눠서 data 배열에 저장

        for(int i=3;i<data.Length;i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            //ID	Script	Character	Expression	Keyword	NextId
            Dialogue dialogue = new Dialogue();
            dialogue.id = int.Parse(row[0]);
            dialogue.character = char1.GetCharacter(row[2]);
            dialogue.expression = char1.GetExpression(row[3]);
            if (row[4] != "0") dialogue.keyword = row[4];
            if (row[5] != "0") dialogue.nextId = int.Parse(row[5]);

            List<string> contextsList = new List<string>();
            do
            {
                if (row[0] == "") i++;
                contextsList.Add(row[1]);
                if (i+1 < data.Length)
                    row = data[i+1].Split(new char[] { ',' });
                else break;
            } while (row[0] == "");
            dialogue.contexts = contextsList.ToArray();
            dialogueList.Add(dialogue);
        }
        Debug.Log("Parsing Finish");
        return dialogueList.ToArray();
    }
}
