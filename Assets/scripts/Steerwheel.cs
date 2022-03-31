using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Steerwheel : MonoBehaviour
{
    Image m_TargetRenderer;
    //ImagePosition m_TargetRenderer;
    //public CarEntity targetObject;
    public float m_FrontWheelAngle = 0;
    const float WHEEL_ANGLE_LIMIT = 40f;
    public float turnAngularVelocity = 20f;
   
    // Start is called before the first frame update
    void Start()
    { m_TargetRenderer = this.GetComponent<Image>(); }
    void UpdateWheels()
    {
        //Update wheels by m_FrontWheelAngle
        Vector3 localEulerAngles = new Vector3(0f, 0f, m_FrontWheelAngle);
        this.transform.localEulerAngles = localEulerAngles;
        
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        { //trn lft
            m_FrontWheelAngle = Mathf.Clamp(
            m_FrontWheelAngle + Time.deltaTime * turnAngularVelocity,
            -WHEEL_ANGLE_LIMIT, WHEEL_ANGLE_LIMIT);

            UpdateWheels();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        { //trn right
            m_FrontWheelAngle = Mathf.Clamp(
                m_FrontWheelAngle - Time.deltaTime * turnAngularVelocity,
                -WHEEL_ANGLE_LIMIT, WHEEL_ANGLE_LIMIT);

            UpdateWheels();
        }

        if(m_FrontWheelAngle == WHEEL_ANGLE_LIMIT|| m_FrontWheelAngle == -WHEEL_ANGLE_LIMIT)
         GetComponent<Image>().color = Color.red;
        else GetComponent<Image>().color = Color.white;
    }
}
