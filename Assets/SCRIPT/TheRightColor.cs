using System.Collections;
using UnityEngine;

public class TheRightColor : MonoBehaviour
{
    private bool correct;
    public ColorChanging colorChanging;
    [SerializeField] private float damage;
    public Health health;
    private string lastcoll;
    private int test;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ceiling"))
        {
            test = 0;
            health.StopTakeDamageAfterTime();
            /*if (colorChanging.spriteRenderer.color != colorChanging.blueColor)
            {

                health.TakeDamageAfterTime(damage, 2);
            }*/

        }


        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("ground");
            /* if (colorChanging.spriteRenderer.color != colorChanging.normalColor)
             {
                 health.TakeDamageAfterTime(damage, 2);
             }*/
            test = 1;
            health.StopTakeDamageAfterTime();
        }

        if (collision.gameObject.CompareTag("Fire"))
        {
            /*if (colorChanging.spriteRenderer.color != colorChanging.redColor)
            {
                health.TakeDamageAfterTime(damage,2);
            }*/
            test = 2;
            health.StopTakeDamageAfterTime();

        }
      
    }
    private void Start()
    {
        StartCoroutine(Checking());
    }

    IEnumerator Checking()
    {
        while (health.currentHealth > 0) {
            yield return new WaitForSeconds(1);
            if (test== 0 && colorChanging.spriteRenderer.color != colorChanging.blueColor)
            {
                health.TakeDamageAfterTime(damage,1.5f);
                Debug.Log("test 0 ");
            }
            else if (test == 1 && colorChanging.spriteRenderer.color != colorChanging.normalColor)
            {
                health.TakeDamageAfterTime(damage, 1.5f);
                Debug.Log("test 1 ");
            }
            else if (test == 2 && colorChanging.spriteRenderer.color != colorChanging.redColor)
            {
                health.TakeDamageAfterTime(damage, 1.5f);
                Debug.Log("test 2 ");
            }
            else
            {
                Debug.Log("test 3 ");
            }


        }
    }
}
