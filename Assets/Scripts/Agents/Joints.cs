using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joints : MonoBehaviour {

    private SpringJoint2D spJoint;

    public GameObject goMuscle;

    public float minDist { get; set; }
    public float maxDist { get; set; }
    public bool spawnMuscle = true;

    private void Start()
    { 
        spJoint = GetComponent<SpringJoint2D>();
        SpawnMuscle(spJoint.connectedBody.GetComponent<GameObject>());
    }

    private void Update()
    {
        if (minDist != 0 || maxDist != 0)
        {
            ClampDistance(minDist, maxDist);
        }
    }

    private void SpawnMuscle(GameObject target)
    {
        if (spawnMuscle)
        {
            Instantiate(goMuscle, new Vector3(), Quaternion.identity);
            Muscle muscle = goMuscle.GetComponent<Muscle>();
            muscle.target1 = gameObject;
            muscle.target2 = target;
        }
    }

    private void ClampDistance(float min, float max)
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

    private void SetDamping(float amount)
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

    private void SetFrequency(float amount)
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
}
