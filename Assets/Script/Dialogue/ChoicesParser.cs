using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesParser : MonoBehaviour
{
    Character char1;
    private void Awake()
    {
        char1 = new Character();
    }
    public Choices[] Parse(string _CSVFileName)
    {
        List<Choices> choicesList = new List<Choices>(); // 선택지 리스트 생성
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); // csv 파일 가져옴
        string[] data = csvData.text.Split(new char[] { '\n' }); // 엔터 기준으로 나눠서 data 배열에 저장
        for (int i = 3; i < data.Length; i++)
        {
            string[] row = data[i].Split(new char[] { ',' });
            //ID	Script	Character	ImpactValue	NextId
            Choices choices = new Choices();
            choices.id = int.Parse(row[0]);
            
            List<Choice> choiceList = new List<Choice>();
            do
            {
                Choice choice = new Choice();
                choice.text = row[1];
                choice.character = char1.GetCharacter(row[2]);
                choice.impactValue = int.Parse(row[3]);
                choice.nextDialogueId = int.Parse(row[4]);

                if (row[0] == "") i++;
                choiceList.Add(choice);
                if (i + 1 < data.Length)
                    row = data[i + 1].Split(new char[] { ',' });
                else break;
            } while (row[0] == "");

            choices.choice = choiceList.ToArray();
            choicesList.Add(choices);
        }
        Debug.Log("Choices Parsing Finish");
        return choicesList.ToArray();
    }
}
