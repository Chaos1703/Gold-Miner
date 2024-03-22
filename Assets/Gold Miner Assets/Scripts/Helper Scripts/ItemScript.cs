using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScript : MonoBehaviour
{
    public float hookSpeed = 5f;
    public int scoreValue;
    void OnDisable(){
        GamePlayManager.instance.DisplayScore(scoreValue);
    }
}
