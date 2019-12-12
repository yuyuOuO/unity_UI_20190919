
using UnityEngine;
using UnityEngine.UI;

public class player : MonoBehaviour {
    public int hp = 100;
    public Slider hpSlider;

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject);
        if (other.tag == "陷阱")
        {
            int d = other.GetComponent<trap>().damage;
            hp -= d;
           hpSlider.value = hp;

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
}
