using UnityEngine;

public interface IEntity
{
    public Transform Transform { get; }
    public string ID { get; }
    public void Initialize();
}
