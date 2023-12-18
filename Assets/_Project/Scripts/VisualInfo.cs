using UnityEngine;

public class VisualInfo : MonoBehaviour
{
    public enum BodyType {Type1, Type2}

    public BodyType currentBodyType;
    
    public HatsSO.HatInfo hat;
    public HairsSO.HairInfo hair;
    public ClothsSO.ClothInfo cloth;
}
