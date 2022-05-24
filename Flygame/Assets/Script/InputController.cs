using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour{
        /*
         * 사용자 입력총괄하는 클래스 (스크립트)
         * 
         */
        private void Update(){
            /*
             * 사용자입력,
             * 전체적인 게임 관리
             * UI 요소 스크립트
             * 
             */

            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                // 왼쪽으로 이동
                Logics.Instance.DIR = Logics.PLAYER_DIR.LEFT;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow)){
                Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
            }


            if (Input.GetKeyDown(KeyCode.RightArrow)){
                //오른쪽으로 이동
               Logics.Instance.DIR = Logics.PLAYER_DIR.RIGHT;
            }
            else if(Input.GetKeyUp(KeyCode.RightArrow)){
                Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
            }

            if (Input.GetKeyDown(KeyCode.Space)){
                // 공격을 할것.
                Logics.Instance.Fire();
            }

        }

    }
