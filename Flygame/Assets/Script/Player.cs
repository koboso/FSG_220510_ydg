using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour{

    private void OnCollisionEnter2D(Collision2D col){
        if (col.gameObject.tag == "Enemy"){
            Logics.Instance.ShowEffect(this.transform.transform.position);
            Logics.Instance.DestroyPlayer();
            col.gameObject.SetActive(false);
        }
    }
}
