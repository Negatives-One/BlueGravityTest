using UnityEngine;

[CreateAssetMenu(fileName = "VisualInfoSO", menuName = "Blue Gravity/VisualInfoSO")]
public class VisualInfoSO : ScriptableObject
{
    public enum BodyType {Male, Female}

    public BodyType currentBodyType;
    
    public HatsSO.HatInfo hat;
    public HairsSO.HairInfo hair;
    public ClothsSO.ClothInfo cloth;
}
