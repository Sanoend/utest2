using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;
using UnityEngine.XR;
using UnityEngine.Advertisements;

public class LevelLoadComplite : MonoBehaviour {
	public Transform StonePrefab;
	public Transform CometaPrefab;
    public Transform GGCPrefab;
	void ResetCamerasAspect() {
		for (int i = 0; i < Camera.allCameras.Length; i++) {
			Camera cam = Camera.allCameras[i];
			if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None) {
				cam.ResetAspect();
			}
		}
	}

    void Start () {
		if (Advertisement.isInitialized == false) {
			Advertisement.Initialize ("1694233");
		}
        if (GlobalGameClass.GGC == null){
            Transform GGC;
			if (GameObject.FindObjectOfType<GlobalGameClass> () == null) {
				GGC = Instantiate (GGCPrefab);
			}
        }
	}
	
	void Update () {
		
	}
}
