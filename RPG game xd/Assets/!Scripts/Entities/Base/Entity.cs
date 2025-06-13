using UnityEngine;

public abstract class Entity : MonoBehaviour, IEntity
{
    public abstract string AddressablesPath { get; }
    public Transform Transform => transform;

    public string ID { get; private set; }

    public abstract void Initialize();

    public void SetID(string id)
    {
        ID = id;
    }
}
