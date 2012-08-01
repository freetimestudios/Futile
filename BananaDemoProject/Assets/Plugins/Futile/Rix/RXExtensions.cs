using System;
using UnityEngine;

//
//public static class EventExtensions
//{
//    
//}

public static class ColorExtensions
{
	public static Color CloneWithNewAlpha(this Color color, float alpha)
	{
		return new Color(color.r, color.g, color.b, alpha);	
	}
	
	public static Color CloneWithMultipliedAlpha(this Color color, float alpha)
	{
		return new Color(color.r, color.g, color.b, color.a*alpha);	
	}
	
	//XT.To(target,0.5f).PropFloat("x",100.0f).OnComplete(OnCompleteHandler).Delay(0.5f).Start();
}

public static class RectExtensions
{
	public static Rect CloneWithExpansion(this Rect rect, float expansionAmount)
	{
		return new Rect(rect.x - expansionAmount, rect.y - expansionAmount, rect.width + expansionAmount*2, rect.height + expansionAmount*2);
	}
}

public static class GoKitExtensions
{
	//this makes it so we don't have to specify false for isRelative every.single.time.
	public static TweenConfig floatProp(this TweenConfig config, string propName, float propValue)
	{
		return config.floatProp(propName,propValue,false);
	}
}