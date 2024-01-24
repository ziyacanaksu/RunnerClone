using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Gun;
    [SerializeField] Bullet bullet;
    [SerializeField] private float Timer;
    [SerializeField] private float fireRate;
    [SerializeField] private float lifeTime;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private float recoilForce;
    [SerializeField] private Rigidbody GunBody;
    private float minFireRate;
    private float minLifeTime;


    void Start()
    {
        minFireRate = 0;
        minLifeTime = 1;
        Timer= fireRate;
        PassThrough.rateAction += ChangeFireRate;
        PassThrough.distanceAction += ChangeLifeTime;

        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0)){
            Timer -= Time.deltaTime;
            if (Timer<0 ){
            Bullet newBullet = Instantiate(bullet,bulletSpawn.position,Quaternion.identity);
            newBullet.lifeTime = lifeTime;
            StartCoroutine(StartRecoil());
            Timer=fireRate;
             }
            
        }

        
    }

private void ChangeFireRate(float change){
    const float threshold = 20.0f; // Set the threshold value
    
    if(Mathf.Abs(change) >= threshold){
        // Only apply a significant change if the threshold is met or exceeded
        fireRate -= (change/40.0f); // More substantial change
        Debug.Log("Significant FireRate Change");
    } else {
        // Apply a smaller change if below the threshold
        fireRate -= (change/20.0f); // Less substantial change
    }
    fireRate = Mathf.Max(fireRate, minFireRate); // Ensure fire rate doesn't go below a minimum
    Debug.Log(fireRate);
}
private void ChangeLifeTime(float time){
    const float threshold = 20.0f; // Set the threshold value
    if(Mathf.Abs(time) >= threshold){
        // Only apply a significant change if the threshold is met or exceeded
        lifeTime += (time /25.0f); // More substantial change
    } else {
        // Apply a smaller change if below the threshold
        lifeTime += (time /10.0f); // Less substantial change
    }
    lifeTime = Mathf.Max(lifeTime, minLifeTime); // Ensure lifetime doesn't go below a minimum
    Debug.Log(lifeTime);
}

    private void ApplyRecoil()
    {
        // Apply a force to the gun Rigidbody that's the opposite direction of the bullet's travel
        GunBody.AddForce(Vector3.up * recoilForce, ForceMode.Impulse);
    }

    private void OnEnable() {
        
    }
    private void OnDisable() {

         PassThrough.rateAction -= ChangeFireRate;
        
    }
    IEnumerator StartRecoil()
    {
        Gun.GetComponent<Animator>().Play("Recoil");
        yield return new WaitForSeconds(0.20f);
        Gun.GetComponent<Animator>().Play("New State");
    }
}
