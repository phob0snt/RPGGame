using UnityEngine;

public interface IEntity
{
    public string AddressablesPath { get; }
    public Transform Transform { get; }
    public string ID { get; }
    public void Initialize();
}
