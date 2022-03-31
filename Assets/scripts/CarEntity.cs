using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarEntity : MonoBehaviour
{
    public GameObject wheelFrontRight;
    public GameObject wheelFrontLeft;
    public GameObject wheelBackRight;
    public GameObject wheelBackLeft;

    public float m_FrontWheelAngle = 0;
    const float WHEEL_ANGLE_LIMIT = 40f;
    public float turnAngularVelocity = 5f;

    float m_Velocity = 0;
    public float Velocity { get { return m_Velocity; } }

    [SerializeField] public float natdecel = 1.5f;
    [SerializeField] public float acceleration = 2f;
    [SerializeField] public float deceleration = 3f;
    [SerializeField] public float maxVelocity = 60f;
    [SerializeField] public float carLength = 30f;
    [SerializeField] public int coll = 0;
    [SerializeField] private Text collText;
    public float m_DeltaMovement;

    [SerializeField] SpriteRenderer[] m_Renderders = new SpriteRenderer[5];
    private object collision;

    void ResetColor(){
        ChangeColor(Color.white);
    }
    void ChangeColor(Color color)
    {
        foreach (SpriteRenderer r in m_Renderders)
        { r.color = color; }
    }

    void Stop() {
        m_Velocity = 0;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Stop();
        ChangeColor(Color.red);
        coll = coll + 1;
        collText.text = coll.ToString();
    }
    void OnCollisionStay2D(Collision2D collision)
    {
        Stop();
    }
    void OnCollisionExit2D(Collision2D collision)
    {
        ResetColor();
    }
    void Start()
    { }
    void OnTriggerEnter2D(Collider2D other)
    {
        CheckPoint checkPoint = other.gameObject.GetComponent<CheckPoint>();

        if (checkPoint != null)
        {
            ChangeColor(Color.green);
            this.Invoke("ResetColor", 0.1f);
        }


        if (other.gameObject.tag == "Hole")
        {
            Debug.Log("Fell in the Hole!");
            UnityEditor.EditorApplication.isPlaying = false;
        }


    }
    void UpdateWheels()
    {
        //Update wheels by m_FrontWheelAngle
        Vector3 localEulerAngles = new Vector3(0f, 0f, m_FrontWheelAngle);
        wheelFrontLeft.transform.localEulerAngles = localEulerAngles;
        wheelFrontRight.transform.localEulerAngles = localEulerAngles;
       
    }
    void FixedUpdate()
    {

        if (Input.GetKey(KeyCode.UpArrow))
        {
            //Speed up
            m_Velocity = Mathf.Min(maxVelocity, m_Velocity + Time.deltaTime * acceleration);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            //spd dwn
            m_Velocity = Mathf.Max(-5, m_Velocity - Time.deltaTime * deceleration);
        }
        m_DeltaMovement = m_Velocity * Time.deltaTime;

       if (Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false && m_DeltaMovement >= 0)
       { m_Velocity = Mathf.Max(0, m_Velocity - Time.deltaTime * natdecel); }
       else if (Input.GetKey(KeyCode.UpArrow) == false && Input.GetKey(KeyCode.DownArrow) == false && m_DeltaMovement <= 0)
       { m_Velocity = Mathf.Min(0, m_Velocity + Time.deltaTime * natdecel); }

        this.transform.Rotate(0f, 0f, 1 / carLength * Mathf.Tan(Mathf.Deg2Rad * m_FrontWheelAngle) * m_DeltaMovement * Mathf.Rad2Deg);
        this.transform.Translate(Vector3.right * m_DeltaMovement);

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
    }

}

