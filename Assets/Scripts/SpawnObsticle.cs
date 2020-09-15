using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObsticle : MonoBehaviour
{
    public float backgroundSpeed;
    public Vector2 offsetX;
    public Vector2 offsetY;
    public List<Transform> obsticles = new List<Transform>();
    private Transform _lastObsticle;
    public Transform spawnStartPosition;

    private void Start()
    {
        _lastObsticle = Instantiate(obsticles[obsticles.Count-1], new Vector3(spawnStartPosition.position.x, 
                                                                              spawnStartPosition.position.y - Random.Range(offsetY.x/2, offsetY.y/2)),
                                                                  Quaternion.identity);
        _lastObsticle.gameObject.SetActive(false);
        _lastObsticle.parent = this.transform;
        foreach (Transform obsticle in obsticles)
        {
            Transform obsticleClone = Instantiate(obsticle, new Vector3(_lastObsticle.position.x + Random.Range(offsetX.x, offsetX.y), 
                                                                        Random.Range(offsetY.x, offsetY.y)), 
                                                  Quaternion.identity);

            obsticleClone.parent = this.transform;
            _lastObsticle = obsticleClone;

        }
    }

    void Update()
    {
        transform.Translate(new Vector3(-Time.deltaTime * backgroundSpeed, 0, 0));
    }

    public void InstantiateNewObsticle()
    {
        Transform obsticleClone = Instantiate(obsticles[Random.Range(0,obsticles.Count)], new Vector3(_lastObsticle.position.x + Random.Range(offsetX.x, offsetX.y),
                                                                        Random.Range(offsetY.x, offsetY.y)),
                                                  Quaternion.identity);

        obsticleClone.parent = this.transform;
        _lastObsticle = obsticleClone;
    }

    //~SpawnObsticle() {
    //    foreach (Transform child  in transform)
    //    {
    //        GameObject.Destroy(child.gameObject);
    //    }
    //}
}
