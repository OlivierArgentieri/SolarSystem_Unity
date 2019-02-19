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
        
        float yr = Input.GetAxis("Mouse X");
        float xr = Input.GetAxis("Mouse Y");
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        yr *= m_speed * Time.deltaTime;
        xr *= m_speed * Time.deltaTime *-1;
        x *= m_speed * Time.deltaTime;
        z *= m_speed * Time.deltaTime;
        transform.eulerAngles += new Vector3(xr, yr);
        transform.Translate(new Vector3(x, 0, z));
    }
}
