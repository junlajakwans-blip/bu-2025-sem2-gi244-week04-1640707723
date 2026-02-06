using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed ;
    public InputAction moveAction;
    public InputAction shootAction;
    public float xRange = 10.0f;
    public GameObject foodPrefab;

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        var hInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(hInput * speed * Time.deltaTime * Vector3.right);
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (shootAction.triggered)
        {
            Instantiate(foodPrefab, transform.position, Quaternion.identity);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizemos.DrawLinesphere(new Vector3(-xRange, transform.position.y, transform.position.z), 1);
        //Gizmos.Drawline(transform.position, Camera.main.transform.position););
        Gizmos.DrawLine(
            new Vector3(-xRange, transform.position.y, transform.position.z), new Vector3(-xRange, transform.position.y, transform.position.z));

    }
}
