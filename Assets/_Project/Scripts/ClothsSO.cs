using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "ClothsSO", menuName = "Blue Gravity/ClothsSO")]
public class ClothsSO : ScriptableObject
{
    [SerializeField] private List<ClothInfo> cloths = new List<ClothInfo>();


    public ClothInfo GetCloth(int index)
    {
        return cloths[index];
    }

    [Serializable]
    public class ClothInfo
    {
        public string name;
        public AnimatorController controller;
    }
}
