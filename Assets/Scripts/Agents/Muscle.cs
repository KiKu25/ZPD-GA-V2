﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muscle : MonoBehaviour {

    public GameObject target1;
    public GameObject target2;

    public float minDist { get; set; }
    public float maxDist { get; set; }

    // Use this for initialization
    void Start()
    {
        if (target1 == null)
            Debug.LogError("Target1 GameObject mising!!!");

        if (target2 == null)
            Debug.LogError("Target2 GameObject mising!!!");
    }

    private void Update()
    {
        transform.localScale = new Vector3(1,4 * GetDistance(target1, target2), 1);
        transform.position = new Vector3(target1.transform.position.x + (target2.transform.position.x - target1.transform.position.x) / 2, target1.transform.position.y + (target2.transform.position.y - target1.transform.position.y) / 2, target1.transform.position.z + GetDistance(target1, target2) / 2);
        transform.eulerAngles = new Vector3(0, 0, 90 - GetAngle(target1.transform.position, target2.transform.position));
    }

    private float GetDistance(GameObject obj1, GameObject obj2)
    {
        return Vector3.Distance(obj1.transform.position, obj2.transform.position);
    }
    
    private float GetAngle(Vector3 vec1, Vector3 vec2)
    {
        Vector3 diference = vec2 - vec1;
        float sign = (vec2.y < vec1.y) ? -1.0f : 1.0f;
        return Vector3.Angle(Vector3.left, diference) * sign;
    }
}