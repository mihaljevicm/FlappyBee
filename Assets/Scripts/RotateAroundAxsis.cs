using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBee
{ 
public class RotateAroundAxsis : MonoBehaviour
{
    private Transform _transform;
    public int value;
    [SerializeField]
    private float _RotationSpeed;
    private GameManager gm;

    private void Start()
    {
            gm = FindObjectOfType<GameManager>();
        _transform = transform;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        _transform.RotateAround(new Vector3(0, 0, 1), Time.deltaTime * _RotationSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            gm.ScoreIncrement(value);
            Destroy(this.gameObject);
        }
    }
}
}