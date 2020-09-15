using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace FlappyBee
{

    public class SceneChanger : MonoBehaviour
{
        //private GameManager gm;
        public TMPro.TMP_Text maxScoreText;

        private void Start()
        {
            //gm = FindObjectOfType<GameManager>();
            if (maxScoreText!=null)
            {
                maxScoreText.text = "" + PlayerPrefs.GetInt("Max Score");
            }
        }
        public void StartGame()
    {
        SceneManager.LoadScene("GameScene");
            Debug.Log("starting new game");
    }


    public void EndGame()
    {
            GameManager.gm.OnDeath();
            //SceneManager.LoadScene("MainMenuScene");
    }
}
}