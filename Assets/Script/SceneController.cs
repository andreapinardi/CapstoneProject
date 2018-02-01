﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneController : MonoBehaviour {

    public GameObject VRGroup;
    public enum VRMode
    {
        VROn,
        VROff
    }
    VRMode vrMode;
    // Use this for initialization
    void Awake()
    {
        vrMode = VRMode.VROff;
        DontDestroyOnLoad(gameObject);
        InvokeRepeating("toggle", 10f, 10f);
    }

    void toggle()
    {
        if (vrMode == VRMode.VROn)
        {
            Debug.Log("Starting Non-VR");
            VRGroup.SetActive(false);
            vrMode = VRMode.VROff;
        }
        else
        {
            Debug.Log("Starting VR");
            vrMode = VRMode.VROn;
            VRGroup.SetActive(true);
        }
        StartCoroutine(switchVRMode());
    }

    IEnumerator switchVRMode()
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(vrMode == VRMode.VROn ? "daydream" : "");
        yield return null;
        UnityEngine.XR.XRSettings.enabled = vrMode == VRMode.VROn;
    }
}
