using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float bulletSpeed;
    private void Update() {
        transform.Translate(new Vector3(0,0,bulletSpeed*Time.deltaTime));
    }

}
