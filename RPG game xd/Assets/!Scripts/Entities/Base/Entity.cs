using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{
    public Transform Transform => transform;

    public string ID { get; private set; }

    public abstract void Initialize();

    public void SetID(string id)
    {
        ID = id;
    }
}
