using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;

public class ChangeColor : MonoBehaviour
{
    [SerializeField] private MeshRenderer _myMesh;
    [SerializeField] private Material _startMaterial;
    [SerializeField] private Material _endMaterial;
    [SerializeField] private XRController _left;
    [SerializeField] private XRController _right;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            Debug.Log("Зашел " + collision.gameObject.name);

            if(collision.collider.name == "L")
            {
                _left.SendHapticImpulse(0.2f, 0.3f);
            }
            else
            {
                _right.SendHapticImpulse(0.2f, 0.3f);
            }

            
            _myMesh.material = collision.gameObject.GetComponent<MeshRenderer>().material;
        }
    }

 /*   private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            Debug.Log("Вышел");
            _myMesh.material = _startMaterial;
        }
    }*/
}
