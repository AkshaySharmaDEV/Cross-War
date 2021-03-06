using UnityEngine;


public class healthProperty : MonoBehaviour
{
    //This script will give object the health property attached to it
    public static healthProperty instance;
    public float Health, Damage;
    float newHealth;
    public string OncollisionWithTag;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {
        if (Health <= 0)
        {
            Health = newHealth;
        }
        else newHealth = Health;   
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag(OncollisionWithTag))
        {
            Health -= Damage;
        }


        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }

    }
}
