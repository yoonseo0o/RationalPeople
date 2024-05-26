using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Choices
{
    public int id;
    public Choice[] choice;
}
public class Choice
{
    public string[] contexts;
    public string character;
    public int impactValue;
    public int nextDialogueId;
}