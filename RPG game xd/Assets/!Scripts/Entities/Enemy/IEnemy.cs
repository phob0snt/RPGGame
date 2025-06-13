using UnityEngine;

public interface IEnemy : IEntity
{
    public void SetTarget(Transform target);
    public void SetPosition(Vector3 position);
    public void SetPeaceful(bool isPeaceful);
    public void SetID(string id);
}