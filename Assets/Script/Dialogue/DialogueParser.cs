using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // 대사 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); // csv 파일 가져옴

        string[] data = csvData.text.Split(new char[] { '\n' }); // 엔터 기준으로 나눠서 data 배열에 저장

        for(int i=1;i<data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Dialogue dialogue = new Dialogue(); // 대사 리스트 생성
            dialogue.name = row[1];

            List<string> contextsList = new List<string>();
            do
            { 
                contextsList.Add(row[2]);

                if (++i < data.Length)
                    row = data[i].Split(new char[] { ',' });
                else break;
            } while (row[0].ToString() == "");

            dialogue.contexts = contextsList.ToArray();
            dialogueList.Add(dialogue);
        }

        return dialogueList.ToArray();
    }
}
