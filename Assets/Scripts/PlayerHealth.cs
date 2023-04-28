using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public Image healthBar;
    public float playerHealth;
    public float currentHealth;
    public PlayerController player;
    public CinemachineVirtualCamera cam;
    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = playerHealth;
    }


    private void Update()
    {
        if (gameObject.transform.position.y < -10)
            KillBox();
    }


    public void TakeDamage(float damage)
    {

        currentHealth -= damage;
        healthBar.fillAmount = currentHealth / playerHealth;
        if(currentHealth <= 0)
        {
            cam.enabled = false;
            player.gameOver = true;
            player.playerDead();
            StartCoroutine(TransitionOut());
        }

    }

   void KillBox()
    {
        TakeDamage(currentHealth);
    }

    IEnumerator TransitionOut()
    {
        yield return new WaitForSeconds(3.0f);
        anim.SetTrigger("GameOver");

        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
