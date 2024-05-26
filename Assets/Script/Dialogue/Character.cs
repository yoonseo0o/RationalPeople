using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character
{
    public enum CharacterType
    {
        char1,
        char2,
        char3,
        char4
    }
    public enum ExpressionType
    {
        Usual,
        Happy,
        Angry
    }
    public class character
    {
        public CharacterType name;
        public int gauge;
    }
}
