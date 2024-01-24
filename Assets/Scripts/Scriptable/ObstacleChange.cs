using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItem", menuName = "Obstacle/ObstacleType", order = 1)]   
public class ObstacleChange : ScriptableObject
{
    // Start is called before the first frame update
public float Amount;
public string ObstacleType;
public Material material;

}
