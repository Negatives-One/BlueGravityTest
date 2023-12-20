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
    public EquipmentType equipmentType;
    public RuntimeAnimatorController controller;
    public Sprite worldSprite;
}
