using UnityEngine;


public class ScreenBoundary : MonoBehaviour
{
    public Transform Player;
    public static float x, y;
    Camera cam;
    EdgeCollider2D edge;
    public float offset, xoffset;
    // Start is called before the first frame update
    void Awake()
    {
        cam = Camera.main;
        edge = GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Start()
    {
        FindBoundries();
        SetBoundaries();
    }
    private void LateUpdate()
    {
        transform.position = Player.position;
    }
    void SetBoundaries()
    {
        Vector2 pointa = new Vector2(x / 2 - xoffset, (y / 2) - offset);
        Vector2 pointb = new Vector2(x / 2 - xoffset, (-y / 2) + offset);
        Vector2 pointc = new Vector2(-x / 2 + xoffset, (-y / 2) + offset);
        Vector2 pointd = new Vector2(-x / 2 + xoffset, (y / 2) - offset);
        Vector2 pointe = new Vector2(x / 2 - xoffset, y / 2 - offset);
        Vector2[] Points = new Vector2[] { pointa, pointb, pointc, pointd, pointe };
        edge.points = Points;
    }
    void FindBoundries()
    {
        x = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).x - .5f);
        y = 1 / (cam.WorldToViewportPoint(new Vector3(1, 1, 0)).y - .5f);
    }
}