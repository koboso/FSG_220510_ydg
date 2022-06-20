using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour{

    private void LateUpdate(){
        if (this.transform.position.y >= 15f) DestroyBullet();
    }

    // 충돌 체크
    private void OnCollisionEnter2D(Collision2D col){
        if(col.collider.gameObject.tag == "Enemy"){
            Logics.Instance.ShowEffect(col.collider.gameObject.transform.position);
            Logics.Instance.IncreaseScore();
            col.collider.GetComponent<Enemy>().DestroyEnemy();
            DestroyBullet();
        }
    }

    // 총알 비활성화
    public void DestroyBullet(){
        this.gameObject.SetActive(false);
    }
}
