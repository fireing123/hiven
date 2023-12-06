using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameModeManger
{
    public static bool isCanPlayerMove = true;
    public static bool isCanPlayerJump = true;
    public static bool isPlayerRun = false;
    public static bool isCanPlayerAttack = false;

    public static void Running()
    {
        isCanPlayerMove = true;
        isPlayerRun = true;
    }

    public static void Moving()
    {
        isCanPlayerMove = true;
        isPlayerRun = false;
    }

    public static void Stop()
    {
        isCanPlayerMove = false;
        isPlayerRun = false;
    }

    public static void Jump(bool jump)
    {
        isCanPlayerJump = jump;
    }

    public static void Attack(bool attack)
    {
        isCanPlayerAttack = attack;
    }
}
