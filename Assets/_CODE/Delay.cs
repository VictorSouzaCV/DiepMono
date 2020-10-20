using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Delay
{
    public static WaitForSeconds twoSeconds = new WaitForSeconds(2f);
    public static WaitForSeconds oneSecond = new WaitForSeconds(1f);
    public static WaitForSeconds halfSecond = new WaitForSeconds(0.5f);
    public static WaitForSeconds quarterSecond = new WaitForSeconds(0.25f);
    public static WaitForSeconds centiSecond = new WaitForSeconds(0.01f);
    public static WaitForSeconds miliSecond = new WaitForSeconds(0.001f);
}
