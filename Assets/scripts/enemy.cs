using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] GameObject explosionvfx;
    [SerializeField] int hitpoints = 3;
    [SerializeField] int score = 5;
    Scoreboard scoreboard;
    void Start()
    {
        scoreboard = FindFirstObjectByType<Scoreboard>();
    }
    void OnParticleCollision(GameObject other)
    {
        hitpoints--;
        if (hitpoints <= 0)
        {
            scoreboard.IncreaseScore(score);
            Instantiate(explosionvfx, transform.position, Quaternion.identity);
            //Quaternion.identity means no rotation
            Destroy(gameObject);
        }
    }
}
