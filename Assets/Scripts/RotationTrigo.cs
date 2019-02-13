using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationTrigo : MonoBehaviour
{
    [SerializeField]
    protected GameObject m_originGameObject;

    [SerializeField]
    protected float m_speed;
    protected float m_distance;

    private float m_time_;

    // Use this for initialization
    void Start()
    {
        m_distance =  (m_originGameObject.transform.position - transform.position).magnitude;
        m_time_ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float x = m_originGameObject.transform.position.x + Mathf.Cos(m_time_) * m_distance;
        float y = transform.position.y;
        float z = m_originGameObject.transform.position.z + Mathf.Sin(m_time_) * m_distance;
    
        transform.position = new Vector3(x, y, z);
        m_time_ += Time.deltaTime * m_speed;
    }
}
