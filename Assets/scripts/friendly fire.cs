
using UnityEngine;

public class friendlyfire : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] GameObject targetobject;
    MeshRenderer meshrenderer;
    private void Start()
    {
        foreach (var laser in lasers)
        {
            var emissionmodule = laser.GetComponent<ParticleSystem>().emission;
            emissionmodule.enabled = false;
        }
        meshrenderer = targetobject.GetComponent<MeshRenderer>();
        Invoke("enablemesh", 9.5f);

    }
    
    void enablemesh()
    {
        meshrenderer.enabled = true;
        startshoot();
    }
    void startshoot()
    {
        foreach (var laser in lasers)
        {
            var emissionmodule = laser.GetComponent<ParticleSystem>().emission;
            emissionmodule.enabled = true;
        }
        Invoke("stopshoot", 1.5f);
    }
    void stopshoot()
    {
        foreach (var laser in lasers)
        {
            var emissionmodule = laser.GetComponent<ParticleSystem>().emission;
            emissionmodule.enabled = false;
        }
    }
}
