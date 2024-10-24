using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class DragRotate : MonoBehaviour
{

    [SerializeField] float rotationSpeed = 1f; // Speed of rotation
    [SerializeField] float maxAngle = 45f;  // Maximum rotation angle


    [SerializeField] Transform inputObject;

    public float rotationAmount;


    [Tooltip("input object will only rotate on selected Axis from the following checks")]
    [SerializeField] bool rotate_x = true;
    [SerializeField] bool rotate_y = false;
    [SerializeField] bool rotate_z = false;

    [Tooltip("input will only consider when swipe Vertically")]
    [SerializeField] bool verticalSwipe = true;

    [Tooltip("input will only consider when swipe Horizonatly")]
    [SerializeField] bool horizontalSwipe = false;

    [Tooltip("check the box will automatically back the input to 0 when button released")]
    [SerializeField] bool backOnMouseUp = false;


    private void Start()
    {
        if (!inputObject)
            inputObject = this.gameObject.transform;

        inputObject.localEulerAngles = new Vector3(maxAngle * rotationAmount, inputObject.localEulerAngles.y, inputObject.localEulerAngles.z);
    }

    private void OnMouseDrag()
    {

        if (verticalSwipe)
            rotationAmount += Input.GetAxis("Mouse Y") * rotationSpeed;
        if (horizontalSwipe)
            rotationAmount += Input.GetAxis("Mouse X") * rotationSpeed;

        rotationAmount = Mathf.Clamp(rotationAmount, -1, 1);

        if (rotate_x)
            inputObject.localEulerAngles = new Vector3(maxAngle * rotationAmount, inputObject.localEulerAngles.y, inputObject.localEulerAngles.z);
        if (rotate_y)
            inputObject.localEulerAngles = new Vector3(inputObject.localEulerAngles.x, maxAngle * rotationAmount, inputObject.localEulerAngles.z);
        if (rotate_z)
            inputObject.localEulerAngles = new Vector3(inputObject.localEulerAngles.x, inputObject.localEulerAngles.z, maxAngle * rotationAmount);


    }

    private void OnMouseUp()
    {
        onMouseUp.Invoke();
        if (!backOnMouseUp)
            return;

        DOTween.To(() => rotationAmount, x => rotationAmount = x, 0f, 0.25f).OnUpdate(
            () => {

                if (rotate_x)
                    inputObject.localEulerAngles = new Vector3(maxAngle * rotationAmount, inputObject.localEulerAngles.y, inputObject.localEulerAngles.z);
                if (rotate_y)
                    inputObject.localEulerAngles = new Vector3(inputObject.localEulerAngles.x, maxAngle * rotationAmount, inputObject.localEulerAngles.z);
                if (rotate_z)
                    inputObject.localEulerAngles = new Vector3(inputObject.localEulerAngles.x, inputObject.localEulerAngles.z, maxAngle * rotationAmount);
            });
    }

    [SerializeField] UnityEvent onMouseDown,onMouseUp = new UnityEvent();
    private void OnMouseDown()
    {
        onMouseDown.Invoke();
    }
  public void SetRotationX(float angle)
    {
        inputObject.localEulerAngles = new Vector3(angle, inputObject.localEulerAngles.y, inputObject.localEulerAngles.z);
    }
    public void SetRotationY(float angle)
    {
        inputObject.localEulerAngles = new Vector3( inputObject.localEulerAngles.x, angle, inputObject.localEulerAngles.z);
    }
    public void SetRotationZ(float angle)
    {
        inputObject.localEulerAngles = new Vector3(inputObject.localEulerAngles.x, inputObject.localEulerAngles.y, angle);
    }
}
