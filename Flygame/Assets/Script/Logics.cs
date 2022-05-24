using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logics : MonoBehaviour{
    public enum PLAYER_DIR { NONE = 0, LEFT = 1, RIGHT = 2};
    public PLAYER_DIR DIR = PLAYER_DIR.NONE;

    public float speed = 10f;
    // �Ѿ� ���ǵ� ��
    public float bulletspeed;
    public GameObject bullet;
    public GameObject player;

    private static Logics instance = null;

    // �Ѿ��� ������ �迭.
    private GameObject[] bullets = new GameObject[100];
    // �Ѿ��� �ε�����.
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

    // �Ѿ��� �����Ǽ� �߻�Ǵ� �Լ�.
    public void Fire(){
        if (bulletPrimaryNumber >= bullets.Length) bulletPrimaryNumber = 0;
        bullets[bulletPrimaryNumber].SetActive(true);
        bullets[bulletPrimaryNumber].GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        bullets[bulletPrimaryNumber].transform.position = player.transform.position;
        bullets[bulletPrimaryNumber].GetComponent<Rigidbody2D>().AddForce(new Vector2(0, bulletspeed * Time.fixedDeltaTime), ForceMode2D.Impulse);
        bulletPrimaryNumber++;
    }

}
