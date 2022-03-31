using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushHourGameScene : MonoBehaviour
{
    public GameObject DarkGreenCar;
    public GameObject YellowCar;
    public GameObject OrangeCar;
    public GameObject GrayCar;
    public GameObject BlueCar;
    public GameObject PinkCar;
    public GameObject LightGreenCar;
    public GameObject RedCar;


    // Start is called before the first frame update
    void Start()
    {
        RushHourGame();


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N))
        {
            SelectNext();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveForward(Time.deltaTime);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveBackward(Time.deltaTime);
        }
    }

    void RushHourGame()
    {
        Debug.Log("Welcome to Rush Hour game. " +
            "Slide the blocking vehicles out of the way for the yellow car to exit.");
        Debug.Log("Press 'N' to select item; " +
            "'UpArrow' to moveForward; " +
            "'DownArrow' to moveBackward.");
        MakeGame();
    }

    List<Entity> m_Entities = new List<Entity>();

    int m_SelectedIndex = -1;
    Entity m_SelectedEntity = null;
    void MakeGame()
    {
        m_Entities.Add(new Entity("Dark Green Car", DarkGreenCar));
        m_Entities.Add(new Entity("Yellow Car", YellowCar));
        m_Entities.Add(new Entity("Orange Car", OrangeCar));
        m_Entities.Add(new Entity("Gray Car", GrayCar));
        m_Entities.Add(new Entity("Blue Car", BlueCar));
        m_Entities.Add(new Entity("Pink Car", PinkCar));
        m_Entities.Add(new Entity("Light Green Car", LightGreenCar));
        m_Entities.Add(new Entity("Red Car", RedCar));
    }

    void MoveForward(float time)
    {
        if (m_SelectedEntity != null)
        {
            Debug.Log(string.Format("Move forward <Color=white>(0)</color>",
                m_SelectedEntity.Name));
            m_SelectedEntity.MoveForward(time);
        }
        else
        {
            Debug.Log("You have to select a item first.");
        }

    }
    public void MoveBackward(float time)
    {
        if (m_SelectedEntity != null)
        {
            Debug.Log(string.Format("Move backward <Color=white>(0)</color>",
                m_SelectedEntity.Name));
            m_SelectedEntity.MoveBackward(time);
        }
        else
        {
            Debug.Log("You have to select a item first.");
        }

    }



    public void SelectNext()
    {
        if (m_Entities.Count == 0)
        {
            Deselect();
            Debug.Log("There is nothing in this space.");
            return;
        }
        if (++m_SelectedIndex >= m_Entities.Count)
        {
            m_SelectedIndex = 0;
        }

        m_SelectedEntity = m_Entities[m_SelectedIndex];

        Debug.Log(string.Format("<color=white>{0}</color> has been selected.", m_SelectedEntity.Name));
    }
    void Deselect()
    {
        m_SelectedIndex = -1;
        m_SelectedEntity = null;
    }


    public void Escape()
    {
        Debug.Log("<color=green>Congrats! You escape the room!</color>");
        Finish();
    }

    public void Die()
    {
        Debug.Log("<color=red>Oops! You died.</color>");
        Finish();
    }
    void Finish()
    {
        Debug.Log("Thanks for playing the game!");
        UnityEditor.EditorApplication.isPlaying = false;
    }


    public class Entity
    {
        protected string m_Name;
        protected GameObject m_GameObject;
        public string Name { get { return m_Name; } }
        public GameObject Car { get { return m_GameObject; } }
        public Entity(string name, GameObject car)
        {
            m_Name = name;
            m_GameObject = car;
        }

        public virtual void MoveForward(float time)
        {
            RushHourCar rushHourCar = m_GameObject.GetComponent<RushHourCar>();
            for (int i = 0; i < 2; i++)
            {
                rushHourCar.move_forward(time);
            }
            rushHourCar.move_forward(time);
        }
        public virtual void MoveBackward(float time)
        {
            RushHourCar rushHourCar = m_GameObject.GetComponent<RushHourCar>();
            for (int i = 0; i < 2; i++)
            {
                rushHourCar.move_backward(time);
            }
        }
    }

}