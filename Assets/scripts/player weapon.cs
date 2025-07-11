
using UnityEngine;
using UnityEngine.InputSystem;

public class playerweapon : MonoBehaviour
{
    bool isFiring = false;
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetpoint;
    [SerializeField] float targetdistance = 10f;
    private void Start()
    {
        Cursor.visible = false;
    }
    void Update()
    {
        processfire();
        movecrosshair();
        movetargetpoint();
        aimlasers();
    }
    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void processfire()
    {
        foreach (var laser in lasers)
        {
            var emissionmodule = laser.GetComponent<ParticleSystem>().emission;
            emissionmodule.enabled = isFiring;
        }
    }
    void movecrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    void movetargetpoint()
    {
        Vector3 targetpointposition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, targetdistance);
        targetpoint.position = Camera.main.ScreenToWorldPoint(targetpointposition);// Convert screen position to world position
    }
    void aimlasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 firedirection = targetpoint.position - this.transform.position;// Calculate the direction from the laser to the target point
            Quaternion rotation = Quaternion.LookRotation(firedirection);   // Create a rotation that points the laser towards the target point
            laser.transform.rotation = rotation; // Apply the rotation to the laser
        }
        
    }
}

