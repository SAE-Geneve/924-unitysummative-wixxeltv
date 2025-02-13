using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody rb = null;
    private bool goForeward = false;
    private bool isExit = false;
    [SerializeField]private float boxSpeed = 0.1f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (goForeward)
        {
            Vector3 initialForce;
            initialForce = isExit ? new Vector3(0,0,1) * boxSpeed : new Vector3(1,0,0) * boxSpeed;
            rb.AddForce(initialForce, ForceMode.Impulse);
        }
       
    }

    private void OnCollisionEnter(Collision coll)
    {
        goForeward = coll.gameObject.CompareTag("Conveyor") || coll.gameObject.CompareTag("ExitConveyor");
        isExit = coll.gameObject.CompareTag("ExitConveyor");
    }
}
