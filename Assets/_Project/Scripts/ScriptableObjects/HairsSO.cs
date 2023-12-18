using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

[CreateAssetMenu(fileName = "HairsSO", menuName = "Blue Gravity/HairsSO")]
public class HairsSO : ScriptableObject
{
    [SerializeField] private List<HairInfo> hairs = new List<HairInfo>();


    public HairInfo GetHair(int index)
    {
        return hairs[index];
    }

    [Serializable]
    public class HairInfo
    {
        public string name;
        public AnimatorController controller;
    }
}
