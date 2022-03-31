using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushHourCar : MonoBehaviour
{
    public Vector3 forwardDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public void move_forward(float time)
    {
        if (m_Velocity >= 0)
        {
            m_Velocity = Mathf.Min(maxVelocity,
                m_Velocity + time * acceleration);
        }
        else
        {
            m_Velocity += time * deceleration;
        }
        m_DeltaMovement = m_Velocity * time;
        this.transform.Translate(forwardDirection * m_DeltaMovement);
    }

    public void move_backward(float time)
    {
        if (m_Velocity >= 0)
        {
            m_Velocity = Mathf.Max(-maxVelocity,
                m_Velocity - time * acceleration);
        }
        else
        {
            m_Velocity -= time * deceleration;
        }
        m_DeltaMovement = m_Velocity * time;
        this.transform.Translate(forwardDirection * m_DeltaMovement);
    }

    void FixedUpdate()
    {


        if (m_Velocity != 0)
        {
            m_Velocity -= (Mathf.Sign(m_Velocity) * autoSlowdownRate * deceleration);
            //TriggerVelocityBuffer();
        }

        m_DeltaMovement = m_Velocity * Time.fixedDeltaTime;



        this.transform.Translate(forwardDirection * m_DeltaMovement);

    }

    public float Velocity { get { return m_Velocity; } }


    float m_Velocity;


    [SerializeField] SpriteRenderer[] m_Renderers = new SpriteRenderer[5];

    public float acceleration = 10f;
    public float deceleration = 15f;
    public float maxVelocity = 60f;

    public float autoSlowdownRate = 0.002f;

    float m_DeltaMovement;







    void Stop()
    {
        m_Velocity = 0;
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        Stop();

    }

    private void OnCollisionStay2D(Collision2D collision)
    {

    }

    private void OnCollisionExit2D(Collision2D collision)
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {

    }

    //private void OnTriggerStay2D(Collider2D other)
    //{

    //    GarageEntry garageEntry = other.gameObject.GetComponent<GarageEntry>();

    //    if (garageEntry != null)
    //    {
    //        ChangeColor(Color.green);
    //        //this.Invoke("ResetColor", 0.5f);
    //    }
    //}
}
