using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : PlayerState {

    //public PlayerState lastPlayerState;
    private float energy;
    private float energyAcce;
    private float rate;
    private float maxEnergy;
    Transform barWhite;
    Transform barYellow;

    public override void StartAction(Player player)
    {
        //base.StartAction(player);
        energy = 0f;
        energyAcce = 2f;
        maxEnergy = 100f;

        barWhite = player.transform.Find("EnergyBarWhite");
        barYellow = barWhite.transform.Find("EnergyBarYellow");

        barWhite.gameObject.SetActive(true);
        barYellow.gameObject.SetActive(true);

        float y = player.GetComponent<SpriteRenderer>().size.y / 2;
        barWhite.transform.position = player.transform.position + new Vector3(0, y + 0.1f, 0);
    }

    public override void EndAction(Player player)
    {
        //base.EndAction(player);

        barWhite.gameObject.SetActive(false);
        barYellow.transform.localScale = new Vector3(0, 0, 0);
        barYellow.gameObject.SetActive(false);
    }

    public override void Update(Player player)
    {
        //base.Update(player);

        InputHandle(player);
    }

    public override void InputHandle(Player player)
    {
        //base.InputHandle(player);

        if (Input.GetKey(KeyCode.Space)) 
        {
            energy += energyAcce;

            if(energy >= maxEnergy)
            {
                energy = maxEnergy;
            }

            rate = energy / maxEnergy;
            Debug.Log(rate);
            barYellow.transform.localScale = new Vector3(rate, 1f, 1f);

            //Debug.Log(energy);
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            float maxScale = 1.5f;
            float minScale = 0.3f;
            float maxRange = 10f;
            float minRange = 5f;

            float scale = minScale + rate * (maxScale - minScale);
            float range = minRange + rate * (maxRange - minRange);

            player.GetComponent<PlayerAttack>().Attack(scale, player, range);

            energy = 0f;

            EndAction(player);
            player.playerState = lastPlayerState;
        }
    }

}
