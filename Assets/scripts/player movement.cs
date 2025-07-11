using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    [SerializeField] float controlspeed = 10f;
    [SerializeField] float zclamped = 50f;
    [SerializeField] float yclamped = 5f;

    [SerializeField] float rotationxangle = 25f;
    [SerializeField] float rotationxspeed = 5f;
    [SerializeField] float rotationzangle = 25f;
    [SerializeField] float rotationzspeed = 10f;
    Vector2 movementInput;
    void Update()
    {
        processtranslation();
        processrotation();
    }



    public void OnMove(InputValue value)
    {
        movementInput = value.Get<Vector2>();
    }
    private void processtranslation()
    {
        float zoffset = movementInput.x * controlspeed * Time.deltaTime;
        //if A and D are pressed, vector 2 will return (1,0) or (-1,0) multiply with controlspeed and delta time to get the offset
        float rawzpos = transform.localPosition.z + zoffset;
        float clampedzpos = Mathf.Clamp(rawzpos, -zclamped, zclamped);
        //to clamp the player so that it does not go out of bounds
        float yoffset = movementInput.y * controlspeed * Time.deltaTime;
        float rawypos = transform.localPosition.y + yoffset;
        float clampedypos = Mathf.Clamp(rawypos, -yclamped, yclamped);
        transform.localPosition = new Vector3(0f, clampedypos, clampedzpos);
    }
    private void processrotation()
    {
        Quaternion targetxRotation = Quaternion.Euler(movementInput.x * rotationxangle, 0f, 0f);
        //to rotate the player based on the input, if A is pressed, it will rotate left, if D is pressed, it will rotate right
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetxRotation, Time.deltaTime * rotationxspeed);
        Quaternion targetzRotation = Quaternion.Euler(0f, 0f, movementInput.y * rotationzangle);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetzRotation, Time.deltaTime * rotationzspeed);
    }
    
}