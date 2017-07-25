using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour {

    private SpringJoint2D spJoint;

    public GameObject goTarget;
    public GameObject goMusclePrfab;
    public GameObject goMuscle;

    public float minDist { get; set; }
    public float maxDist { get; set; }

    public float contractionRate { get; set; }
    public float timeBetwenePulses { get; set; }
    public float timeDeckey { get; set; }
    private float currentPulseTime = 0;
    private bool contracting = true;

    private void Start()
    { 
        spJoint = GetComponent<SpringJoint2D>();
        spJoint.connectedBody = goTarget.GetComponent<Rigidbody2D>();
        SpawnMuscle();

        if (contractionRate == 0)
            contractionRate = 0.5f;
        if (timeBetwenePulses == 0)
            timeBetwenePulses = 1f;
        if (timeDeckey == 0)
            timeDeckey = 0.01f;
    }

    private void Update()
    {
        ClampDistance(minDist, maxDist);      
        UpdateMuscle();
    }

    private void FixedUpdate()
    {
        TwitchMuscle();
    }

    /// <summary>
    /// Spawns Muscle
    /// </summary>
    private void SpawnMuscle()
    { 
        goMuscle = Instantiate(goMusclePrfab, new Vector3(), Quaternion.identity);
        goMuscle.transform.SetParent(transform);
    }

    /// <summary>
    /// Clamp Distance of Muscle
    /// </summary>
    /// <param name="minDistance"></param>
    /// <param name="maxDistance"></param>
    private void ClampDistance(float min, float max)
    {
        if (max != 0)
        {
            if (spJoint.distance > max)
            {
                spJoint.distance = max;
            }
            else if (spJoint.distance < min)
            {
                spJoint.distance = min;
            }  
        }
    }

    /// <summary>
    /// Get Damping amount
    /// </summary>
    /// <param name="amount"></param>
    public void SetDamping(float amount)
    {
        if (1 < amount)
        {
            spJoint.dampingRatio = 1;
        }
        if (0 > amount)
        {
            spJoint.dampingRatio = 0;
        }
        else
        {
            spJoint.dampingRatio = amount;
        }
    }

    /// <summary>
    /// Get Damping amount
    /// </summary>
    /// <returns></returns>
    public float GetDamping()
    {
        return spJoint.dampingRatio;
    }

    /// <summary>
    /// Set Frequency
    /// </summary>
    /// <param name="amount"></param>
    public void SetFrequency(float amount)
    {
        if (0 > amount)
        {
            spJoint.frequency = 0;
        }
        else
        {
            spJoint.frequency = amount;
        }
    }

    /// <summary>
    /// Get Frequency
    /// </summary>
    /// <returns></returns>
    public float GetFrequency()
    {
        return spJoint.frequency;
    }

    /// <summary>
    /// Muscle Loacation and Rotation
    /// </summary>
    private void UpdateMuscle()
    {
        goMuscle.transform.localScale = new Vector3(1, 4 * GetDistance(goTarget), 1);
        goMuscle.transform.position = new Vector3(transform.position.x + (goTarget.transform.position.x - transform.position.x) / 2, transform.position.y + (goTarget.transform.position.y - transform.position.y) / 2, transform.position.z + GetDistance(goTarget) / 2);
        goMuscle.transform.eulerAngles = new Vector3(0, 0, 90 - GetAngle(goTarget.transform.position));
    }

    /// <summary>
    /// Get Distance betweene two GameObjects
    /// </summary>
    /// <param name="goTarget"></param>
    /// <returns></returns>
    private float GetDistance(GameObject obj1)
    {
        return Vector3.Distance(transform.position, obj1.transform.position);
    }

    /// <summary>
    /// Get Angle betweene tow GameObjects
    /// </summary>
    /// <param name="vector"></param>
    /// <returns></returns>
    private float GetAngle(Vector3 vec1)
    {
        Vector3 diference = vec1 - transform.position;
        float sign = (vec1.y < transform.position.y) ? -1.0f : 1.0f;
        return Vector3.Angle(Vector3.left, diference) * sign;
    }

    private void TwitchMuscle()
    {
        if (currentPulseTime == 0)
        {
            //Kad muscle sasniedz savu min/max distanci tad tas maina savu saliksanas virzienu
            if (maxDist != 0)
            {
                if (spJoint.distance > maxDist)
                {
                    contracting = true;
                }
                else if (spJoint.distance < minDist)
                {
                    contracting = false;
                }
            }

            if (contracting)
            {
                spJoint.distance -= contractionRate;
            }
            else
            {
                spJoint.distance += contractionRate;
            }

            currentPulseTime = timeBetwenePulses;
        }
        else
        {
            currentPulseTime -= timeDeckey;
        }
    }
}
