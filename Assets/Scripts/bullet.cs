using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // ลบสัตว์ (ถ้าต้องการ)
            Destroy(gameObject);       // ลบอาหาร/กระสุน
        }
    }
}
