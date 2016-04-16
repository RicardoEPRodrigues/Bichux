using UnityEngine;

public class Utilities
{
    public static bool WithinDistance(Vector3 start, Vector3 end, float distanceThreshold)
    {
        return Vector3.SqrMagnitude(end - start) < (distanceThreshold * distanceThreshold);
    }
}

