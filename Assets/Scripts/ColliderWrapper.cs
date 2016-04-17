using UnityEngine;
using System.Collections;

public class ColliderWrapper : MonoBehaviour
{
    public delegate void CollisionEvent(Collider colissionInfo);
    public CollisionEvent onCollisionEnter;
    public CollisionEvent onCollisionStay;
    public CollisionEvent onCollisionExit;

    public void OnTriggerEnter(Collider col)
    {
        if (onCollisionEnter != null)
        {
            onCollisionEnter(col);
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (onCollisionStay != null)
        {
            onCollisionStay(col);
        }
    }

    public void OnTriggerExit(Collider col)
    {
        if (onCollisionExit != null)
        {
            onCollisionExit(col);
        }
    }
}
