using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;

public class VRYesPlease : MonoBehaviour {

	// Use this for initialization
	public void Start () {
        StartCoroutine(ActivatorVR("daydream"));
	}

    public IEnumerator ActivatorVR(string YESVR)
    {
        XRSettings.LoadDeviceByName(YESVR);
        yield return null;
        XRSettings.enabled = true;
    }
	
	
}
