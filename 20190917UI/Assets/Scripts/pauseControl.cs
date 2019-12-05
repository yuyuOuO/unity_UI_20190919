using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseControl : MonoBehaviour
{
    [Header("暫停介面")]
    public Image imagePause;
    public Sprite spritePause, spritePlay;
    [Header("暫停")]
    public bool pause;

    private void Pause()
    {
        //如果 按下ESC就執行{}
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            print("暫停~");
            //相反 :將布林值改為相反
            pause = !pause;

            //條件運算子
            //布林值 ?結果一：結果二
            //布林值 true 會執行結果一
            //布林值 salse 會執行結果二

            imagePause.sprite = pause ? spritePlay : spritePause;

            Time.timeScale = pause ? 0 : 1;
        }
        
    }

    //更新:一秒執行約60次
    private void Update()
    {
        Pause();
    }
}
