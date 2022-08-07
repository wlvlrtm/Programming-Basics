using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class BestScore : MonoBehaviour
{
    private void Start() {
        if (File.Exists(UserInfoManager.path)) {
            PrintHighScore();
        }
        else {
            PrintDefaultScore();
        }
    }


    public void PrintHighScore() {
        gameObject.GetComponent<Text>().text = UserInfoManager.Instance.Get_highUser()  + " : " + UserInfoManager.Instance.Get_highScore();
    }


    public void PrintDefaultScore() {
        gameObject.GetComponent<Text>().text = "None : 0";
    }
}