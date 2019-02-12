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

    private int m_current_planet_index_;
    private GameObject m_originGameObject;
    private Vector2 m_input_;

    // Use this for initialization
    void Start()
    {
        m_current_planet_index_ = 0;
        m_originGameObject = m_planets[m_current_planet_index_];

       // m_distance += m_originGameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        m_input_ += new Vector2(Input.GetAxis("Mouse Y") * m_speed, Input.GetAxis("Mouse X") * m_speed);
        transform.localRotation = Quaternion.Euler(m_input_.x, m_input_.y, 0);
        transform.localPosition = m_planets[m_current_planet_index_].transform.position - (transform.localRotation * Vector3.forward * m_distance);

        //transform.LookAt(m_planets[m_current_planet_index_].transform);
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
