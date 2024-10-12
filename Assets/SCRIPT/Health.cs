using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    [SerializeField] private float damageCooldown;
    [SerializeField] private AudioClip hurtSound;
    [SerializeField] private AudioClip DieSound;// Cooldown time before taking damage again

    public float currentHealth { get; private set; }

    private bool dead;
    private bool canTakeDamage = true;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(float _damage)
    {
        if (canTakeDamage)
        {

            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);


            if (currentHealth > 0)
            {
                Debug.Log("hurt");
                // Activate invincibility frames here if needed
                
                SoundManger.Instance.PlaySound(hurtSound);

            }
            else
            {
                if (!dead)
                {
                    SoundManger.Instance.PlaySound(DieSound);
                    GetComponent<PlayerMovs>().enabled = false;
                    dead = true;
                    SceneManager.LoadSceneAsync("LoseScene");
                }
            }
        }
    }

    IEnumerator TakeDamageAfterTimeCoroutine(float _damage, float _time)
    {
        yield return new WaitForSeconds(_time);
        TakeDamage(_damage);
    }

    public void TakeDamageAfterTime(float _damage, float _time)
    {
        StartCoroutine(TakeDamageAfterTimeCoroutine(_damage, _time));
    }
    public void StopTakeDamageAfterTime()
    {
        StopAllCoroutines();
    }

}
