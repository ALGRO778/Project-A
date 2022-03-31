using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracingCameraEntity : MonoBehaviour
{
    public bool CameraRotate;
    public CarEntity targetObject;
    public float moving_threshold = 10f;
    Camera m_Camera;
    float m_OrthographicSize;

    // Start is called before the first frame update
    void Start()
    {
        m_Camera = this.GetComponent<Camera>();
        m_OrthographicSize = m_Camera.orthographicSize;
    }
 
    void Update()
    {
        this.transform.position = targetObject.transform.position;

        if (CameraRotate==true) 
        {this.transform.eulerAngles = new Vector3(targetObject.transform.eulerAngles.x, targetObject.transform.eulerAngles.y, targetObject.transform.eulerAngles.z-90); }
        

         Vector2 deltaPos = this.transform.position - targetObject.transform.position;
        m_Camera.orthographicSize = m_OrthographicSize + targetObject.Velocity * 0.1f;
         if (deltaPos.magnitude > moving_threshold)
         {
         deltaPos.Normalize();
         Vector2 newPosition = new Vector2(targetObject.transform.position.x, targetObject.transform.position.y) + deltaPos * moving_threshold;

         this.transform.position = new Vector3(newPosition.x, newPosition.y, this.transform.position.z);

        }
    }
}
