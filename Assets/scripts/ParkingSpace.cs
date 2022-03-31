using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ParkingSpace : MonoBehaviour
{//PolygonCollider2D carbox;

    public GameObject MainGame;
    public GameObject RushHour;

    public bool SW;
    public bool SE;
    public bool NE;
    public bool NW;
    public bool allin;

    //public CarEntity targetObject;
    //SpriteRenderer[] m_TargetRenderer;
    SpriteRenderer m_TargetRenderer;
    //carbox = CarEntity.GetComponent<PolygonCollider2D>();

    // Start is called before the first frame update
    void Start()
    {
        //m_TargetRenderer = targetObject.GetComponent<SpriteRenderer[]>();
        m_TargetRenderer = this.GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.tag == "PSW")
        { SW = true; }
       
        if (collision.gameObject.tag == "PSE")
        { SE = true; }
       
        if (collision.gameObject.tag == "PNE")
        { NE = true; }
     
        if (collision.gameObject.tag == "PNW")
        { NW = true; }

    }
 

    private void OnTriggerExit2D(Collider2D  other)
    {
       if (other.gameObject.tag =="PSW")
         SW = false; 
       
        if (other.gameObject.tag == "PSE")
         SE = false; 
        
        if (other.gameObject.tag == "PNE")
        NE = false; 
        
        if (other.gameObject.tag == "PNW")
        NW = false; 

    }
    void Update()
    {
        if (SW && NW && SE && SE == true)
        {
            allin = true;
            //    m_TargetRenderer[1].color = Color.green;
            m_TargetRenderer.color = Color.green;
            this.Invoke("CreatingNewGame", 3f);
        }

        else
        {
            allin = false;
            m_TargetRenderer.color = Color.white;
        }

    }

    void CreatingNewGame()
    {
        MainGame.SetActive(false);
        RushHour.SetActive(true);
    }
}
