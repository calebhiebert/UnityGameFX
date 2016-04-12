using UnityEngine;
using System.Collections;

public static class Extensions {

    public static float LookAngle(this Transform transform, Vector2 target)
    {
        var diff = (target - (Vector2)transform.position).normalized;
        var ang = (Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg) - 90;
        return ang;
    }

    public static Quaternion LookQuaternion(this Transform transform, Vector2 target)
    {
        return Quaternion.Euler(0, 0, transform.LookAngle(target));
    }
}
