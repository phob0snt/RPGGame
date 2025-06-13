using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameProfile
{
    public GameProfile()
    {
        PlayerData = new();
        EnemyData = new();
    }
    public PlayerData PlayerData;
    public List<EnemyData> EnemyData;
}

[System.Serializable]
public class TransformData
{
    public TransformData() {}

    public TransformData(Transform transform)
    {
        transform.GetPositionAndRotation(out var pos, out var rot);

        xPos = pos.x;
        yPos = pos.y;
        zPos = pos.z;

        xQuat = rot.x;
        yQuat = rot.y;
        zQuat = rot.z;
        wQuat = rot.w;
    }

    public float xPos, yPos, zPos;
    public float xQuat, yQuat, zQuat, wQuat;
}

[System.Serializable]
public class PlayerData
{
    public PlayerData()
    {
        Transform = new();
        Transform.xPos = -26.1f;
        Transform.yPos = 34.88f;
        Transform.zPos = 65.396f;

        Health = 100;
    }
    
    public TransformData Transform;
    public int Health;
}

[System.Serializable]
public class EnemyData
{
    public TransformData Transform;
    public string AddressablesPath;
}