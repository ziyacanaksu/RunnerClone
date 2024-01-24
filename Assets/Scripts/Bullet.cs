using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float lifeTime;
    private void Awake() {
        
    }
    private void Start() {
        Destroy(gameObject,lifeTime);
    }



    private void OnEnable() {
        
    }
    private void OnDestroy() {
        
        
    }


}
