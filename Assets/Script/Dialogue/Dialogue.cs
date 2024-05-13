using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    [Tooltip("��� ġ�� ĳ���� �̸�")]
    public string name;

    [Tooltip("��� ����")]
    public string[] contexts;
}

[System.Serializable]
public class DialogueEvent
{
    public string name; // ��ȭ �ó����� �̸�?
    public Vector2 line; // x��~y�ٱ��� ���
    public Dialogue[] dialogues;  
}