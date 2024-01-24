using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PassThrough : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] ObstacleChange Obstacle;
    [SerializeField] TextMeshProUGUI ObstacleNum;
    [SerializeField] TextMeshProUGUI ObstacleText;
    private float Amount;
    public static Action<float> rateAction;
    public static Action<float> distanceAction;

    void Start()
    {
        SetMaterial();
        Amount = Obstacle.Amount;
        ObstacleNum.text = Amount.ToString();
        ObstacleText.text = Obstacle.ObstacleType ;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Constants.Bullet))
        {
            if(Amount>0){
                Amount -= 1;
                UpdateObstacleText(); // Update the text on the UI
                Destroy(other.gameObject);

                if (Amount == 0)
                {
                    DisableObtsacle();
                }
            }
            else{
                Amount += 1;
                UpdateObstacleText();
                Destroy(other.gameObject);
                if (Amount == 0)
                {
                    DisableObtsacle();
                }



            }
        }
    }
    private void UpdateObstacleText()
    {

        ObstacleNum.text = Amount.ToString(); // Update the text
    }
    private void SetMaterial(){
        Renderer childRenderer = GetComponentInChildren<Renderer>();

        // Check if the Renderer and material are not null
        if (childRenderer != null && Obstacle.material != null)
        {
            // Set the material
            childRenderer.material = Obstacle.material;
        }

    }
    



    private void DisableObtsacle(){
        gameObject.SetActive(false);

    }
    private void OnDisable() {
        if(Obstacle.ObstacleType == Constants.FireRate){
            rateAction?.Invoke(Obstacle.Amount);
        }
        else if (Obstacle.ObstacleType ==Constants.Distance) 
        {
            Debug.Log("Distance");
            distanceAction?.Invoke(Obstacle.Amount);
        }
            
        
    }
}
