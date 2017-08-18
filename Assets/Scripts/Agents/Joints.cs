using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Joints : MonoBehaviour {

    private SpringJoint2D spJoint;

    public GameObject goTarget;
    public GameObject goMusclePrfab;
    public GameObject goMuscle;

    public float minDist { get; set; }
    public float maxDist { get; set; }

    public float contractionRate { get; set; }
    public float timeDeckey { get; set; }
    public float muscleContractionFlipTime { get; set; }

    public bool contracting = true;

    private float currentMuscleContractionFlipTime = 0;

    private void Start()
    { 
        spJoint = GetComponent<SpringJoint2D>();
        spJoint.connectedBody = goTarget.GetComponent<Rigidbody2D>();
        SpawnMuscle();

        if (contractionRate == 0)
            contractionRate = 1f;
        if (timeDeckey == 0)
            timeDeckey = 0.01f;
        if (minDist == 0)
            minDist = 5f;
        if (maxDist == 0)
            maxDist = 10f;
        if (muscleContractionFlipTime == 0)
            muscleContractionFlipTime = 15f;
    }

    private void Update()
    {
        UpdateMuscle();
        Mathf.Clamp(spJoint.distance, minDist, maxDist);
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
        goMuscle.transform.eulerAngles = new Vector3(0, 0, 90 - GetAngle(goTarget));
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
    private float GetAngle(GameObject obj1)
    {
        Vector3 diference = obj1.transform.position - transform.position;
        float sign = (obj1.transform.position.y < transform.position.y) ? -1.0f : 1.0f;
        return Vector3.Angle(Vector3.left, diference) * sign;        
    }

    private float GetXFromCircle()
    {
        return GetRadiuss() * Mathf.Cos(GetAngle(goTarget));
    }

    private float GetYFromCircle()
    {
        return GetRadiuss() * Mathf.Sign(GetAngle(goTarget));
    }

    private float GetRadiuss()
    {
        float X = transform.position.x - goTarget.transform.position.x;
        float Y = transform.position.y - goTarget.transform.position.y;
        return ((X * X) - (Y *Y)) * ((X * X) - (Y * Y));
    }

    private void TwitchMuscle()
    {
        //Kad muscle sasniedz savu min/max distanci tad tas maina savu saliksanas virzienu
        if (currentMuscleContractionFlipTime <= 0)
        {
            contracting = !contracting;
        }
        else
        {
            currentMuscleContractionFlipTime -= 0.1f;
        }

       
        /*
        if (contracting)
        {
            spJoint.distance -= contractionRate;
        }
        else
        {
            spJoint.distance += contractionRate;
        }
        */

        //TODO: Make me work
        if (contracting)
        {
            goTarget.transform.position = new Vector3(goTarget.transform.position.x - (contractionRate * GetXFromCircle()), goTarget.transform.position.y - (contractionRate * GetYFromCircle()));
        }
        else
        {
            goTarget.transform.position = new Vector3(goTarget.transform.position.x + (contractionRate * GetXFromCircle()), goTarget.transform.position.y + (contractionRate * GetYFromCircle()));
        }
    }
}
