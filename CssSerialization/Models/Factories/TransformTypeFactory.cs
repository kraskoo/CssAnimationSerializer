namespace Models.Factories
{
    using System;
    using Enums;

    public class TransformTypeFactory
    {
        public static string GetTransformCssString(TransformType transform)
        {
            switch (transform)
            {
                case TransformType.Perspective:
                    return "perspective";
                case TransformType.Rotate:
                    return "rotate";
                case TransformType.Rotate3d:
                    return "rotate3d";
                case TransformType.RotateX:
                    return "rotateX";
                case TransformType.RotateY:
                    return "rotateY";
                case TransformType.RotateZ:
                    return "rotateZ";
                case TransformType.Scale:
                    return "scale";
                case TransformType.Scale3d:
                    return "scale3d";
                case TransformType.ScaleX:
                    return "scaleX";
                case TransformType.ScaleY:
                    return "scaleY";
                case TransformType.ScaleZ:
                    return "scaleZ";
                case TransformType.Translate:
                    return "translate";
                case TransformType.Translate3d:
                    return "translate3d";
                case TransformType.TranslateX:
                    return "translateX";
                case TransformType.TranslateY:
                    return "translateY";
                case TransformType.TranslateZ:
                    return "translateZ";
                case TransformType.Skew:
                    return "skew";
                case TransformType.SkewX:
                    return "skewX";
                case TransformType.SkewY:
                    return "skewY";
                default:
                    throw new ArgumentException("Unknown transform type.");
            }
        }
    }
}