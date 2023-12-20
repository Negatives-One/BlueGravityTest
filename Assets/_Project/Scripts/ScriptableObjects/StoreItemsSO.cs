using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreItemsSO", menuName = "Blue Gravity/StoreItemsSO")]
public class StoreItemsSO : ScriptableObject
{
    public List<ItemPack> items = new List<ItemPack>();
}
