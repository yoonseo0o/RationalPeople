using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public int id;
    public Character.CharacterType character;
    public Character.ExpressionType expression;
    public string[] contexts;
    public string keyword;
    public int nextId;
}