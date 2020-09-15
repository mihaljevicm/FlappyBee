using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace FlappyBee
{

    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private Canvas panelScore;
        [SerializeField]
        private Canvas panelTry;
        public TMPro.TMP_Text panelTryScore;
        public TMPro.TMP_Text textScore;
        public TMPro.TMP_Text textMaxScore;
        public BackgroundController backgroundController;
        public SpawnObsticle spawnObsticle;
        public static GameManager gm = new GameManager();
        private int _score = 0;
        private int _maxScore;

        // Start is called before the first frame update
        void Start()
        {
            if (gm == null) { 
                             gm = this;
                            }
           
            OnSpawn();
            _maxScore = PlayerPrefs.GetInt("Max Score");
            panelTryScore.text = "" + _score;
            textScore.text = "" + _score;
            textMaxScore.text = "" + _maxScore;
        }

        public void ScoreIncrement(int amount)
        {
            _score += amount;
            textScore.text = "" + _score;
            panelTryScore.text = "" + _score;
        }

        public void LivesManagement()
        {
            //TODO
        }

        public void OnDeath()
        {
            if (_score >= _maxScore)
            {
                _maxScore = _score;
                PlayerPrefs.SetInt("Max Score", _maxScore);
                textMaxScore.text = "" + _maxScore;

            }
            if (panelScore != null)
            {
                if (panelScore.isActiveAndEnabled)
                {
                    panelScore.enabled = false;
                }
            }
            else
            {
                Debug.LogWarning("null");
            }
            if (!panelTry.isActiveAndEnabled)
            {
                panelTry.enabled = true;
                panelTryScore.text = "" + _score;
            }
            Time.timeScale = 0;
        }

        public void OnSpawn()
        {
            Time.timeScale = 1;
            if (!panelScore.isActiveAndEnabled)
                panelScore.enabled = true;
            if (panelTry.isActiveAndEnabled)
                panelTry.enabled = false;
        }
    }
}
