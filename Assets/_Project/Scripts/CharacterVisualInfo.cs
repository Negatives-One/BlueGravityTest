using System;
using UnityEngine;

[CreateAssetMenu(fileName = "HatsSO", menuName = "Blue Gravity/CharacterVisualInfoSO")]
public class CharacterVisualInfo : ScriptableObject
{
    public enum BodyType {Type1, Type2}

    public BodyType currentBodyType;
    
    public EquipableInfoSO hat;
    public EquipableInfoSO hair;
    public EquipableInfoSO cloth;
}
