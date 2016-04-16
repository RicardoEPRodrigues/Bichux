using UnityEngine;
using System.Collections;

public class ColliderWrapper : MonoBehaviour
{
    public delegate void CollisionEvent(Collider colissionInfo);
    public CollisionEvent onCollisionEnter;

    public void OnTriggerEnter(Collider col)
    {
        if (onCollisionEnter != null)
        {
            onCollisionEnter(col);
        }
    }
}
