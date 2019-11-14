using System.Collections;
using UnityEngine;
using UnityEngine.Audio; //引用音頻API
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    //定義欄位(宣告變數)
    //類型 名稱 結尾
    //public 公開 、private 私人
    public AudioMixer mixer;
    public Text LoadingText;
    public Slider Loading;

    //定義方法 (宣告函式)
    //修飾詞 類型 名稱(參數){敘述}
    public void SetVBGM(float value)
    {
        mixer.SetFloat("VBGM", value);
    }
    public void SetVSFX(float value)
    {
        mixer.SetFloat("VSFX", value);
    }
    public void Play()
    {
        //SceneManager.LoadScene("場景");
        StartCoroutine(Loading1()); //啟動協同程序(協同程序方法名稱())
    }
    //協同程序Coroutine
    private IEnumerator Loading1()
    {
        //print("測試1");
        //yield return new WaitForSeconds(2); //等待秒數(秒數);
        //print("測試2");
        AsyncOperation ao = SceneManager.LoadSceneAsync("場景");  //取得場景資訊
        ao.allowSceneActivation = false;  //取消載入場景
        while (ao.isDone == false)
        {
            LoadingText.text = ((ao.progress / 0.9f) * 100).ToString(); //更新文字 = 載入.進度
            Loading.value = ao.progress / 0.9f;
            yield return new WaitForSeconds(0.01f);
            if ( ao.progress == 0.9f && Input.anyKey)
            {
                ao.allowSceneActivation = true;
            }
        }
    }
}
