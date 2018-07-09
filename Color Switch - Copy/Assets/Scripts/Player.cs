using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

    public float jumpForce = 7f;

    public Rigidbody2D rb;

    public SpriteRenderer sr;

    public string currentColor;

    public GameObject Green;

    public GameObject[] obj;

    public float SpawnAmount = 1f;

    public Color ColorBlue;
    public Color ColorPurple;
    public Color ColorYellow;
    public Color ColorPink;
    public int Score = 0;
    public int Height = 0;
    Vector3 CurrentSpawnPoint;
    private void Start()
    {
        SetRandomColor();
    }



    void Update() {

        if (Input.GetButtonDown("Jump") || Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector2.up * jumpForce;
        }

    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Change")
        {
            SetRandomColor();
            Destroy(col.gameObject);
            return;
        }
            
        if (col.tag == "Level")
        {
            Debug.Log("New Level");
            return;
        }

        else if (col.tag == "Point")
        {
            Debug.Log("Point gained");
            Destroy(col.gameObject);
            Score += 1;
            Height += 7;
            CurrentSpawnPoint = col.transform.position;
            CurrentSpawnPoint.y += 7;
            Instantiate(Green, CurrentSpawnPoint, Quaternion.identity);
            Instantiate(obj[Random.Range(0, obj.GetLength(0))], CurrentSpawnPoint, Quaternion.identity);
            Debug.Log(Height);
            Debug.Log(CurrentSpawnPoint);
            return;
        }

        else if (col.tag != currentColor)
        {
            Debug.Log("GAME OVER");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    void SetRandomColor()
    {
        int index = Random.Range(0, 4);

        switch (index)
        {
            case 0:
                currentColor = "Blue";
                sr.color = ColorBlue;
                break;
            case 1:
                currentColor = "Yellow";
                sr.color = ColorYellow;
                break;
            case 2:
                currentColor = "Purple";
                sr.color = ColorPurple;
                break;
            case 3:
                currentColor = "Pink";
                sr.color = ColorPink;
                break;
        }


    }
}
