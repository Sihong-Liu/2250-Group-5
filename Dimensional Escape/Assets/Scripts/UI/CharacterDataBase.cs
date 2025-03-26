
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu]
public class CharacterDataBase :ScriptableObject
{
    public Character[] character;

    public int CharacterCount
    {
        get
        {
            return character.Length;
            
        }
        
    }

    public Character GetCharacter(int index)
    {
        return character[index];
    }
    
   
}


