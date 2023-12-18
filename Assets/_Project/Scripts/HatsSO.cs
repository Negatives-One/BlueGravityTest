using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

[CreateAssetMenu(fileName = "HatsSO", menuName = "Blue Gravity/HatsSO")]
public class HatsSO : ScriptableObject
{
    [SerializeField] private List<HatInfo> hats = new List<HatInfo>();


    public HatInfo GetHat(int index)
    {
        return hats[index];
    }

    [Serializable]
    public class HatInfo
    {
        public string name;
        public AnimatorController controller;
    }
}
