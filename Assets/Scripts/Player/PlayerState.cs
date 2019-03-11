using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState {

    public bool dirLeft;
    public PlayerState lastPlayerState;

    public PlayerState()
    {
        dirLeft = false;
    }

    public virtual void StartAction(Player player)
    {

    }

    public virtual void EndAction(Player player)
    {

    }

	public virtual void Update (Player player)
    {

	}

    public virtual void InputHandle(Player player)
    {

    }
}
