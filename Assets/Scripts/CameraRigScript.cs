using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRigScript : MonoBehaviour {


    [SerializeField]
    protected GameObject m_target;
    
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform temp = GetComponentInParent<Transform>();
        transform.position.Set(transform.position.x, temp.position.y, transform.position.z);
        transform.LookAt(m_target.transform);
    }
}
