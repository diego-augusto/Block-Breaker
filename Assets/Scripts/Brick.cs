using UnityEngine;

public class Brick : MonoBehaviour
{
    private LevelManager levelManager;
    private int timesHit;
    private bool isBreakable;

    public static int breakableCount = 0;
    public AudioClip crack;


    public Sprite[] hitSprites;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
        timesHit = 0;

        isBreakable = tag.Equals("Breakable");
        if (isBreakable)
        {
            breakableCount++;
            Debug.Log(breakableCount);
        }
    }

    void Update()
    {

    }

    void OnCollisionExit2D(Collision2D collision)
    {
        AudioSource.PlayClipAtPoint(crack, transform.position);
        if (isBreakable)
        {
            HandleHits();
        }
    }

    private void HandleHits()
    {
        timesHit++;

        if (timesHit >= hitSprites.Length + 1)
        {
            Destroy(gameObject);
            breakableCount--;
            if(breakableCount <= 0)
            {
                levelManager.LoadNextLevel();
            }
            Debug.Log(breakableCount);
        }
        else
        {
            LoadSprites();
        }
    }

    private void LoadSprites()
    {
        int spriteIndex = timesHit - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void SimulateWin()
    {
        levelManager.LoadNextLevel();
    }
}
