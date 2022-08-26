using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewCharacterProfile", menuName = "ScriptableObjects/CharacterProfile", order = 1)]
public class CharacterProfile : ScriptableObject
{
    public string CharacterName;

    // Skills
    public Dictionary<string, ISkill> SkillDictionary;

}
