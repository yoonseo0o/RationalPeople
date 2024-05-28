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
            case "정우":
                return CharacterType.player;
            case "가은":
                return CharacterType.char1;
            case "윤서":
                return CharacterType.char2;
            case "엄":
                return CharacterType.char3;
            case "리원":
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
