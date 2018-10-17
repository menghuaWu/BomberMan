using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour {

	public static IMovemen Movemen(string name)
    {
        switch (name)
        {
            case "Player1":
                return new Player1();
            case "Player2":
                return new Player2();
            default:
                return null;
        }
    }
}
