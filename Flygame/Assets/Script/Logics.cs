using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logics : MonoBehaviour{
    public enum PLAYER_DIR { NONE = 0, LEFT = 1, RIGHT = 2};
    public PLAYER_DIR DIR = PLAYER_DIR.NONE;

    public float speed = 10f;
    // 총알 스피드 값
    public float bulletspeed;
    public GameObject bullet;
    public GameObject player;

    private static Logics instance = null;

    // 총알을 저장할 배열.
    private GameObject[] bullets = new GameObject[100];
    // 총알의 인덱스값.
    private int bulletPrimaryNumber = 0;


    public static Logics Instance{
        get{
            return instance;
        }
    }

    void Awake(){
        if (instance == null) instance = this;
    }

    private void Start(){
        
        for(int i = 0; i< bullets.Length; i++){
            bullets[i] = Instantiate(bullet, Vector3.zero, Quaternion.identity, this.transform);
            bullets[i].SetActive(false);
        }
    }

    private void FixedUpdate(){

        if (DIR == PLAYER_DIR.LEFT){
            player.transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
        else if(DIR == PLAYER_DIR.RIGHT){
            player.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
    }

    // 총알이 생성되서 발사되는 함수.
    public void Fire(){
        if (bulletPrimaryNumber >= bullets.Length) bulletPrimaryNumber = 0;
        bullets[bulletPrimaryNumber].SetActive(true);
        bullets[bulletPrimaryNumber].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        bullets[bulletPrimaryNumber].transform.position = player.transform.position;
        bullets[bulletPrimaryNumber].GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed * Time.fixedDeltaTime), ForceMode2D.Impulse);
        bulletPrimaryNumber++;
    }

}
