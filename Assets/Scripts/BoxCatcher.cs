using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.InputSystem;

public class BoxCatcher : MonoBehaviour
{

    [SerializeField] private Transform catchPoint;

    private Box _catchedBox;
    private Rigidbody _catchedBoxRb;
    
    private bool _isCatched = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (_isCatched)
        {
            CatchBox();
        }
        else
        {
            ReleaseBox();
        }
    }

    public void OnCatch(InputValue value)
    {
        _isCatched = value.isPressed;
    }

    void CatchBox()
    {
        var hits = Physics.SphereCastAll(transform.position, 0.08f, Vector3.forward);
        foreach (var hit in hits)
        {
            if (hit.transform.CompareTag("Box"))
            {
                Box box = hit.transform.GetComponent<Box>();
                _catchedBox = box;
                ParentConstraint pc = _catchedBox.AddComponent<ParentConstraint>();
                if (pc != null)
                {
                    pc.constraintActive = true;

                    ConstraintSource source = new ConstraintSource();
                    source.sourceTransform = catchPoint;
                    source.weight = 1;

                    pc.AddSource(source);
                }

                _catchedBox.GetComponent<Rigidbody>().isKinematic = true;
                
                return;

            }
        }

    }

    void ReleaseBox()
    {
        
        if (_catchedBox != null)
        {
            ParentConstraint pc = _catchedBox.GetComponent<ParentConstraint>();
            Destroy(pc);
            
            _catchedBox.GetComponent<Rigidbody>().isKinematic = false;
            _catchedBox = null;
            
        }

    }


}
