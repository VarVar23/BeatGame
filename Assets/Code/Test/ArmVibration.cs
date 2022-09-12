using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ArmVibration : MonoBehaviour
{
    [SerializeField] private XRController _left;
    [SerializeField] private XRController _right;
    private void OnCollisionStay(Collision collision)
    {
        if(collision.collider.CompareTag("Player") && collision.collider.name != gameObject.name)
        {
            _left.SendHapticImpulse(0.5f, 0.1f);
            _right.SendHapticImpulse(0.5f, 0.1f);
        }
    }
}
