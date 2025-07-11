using UnityEngine;

public class collisionhandler : MonoBehaviour
{
    [SerializeField] GameObject playerexplosionvfx;
    Gamescenemanager gamescenemanager;
    void Start()
    {
        gamescenemanager=FindFirstObjectByType<Gamescenemanager>();
    }
    void OnTriggerEnter(Collider other)
    {
        gamescenemanager.Reloadlevel();
        Instantiate(playerexplosionvfx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
