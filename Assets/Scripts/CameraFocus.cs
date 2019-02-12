using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{

    [SerializeField]
    protected float m_speed;

    [SerializeField]
    protected float m_distance;

    [SerializeField]
    private List<GameObject> m_planets;

    [SerializeField]
    private float m_offset_y;

    private float m_time_;
    private int m_current_planet_index_;
    private GameObject m_originGameObject;
    // Use this for initialization
    void Start()
    {
        m_current_planet_index_ = 0;
        m_originGameObject = m_planets[m_current_planet_index_];

        m_distance += m_originGameObject.transform.localScale.x;
        m_time_ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float x = m_originGameObject.transform.position.x + Mathf.Cos(m_time_) * m_distance;
        float y = m_originGameObject.transform.position.y + m_offset_y;
        float z = m_originGameObject.transform.position.z + Mathf.Sin(m_time_) * m_distance;

        m_time_ += Time.deltaTime * m_speed;
        GetComponent<Transform>().position = new Vector3(x, y, z);

        transform.LookAt(m_planets[m_current_planet_index_].transform);
        if (Input.GetKeyDown(KeyCode.Mouse0))
            PreviousPlanet();

        if (Input.GetKeyDown(KeyCode.Mouse1))
            NextPlanet();


    }

    void NextPlanet()
    {
        if (m_current_planet_index_ < m_planets.Count - 1)
        {
            m_current_planet_index_++;
        }
        else
            m_current_planet_index_ = 0;

        m_originGameObject = m_planets[m_current_planet_index_];
    }

    void PreviousPlanet()
    {
        if (m_current_planet_index_ - 1 >= 0)
        {
            m_current_planet_index_--;
        }
        else
            m_current_planet_index_ = m_planets.Count - 1;
        m_originGameObject = m_planets[m_current_planet_index_];
    }
}
