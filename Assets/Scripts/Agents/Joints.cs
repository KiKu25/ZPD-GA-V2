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
    public bool spawnMuscle = true;

    private void Start()
    { 
        spJoint = GetComponent<SpringJoint2D>();
        spJoint.connectedBody = goTarget.GetComponent<Rigidbody2D>();
        SpawnMuscle(goTarget);
    }

    private void Update()
    {
        ClampDistance(minDist, maxDist);
        UpdateMuscle();
    }

    private void SpawnMuscle(GameObject target)
    {
        if (spawnMuscle)
        {
            goMuscle = Instantiate(goMusclePrfab, new Vector3(), Quaternion.identity);
        }
    }

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

    public float GetDamping()
    {
        return spJoint.dampingRatio;
    }

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

    public float GetFrequency()
    {
        return spJoint.frequency;
    }

    private void UpdateMuscle()
    {
        goMuscle.transform.localScale = new Vector3(1, 4 * GetDistance(goTarget), 1);
        goMuscle.transform.position = new Vector3(transform.position.x + (goTarget.transform.position.x - transform.position.x) / 2, transform.position.y + (goTarget.transform.position.y - transform.position.y) / 2, transform.position.z + GetDistance(goTarget) / 2);
        goMuscle.transform.eulerAngles = new Vector3(0, 0, 90 - GetAngle(goTarget.transform.position));
    }

    private float GetDistance(GameObject obj1)
    {
        return Vector3.Distance(transform.position, obj1.transform.position);
    }

    private float GetAngle(Vector3 vec1)
    {
        Vector3 diference = vec1 - transform.position;
        float sign = (vec1.y < transform.position.y) ? -1.0f : 1.0f;
        return Vector3.Angle(Vector3.left, diference) * sign;
    }
}
