using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsCameraController : MonoBehaviour {

    [SerializeField]
    private float m_speed = 10;

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        float x = Input.GetAxis("Horizontal X");
        float y = Input.GetAxis("Horizontal Y");
        
    }
}
