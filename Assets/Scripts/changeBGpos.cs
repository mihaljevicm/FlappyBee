using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    namespace FlappyBee { 

public class changeBGpos : MonoBehaviour
{
    private float newXPosition;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
    }
    void OnBecameInvisible()
    {
        newXPosition = GameManager.gm.backgroundController.NewBackgroundPosition(_transform.localPosition.x);
        _transform.localPosition = new Vector2(newXPosition, _transform.localPosition.y);
    }
}
}
