﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;


public class CameraMove : MonoBehaviour {

    public float dampTime = 0.15F;  
    public GameObject rea;


    private Vector3 velocity = Vector3.zero;

    void Awake() {

        transform.position = new Vector3(rea.transform.position.x, transform.position.y, rea.transform.position.z);
    }


    void LateUpdate() {

        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(rea.transform.position.x, transform.position.y, rea.transform.position.z), ref velocity, dampTime);
    }
}