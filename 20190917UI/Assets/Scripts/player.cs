
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


    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
           hpSlider.value = hp;

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
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
            hpSlider.value = hp;
        }
    }
    private void Start()
    {
        FoodTotal = GameObject.FindGameObjectsWithTag("FOOD").Length;
        textFood.text = "FOOD：0/" + FoodTotal;
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
}
