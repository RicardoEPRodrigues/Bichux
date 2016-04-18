using UnityEngine;
using System.Collections;

public class SpeedChanger : MonoBehaviour
{
    [SerializeField]
    private float baseSpeed = 5f;
    private float speed;
    [SerializeField]
    private float maxSpeed = 10f;
    [SerializeField]
    private float speedMultiplier = 0.1f;
    [SerializeField]
    private float updateTime = 5f;
    [SerializeField]
    private bool isUpdating = false;


    public float BaseSpeed
    {
        get
        {
            return baseSpeed;
        }

        set
        {
            this.baseSpeed = value;
        }
    }

    public float MaxSpeed
    {
        get
        {
            return maxSpeed;
        }

        set
        {
            this.maxSpeed = value;
        }
    }

    public float SpeedMultiplier
    {
        get
        {
            return speedMultiplier;
        }

        set
        {
            this.speedMultiplier = value;
        }
    }

    public float UpdateTime
    {
        get
        {
            return updateTime;
        }

        set
        {
            this.updateTime = value;
        }
    }

    public bool IsUpdating
    {
        get
        {
            return isUpdating;
        }

        set
        {
            this.isUpdating = value;
        }
    }

    public float Speed
    {
        get
        {
            return speed;
        }
    }

    // Use this for initialization
    void Start()
    {
        this.speed = this.baseSpeed;
        StartCoroutine(IncreaseSpeed());
    }

    private IEnumerator IncreaseSpeed()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.updateTime);
            if (this.speed < maxSpeed && this.isUpdating)
            {
                this.speed += this.speed * this.speedMultiplier;
            }
        }
    }

    public void Reset()
    {
        this.speed = this.baseSpeed;
    }
}
