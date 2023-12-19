using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "EquipableInfoSO", menuName = "Blue Gravity/EquipableInfoSO")]
public class EquipableInfoSO : ScriptableObject
{
    public string name;
    public enum EquipmentType
    {
        Hat,
        Hair,
        Cloth
    }
    [SerializeField] private EquipmentType equipmentType;
    public AnimatorController controller;
}
