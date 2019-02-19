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

    float yInput;
    float xInput;
    // Use this for initialization
    void Start()
    {
        m_current_planet_index_ = 0;
        m_originGameObject = m_planets[m_current_planet_index_];
        m_distance = (m_originGameObject.transform.position - transform.position).magnitude;
        // m_distance += m_originGameObject.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        yInput += Input.GetAxis("Mouse Y");
        xInput += Input.GetAxis("Mouse X");
       // transform.eulerAngles += new Vector3(yInput, xInput);
        transform.localRotation = Quaternion.Euler(yInput, xInput, 0);
        transform.localPosition = m_planets[m_current_planet_index_].transform.position - (transform.localRotation * Vector3.forward * m_distance);
        
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
