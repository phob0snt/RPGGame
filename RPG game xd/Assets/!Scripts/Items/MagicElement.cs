using UnityEngine;

[CreateAssetMenu(fileName = "MagicElement", menuName = "MagicElement")]
public class MagicElement : ScriptableObject
{
    public ElementType ElementType;
    public Color BaseColor;
    public Color SecondColor;
}

public enum ElementType
{
    Fire,
    Ice,
    Lightning,
    Earth
}