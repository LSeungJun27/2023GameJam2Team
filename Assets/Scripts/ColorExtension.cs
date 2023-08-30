using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ColorExtension
{
    public static class ColorExtension
    {
        public static Color MixColor(Color x,Color y,float a)
        {
            return x * (1-a) + y*a;
        }

        public static Color PowColor(Color color, float p)
        {
            return new Color(Mathf.Pow(color.r,p),Mathf.Pow(color.g,p),Mathf.Pow(color.b,p));
        }
    }
}
