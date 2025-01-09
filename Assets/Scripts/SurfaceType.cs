using UnityEngine;

public class SurfaceType : MonoBehaviour
{

    [SerializeField] float speedModifier; //Defines the surface effect on the player's speed.
    public float SpeedModifier { get { return speedModifier; } }
    public SurfaceKind MyType;
    public Color ColorEffect;

}

public enum SurfaceKind 
{
    Bush,
    Mud,
    DangerMud,
    Rocks
}