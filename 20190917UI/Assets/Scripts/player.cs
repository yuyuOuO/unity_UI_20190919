
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {

    [Header("血量血條")]
    public int hp = 100;
    public Slider hpSlider;
    [Header("食物")]
    public Text textFood;
    public int FoodCount;
    public int FoodTotal;
    [Header("時間區域")]
    public Text textTime;
    public float gameTime;
    [Header("結束畫布")]
    public GameObject final;
    public Text textBest;
    public Text textCurrent;
        


    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
           hpSlider.value = hp;
            if (hp <= 0) Dead();

        }
        if (other.tag == "FOOD")
        {
            FoodCount++;
            textFood.text = "FOOD：" + FoodCount + "/" + FoodTotal;
            Destroy(other.gameObject);
        }
        if(other.name == "終點"&& FoodCount == FoodTotal)
        {
            print("過關");
        }
        if(other.name == "終點"&& FoodCount == FoodTotal)
        {
            GameOver();
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            hpSlider.value = hp;
            if (hp <= 0) Dead();
        }
    }
    private void Start()
    {
        FoodTotal = GameObject.FindGameObjectsWithTag("FOOD").Length;
        textFood.text = "FOOD：0/" + FoodTotal;

        if (PlayerPrefs.GetFloat("最佳紀錄") == 0)
        {
            PlayerPrefs.SetFloat("最佳紀錄", 99999);
        }
    }
    private void Update()
    {
        UpdateTime();
    }
    private void UpdateTime()
    {
        gameTime += Time.deltaTime;
        textTime.text = gameTime.ToString("0.00");
    }
    private void Dead()
    {
        final.SetActive(true);
        textCurrent.text = "TIME:" + gameTime.ToString("0.00");
        textBest.text = "BEST : " + PlayerPrefs.GetFloat("最佳紀錄").ToString("0.00");
        Cursor.lockState = CursorLockMode.None;
        GetComponent<FPSControllerLPFP.FpsControllerLPFP>().enabled = false;
        this.enabled = false;
    }
    private void GameOver()
    {
        final.SetActive(true);
        textCurrent.text = "TIME:" + gameTime.ToString("0.00");
        if (gameTime < PlayerPrefs.GetFloat("最佳紀錄"))
        {
            PlayerPrefs.SetFloat("最佳紀錄", gameTime);
        }
         textBest.text = "BEST : "+PlayerPrefs.GetFloat("最佳紀錄").ToString("0.00") ;

        Cursor.lockState = CursorLockMode.None;
    }
}
