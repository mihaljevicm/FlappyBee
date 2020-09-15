using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBee { 
public class DestroyObsticle : MonoBehaviour
{
        private void OnBecameInvisible()
        {
            if (GameManager.gm.spawnObsticle != null)
            { 
                GameManager.gm.spawnObsticle.InstantiateNewObsticle();
            }
        Destroy(this.gameObject);
    }
}
}