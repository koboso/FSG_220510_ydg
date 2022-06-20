using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Logics : MonoBehaviour{
    public enum GameState{ Init = 0, Ready = 1, Play = 2, Pause = 3, Fail = 4 };
    private GameState gamestate = GameState.Init;

    public GameObject effect;
    public GameObject effectSpawn;
    private int effectIndex = 0;


    public Text startDialog; 
    public Button startBtn;
    public Text countText;
    public Text scoreText;
    public GameState GetState{
        get{
            return this.gamestate;
        }
    }

    public void SetGameState(GameState state){
        this.gamestate = state;
    }
    public enum PLAYER_DIR { NONE = 0, LEFT = 1, RIGHT = 2 };

    [Header("GAME UI")]
    public GameObject readyUI;
    public GameObject gameOverUI;
    public Slider hpBar;

    [Header("����")]
    public PLAYER_DIR DIR = PLAYER_DIR.NONE;

    [Header("���� ���ǵ�")]
    public float speed = 10f;
    // �Ѿ� ���ǵ� ��
    public float bulletspeed;
    public GameObject bullet;
    public GameObject player;

    private int score;



    private static Logics instance = null;

    // �Ѿ��� ������ �迭.
    private GameObject[] bullets = new GameObject[100];
    private GameObject[] effecters = new GameObject[100];

    // �Ѿ��� �ε�����.
    private int bulletPrimaryNumber = 0;

    private int hp = 3;

    public int Hp{
        get{
            return this.hp;
        }
    }

    public void DestroyPlayer(){
        this.hp--;
        if (this.hp <= 0){
            SetGameState(GameState.Fail);
            return;
        }
    }

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
            effecters[i] = Instantiate(effect, Vector3.zero, Quaternion.identity, effectSpawn.transform);

            effecters[i].SetActive(false);
            bullets[i].SetActive(false);
        }
    }

    private void FixedUpdate(){
        switch (gamestate){
            case GameState.Init:

                break;
            case GameState.Ready:
                
                break;
            case GameState.Play:
                PlayerMovementLogic();
                break;
            case GameState.Pause: 
            
                break;            
            case GameState.Fail:
                break;
        }
    }

    private void Update(){
        switch (gamestate){
            case GameState.Init:
                InitGame();
                break;
            case GameState.Ready:
                ReadyGame();
                break;
            case GameState.Play:
                PlayUI();
                break;
            case GameState.Pause:
                PauseGame();
                break;
            case GameState.Fail:
                FailGame();
                break;
        }

    }

    public void InitGame(){
        if (!readyUI.gameObject.activeSelf){
            readyUI.gameObject.SetActive(true);
        }
        scoreText.gameObject.SetActive(false);
        startBtn.enabled = true;
        startBtn.interactable = true;
        this.hp = 3;
        hpBar.minValue = 0;
        hpBar.maxValue = hp;
        hpBar.value = hp;
        
        InitScore();
        InitEffect();
        SetGameState(GameState.Ready);
    }

    public void ReadyGame() { 

    }

    public void PlayUI(){
        if (!scoreText.gameObject.activeSelf) scoreText.gameObject.SetActive(true);
        scoreText.text = $"Score : {score.ToString()}";

        hpBar.value = hp;
    }


    public void PlayerMovementLogic() {
        if (DIR == PLAYER_DIR.LEFT)
        {
            player.transform.position -= new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
        else if (DIR == PLAYER_DIR.RIGHT)
        {
            player.transform.position += new Vector3(speed * Time.fixedDeltaTime, 0, 0);
        }
    }

    public void PauseGame(){

    }

    public void FailGame(){
        if (!gameOverUI.gameObject.activeSelf){
            scoreText.gameObject.SetActive(false);
            gameOverUI.gameObject.SetActive(true);
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


    private float count = 2;
    public void StartGame() {
        startBtn.enabled = false;
        startBtn.interactable = false;
        startBtn.gameObject.SetActive(false);
        startDialog.gameObject.SetActive(false);
        StartCoroutine(StartCountCorutine());
        countText.gameObject.SetActive(true);
    }

    IEnumerator StartCountCorutine(){
        while (true){
            countText.text = count.ToString("0");

            if(count < 1){
                count = 5f;
                SetGameState(GameState.Play);
                readyUI.gameObject.SetActive(false);
                countText.gameObject.SetActive(false);
                break;
            }
            count -= 1;
            yield return new WaitForSeconds(1f);
        }
    }

    public void ShowEffect(Vector3 pos){
        if (effectIndex >= effecters.Length - 1) effectIndex = 0;
        effecters[effectIndex].transform.position = pos;
        effecters[effectIndex].gameObject.SetActive(true);
        effectIndex++;
    }

    public void InitEffect(){
        effectIndex = 0;
        for(int i = 0; i< 100; i++){
            effecters[i].gameObject.SetActive(false);
        }
    }



    public void LoadScore(){

    }

    public void InitScore(){
        score = 0;
    }


    public void IncreaseScore(){
        score += 100;
    }

    public void SaveScore(){

    }
}

