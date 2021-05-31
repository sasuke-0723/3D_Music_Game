using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public static class JudgmentUtility
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="laneNum"> レーンの番号 </param>
    /// <returns></returns>
    //public static KeyCode GetKeyCodeByJudgmentLine(int laneNum)
    //{
    //    switch (laneNum)
    //    {
    //        case 0:
    //            return KeyCode.A;
    //        case 1:
    //            return KeyCode.D;
    //        case 2:
    //            return KeyCode.G;
    //        case 3:
    //            return KeyCode.J;
    //        case 4:
    //            return KeyCode.L;
    //        default:
    //            return KeyCode.None;
    //    }
    //}

    public static int GetLaneNumByKeyCode(KeyCode key)
    {
        switch (key)
        {
            case KeyCode.A:
                return 0;
            case KeyCode.D:
                return 1;
            case KeyCode.G:
                return 2;
            case KeyCode.J:
                return 3;
            case KeyCode.L:
                return 4;
            default:
                return int.MinValue;
        }
    }
}
