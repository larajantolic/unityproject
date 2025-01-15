using UnityEngine;

public class EnemyMovementBasic : MonoBehaviour
{
    [Header("Movement Settings")]
    public Transform player; 
    public float speed = 3.5f; // Speed of the enemy

    [Header("Animation Settings")]
    public Animator animator; 

    void Update()
    {
        if (player != null)
        {
            // Move towards the player
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // Rotate to face the player
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            // Trigger walk animation 
            if (animator != null)
            {
                animator.SetBool("IsWalking", true); // 
            }
        }
    }
}
