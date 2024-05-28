using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public enum CharacterType
    {
        player,
        char1,
        char2,
        char3,
        char4
    }
    public enum ExpressionType
    {
        Usual,
        Happy,
        Angry,
        crying
    }
    public class character
    {
        public CharacterType name;
        public int gauge;
    }
    public CharacterType GetCharacter(string name)
    {
        switch (name)
        {
            case "����":
                return CharacterType.player;
            case "����":
                return CharacterType.char1;
            case "����":
                return CharacterType.char2;
            case "��":
                return CharacterType.char3;
            case "����":
                return CharacterType.char4;
            default:
                Debug.LogError("GetCharacter failed"); return 0;
        }
    }
    public ExpressionType GetExpression(string name)
    {
        switch (name)
        {
            case "Usual":
                return ExpressionType.Usual;
            case "Happy":
                return ExpressionType.Happy;
            case "Angry":
                return ExpressionType.Angry;
            case "crying":
                return ExpressionType.crying;
            default:
                return ExpressionType.Usual;
        }
    }
}
