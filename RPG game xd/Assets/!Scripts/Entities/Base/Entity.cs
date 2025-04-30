using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{
    public Transform Transform => transform;
    public abstract void Initialize();
}
