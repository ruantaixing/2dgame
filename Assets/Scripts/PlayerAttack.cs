using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] float attackCooldown;
    Animator ani;
    PlayerMove playerMove;
    float cooldownTimer = Mathf.Infinity; // vo cung



    private void Awake()
    {
        ani = GetComponent<Animator>();
        playerMove = GetComponent<PlayerMove>();
    }
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        if (Input.GetMouseButton(0) && cooldownTimer > attackCooldown && playerMove.canAttack())
        {
            attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    void attack()
    {
        ani.SetTrigger("attack");
        cooldownTimer = 0;

    }
}
