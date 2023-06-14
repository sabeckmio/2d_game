using UnityEngine;
using System.Collections;

public class enemy : MonoBehaviour
{
    [SerializeField] float m_movementInterval = 2.0f;
    [SerializeField] float m_attackInterval = 3.0f;
    [SerializeField] float m_attackRange = 2.0f;
    [SerializeField] float m_speed = 5.0f; // Adjust the value as per your desired speed

    private HeroKnight m_heroKnight;
    private Animator m_animator;
    private Rigidbody2D m_body2d;
    private GameObject m_character;
    private bool m_grounded = false; // Added grounded variable
    public int attackDamage = 10;
    public int health = 100;

    private void OnTriggerEnter2D(Collider2D collision)
{
    // Check if the enemy collides with the player
    if (collision.CompareTag("Player"))
    {
        // Get the HeroKnight component from the player object
        HeroKnight player = collision.GetComponent<HeroKnight>();

        // Call the TakeDamage() method of the player
        if (player != null)
        {
            player.TakeDamage(attackDamage);
        }

        // Enemy takes damage from player's attack
        TakeDamage(player.TakeDamage(attackDamage));
    }
}

    // Use this for initialization
   void Start()
{
    m_animator = GetComponent<Animator>();
    m_body2d = GetComponent<Rigidbody2D>();
    m_character = GameObject.FindWithTag("Player");
    m_heroKnight = m_character.GetComponent<HeroKnight>();
    StartCoroutine(EnemyActions());
}


    IEnumerator EnemyActions()
    {
        while (true)
        {
            yield return new WaitForSeconds(m_movementInterval);

            
            MoveTowardsCharacter();

            yield return new WaitForSeconds(m_attackInterval);

            
            if (IsCharacterWithinAttackRange())
            {
                AttackCharacter();
            }
        }
    }

    void MoveTowardsCharacter()
    {
        Vector3 direction = (m_character.transform.position - transform.position).normalized;
        m_body2d.velocity = direction * m_speed;
        m_grounded = true;
        m_animator.SetBool("Grounded", m_grounded);
    }

    void StopMoving()
    {
        m_body2d.velocity = Vector2.zero;
        m_grounded = false;
        m_animator.SetBool("Grounded", m_grounded);
    }

    bool IsCharacterWithinAttackRange()
    {
        return Vector2.Distance(transform.position, m_character.transform.position) <= m_attackRange;
    }

    void AttackCharacter()
    {
        // Play attack animation
        m_animator.SetTrigger("Attack");

        // Deal damage to the character
        if (m_heroKnight != null)
        {
            m_heroKnight.TakeDamage(attackDamage);
        }
    }

    public void TakeDamage(int damage)
{
    health -= damage;
    if (health <= 0)
    {
        // Enemy is dead
        Die();
        StartCoroutine(DisappearAfterDelay(2f)); 
    }
    else if (health > 0)
    {
        // Enemy is hurt but still alive
        m_animator.SetTrigger("Hurt");
    }
}

private IEnumerator DisappearAfterDelay(float delay)
{
    yield return new WaitForSeconds(delay); // Wait for the specified delay
    gameObject.SetActive(false); // Deactivate the enemy object
}


    void Die()
    {
        // Play death animation
        m_animator.SetTrigger("Death");

        // Disable enemy behavior
        StopMoving();
        enabled = false;
    }
}
