using UnityEngine;

namespace DiepMono.Utils
{
    public static class Delay
    {
        public static WaitForSeconds TenSeconds = new WaitForSeconds(10f);
        public static WaitForSeconds FiveSeconds = new WaitForSeconds(5f);
        public static WaitForSeconds TwoSeconds = new WaitForSeconds(2f);
        public static WaitForSeconds OneSecond = new WaitForSeconds(1f);
        public static WaitForSeconds HalfSecond = new WaitForSeconds(0.5f);
        public static WaitForSeconds QuarterSecond = new WaitForSeconds(0.25f);
        public static WaitForSeconds CentiSecond = new WaitForSeconds(0.01f);
        public static WaitForSeconds MiliSecond = new WaitForSeconds(0.001f);
    } 
}
