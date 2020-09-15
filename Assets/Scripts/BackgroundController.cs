using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour
{
    [SerializeField]
    private Transform[] _backgrounds;
    [SerializeField]
    private float backgroundSpeed;
    private float[] startPosition;
    private float backgroundWidth;
    private Vector2 direction = new Vector2();

    // Start is called before the first frame update
    void Start()
    {
        startPosition = new float[_backgrounds.Length];
        for (int i = 0; i < _backgrounds.Length; i++)
        {
            if (i == 0)
            {
                startPosition[i] = _backgrounds[i].localPosition.x;
            }
            else
            {
                startPosition[i] = _backgrounds[i].localPosition.x;
                backgroundWidth = startPosition[i - 1] - _backgrounds[i].localPosition.x;
            }
        }

    }

    public float NewBackgroundPosition(float positionX)
    {
        return positionX - (backgroundWidth * (_backgrounds.Length));
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(-Time.deltaTime * backgroundSpeed, 0, 0));
    }
}
