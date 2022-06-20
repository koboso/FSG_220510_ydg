using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour
{


    public void GoToHome(){
        SceneManager.LoadScene(0);
    }

    public void StartPlayGame(){
        SceneManager.LoadScene(1);
    }




}
