using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsScreen : MonoBehaviour {

    public Text scoreText;

    private void Start()
    {
        scoreText.text = GameState.Score.ToString();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            GameState.NextLevel();
        }
    }
}
