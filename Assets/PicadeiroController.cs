using UnityEngine;

public class PicadeiroController : MonoBehaviour
{
    public float radius;
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
