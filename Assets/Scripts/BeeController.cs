using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace FlappyBee { 
public class BeeController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [Range(1,15)]
    public float thrust = 1f;

        public GameObject panelScore;
        
        public GameObject panelTry;
        //public Collider2D cameraCollider;

        // Start is called before the first frame update
        void Start()
    {
            
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(CrossPlatformInputManager.GetButtonDown("Jump"))
        {
            _rigidbody.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
            GameManager.gm.OnDeath();
  
            }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag != "nectar")
                GameManager.gm.OnDeath();
        }
    }
}
