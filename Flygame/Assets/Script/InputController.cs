using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour{
        /*
         * ����� �Է��Ѱ��ϴ� Ŭ���� (��ũ��Ʈ)
         * 
         */
        private void Update(){
            /*
             * ������Է�,
             * ��ü���� ���� ����
             * UI ��� ��ũ��Ʈ
             * 
             */

            if (Input.GetKeyDown(KeyCode.LeftArrow)) {
                // �������� �̵�
                Logics.Instance.DIR = Logics.PLAYER_DIR.LEFT;
            }
            else if (Input.GetKeyUp(KeyCode.LeftArrow)){
                Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
            }


            if (Input.GetKeyDown(KeyCode.RightArrow)){
                //���������� �̵�
               Logics.Instance.DIR = Logics.PLAYER_DIR.RIGHT;
            }
            else if(Input.GetKeyUp(KeyCode.RightArrow)){
                Logics.Instance.DIR = Logics.PLAYER_DIR.NONE;
            }
        }

    }
