using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    Animator anim;

    enum EnemyState { stand, down}

    private EnemyState enemyState = EnemyState.stand;

    private float wakeDelay = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "WeaponPoint" && enemyState == EnemyState.stand);
        {
            anim.SetTrigger("die");
            enemyState = EnemyState.down;
            Die();
            Debug.Log("collide with " + col.gameObject.name);
        }
    }

    private void Die()
    {
        if(enemyState == EnemyState.down)
        {
            StartCoroutine("WakeUp");
        }
    }

    IEnumerator WakeUp()
    {
        yield return new WaitForSeconds (wakeDelay);
        anim.SetTrigger("up");
        enemyState = EnemyState.stand;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
