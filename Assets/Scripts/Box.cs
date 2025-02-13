using UnityEngine;

public class Box : MonoBehaviour
{
    private Rigidbody rb = null;
    private bool goForeward = false;
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
            //Debug.Log("YEAH");
            Vector3 initialForce = new Vector3(1,0,0) * boxSpeed;
           /* if (rb != null)
            {
                initialForce += rb.linearVelocity;
            }*/
            rb.AddForce(initialForce, ForceMode.Impulse);
        }
       
    }

    private void OnCollisionEnter(Collision coll)
    {
        //Debug.Log(coll.gameObject.name);
        if (coll.gameObject.CompareTag("Conveyor"))
        {
            goForeward = true;
        }
        else
        {
            goForeward = false;
        }
           
            
    }
}
