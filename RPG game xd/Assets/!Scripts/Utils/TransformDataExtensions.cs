using UnityEngine;

public static class TransformDataExtensions
{
    public static void SetPositionAndRotation(this Transform transform, TransformData data)
    {
        transform.position = new Vector3(data.xPos, data.yPos, data.zPos);
        transform.rotation = new Quaternion(data.xQuat, data.yQuat, data.zQuat, data.wQuat);
    }
}
