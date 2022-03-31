using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ending : MonoBehaviour
{
    public GameObject MainGame;
    public GameObject RushHour;
    public GameObject AnotherRushHour;

    private void OnTriggerEnter2D(Collider2D other)
    {
        EndingRushGame();
    }

    void EndingRushGame()
    {
        if (AnotherRushHour == null)
        {
            Debug.Log("You've completed the game. Congratulations!!");
            UnityEditor.EditorApplication.isPlaying = false;
        }
        else
        {
            GameObject.Destroy(RushHour.gameObject);
            MainGame.SetActive(true);
        }

    }
}