using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpPoints : MonoBehaviour
{
    public int scoreToGive;

    private ScoreManager scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.name == "Player")
        {
            scoreManager.AddScore(scoreToGive);
            gameObject.SetActive(false);
        }
    }
}
