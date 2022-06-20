using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effector : MonoBehaviour{
    float t = 0;

    private void OnEnable(){
        t = 0;
    }

    private void Update(){
        if(t >= 3.5f){
            t = 0;
            this.gameObject.SetActive(false);
        }
        t += Time.fixedDeltaTime;
    }



}
