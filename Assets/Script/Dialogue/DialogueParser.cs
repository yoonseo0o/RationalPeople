using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueParser : MonoBehaviour
{
    public Dialogue[] Parse(string _CSVFileName)
    {
        List<Dialogue> dialogueList = new List<Dialogue>(); // ��� ����Ʈ ����
        TextAsset csvData = Resources.Load<TextAsset>(_CSVFileName); // csv ���� ������

        string[] data = csvData.text.Split(new char[] { '\n' }); // ���� �������� ������ data �迭�� ����

        for(int i=1;i<data.Length;)
        {
            string[] row = data[i].Split(new char[] { ',' });
            Dialogue dialogue = new Dialogue(); // ��� ����Ʈ ����
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
