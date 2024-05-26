using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public int id;
    public string name;
    public string[] contexts;
    public string expression;
    public string keyWord;
    public int nextId;
}