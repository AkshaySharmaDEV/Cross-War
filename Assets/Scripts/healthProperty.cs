using UnityEngine;


public class healthProperty : MonoBehaviour
{
    //This script will give object the health property attached to it
    public static healthProperty instance;
    public float Health,Damage;

    private void Awake()
    {
        instance = this;
    }
    private void OnEnable()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "bullet":
                Health -= Damage;
                break;
                //Logic behind this case is that if you attach this script to enemies they'll take damage colliding with each other
            case "ememy":
                //Health -= Damage;
                break;

        }
        if (Health <= 0)
        {
            gameObject.SetActive(false);
        }

    }
}
