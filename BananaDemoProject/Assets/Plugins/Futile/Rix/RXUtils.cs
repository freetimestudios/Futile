using UnityEngine;
using System;


public class RXUtils
{
	public RXUtils ()
	{
		
	}
	
	public static Rect ExpandRect(Rect rect, float paddingX, float paddingY)
	{
		return new Rect(rect.x - paddingX, rect.y - paddingY, rect.width + paddingX*2, rect.height+paddingY*2);	
	}
	
	public static void LogVectors(string name, params Vector2[] args)
	{
		string result = name + ": " + args.Length + " Vector2 "+ args[0].ToString()+"";

		for(int a = 1; a<args.Length; a++)
		{
			Vector2 arg = args[a];
			result = result + ", "+ arg.ToString()+"";	
		}
		
		Debug.Log(result);
	}
	
	public static void LogVectors(string name, params Vector3[] args)
	{
		string result = name + ": " + args.Length + " Vector3 "+args[0].ToString()+"";

		for(int a = 1; a<args.Length; a++)
		{
			Vector3 arg = args[a];
			result = result + ", "+ arg.ToString()+"";	
		}
		
		Debug.Log(result);
	}
	
	public static void LogVectorsDetailed(string name, params Vector2[] args)
	{
		string result = name + ": " + args.Length + " Vector2 "+ VectorDetailedToString(args[0])+"";
		
		for(int a = 1; a<args.Length; a++)
		{
			Vector2 arg = args[a];
			result = result + ", "+ VectorDetailedToString(arg)+"";	
		}
		
		Debug.Log(result);
	}
	
	public static string VectorDetailedToString(Vector2 vector)
	{
		return "("+vector.x + "," + vector.y +")";
	}
	
	public static Color GetColorFromHex(uint hex)
	{
		uint red = hex >> 16;
		uint greenBlue = hex - (red<<16);
		uint green = greenBlue >> 8;
		uint blue = greenBlue - (green << 8);
		
		return new Color(red/255.0f, green/255.0f, blue/255.0f);
	}
	
}

public class RXMath
{
	public const float RTOD = 180.0f/Mathf.PI;
	public const float DTOR = Mathf.PI/180.0f;
	public const float DOUBLE_PI = Mathf.PI*2.0f;
	
	public static int Wrap(int input, int range)
	{
		return (input + (range*1000000)) % range;	
	}
	
	public static float Wrap(float input, float range)
	{
		return (input + (range*1000000)) % range;	
	}
	
	
	public static float getDegreeDelta(float startAngle, float endAngle) //shortRotation
	{
		float delta = (endAngle - startAngle) % 360.0f;
		
		if (delta != delta % 180.0f) 
		{
			delta = (delta < 0) ? delta + 360.0f : delta - 360.0f;
		}	
		
		return delta;
	}
	
	public static float getRadianDelta(float startAngle, float endAngle) //shortRotation
	{
		float delta = (endAngle - startAngle) % DOUBLE_PI;
		
		if (delta != delta % Mathf.PI) 
		{
			delta = (delta < 0) ? delta + DOUBLE_PI : delta - DOUBLE_PI;
		}	
		
		return delta;
	}
	
	//normalized ping pong
	public static float PingPong(float input, float range)
	{
		float first = ((input + (range*1000000.0f)) % range)/range; //0 to 1
		if(first < 0.5f) return first/0.5f;
		else return 1.0f - ((first - 0.5f)/0.5f); 
	}
	
}

public class RXRandom
{
	private static System.Random _randomSource = new System.Random();
	
	public static float Float()
	{
		return (float)_randomSource.NextDouble();
	}
	
	public static float Range(float low, float high)
	{
		return low + (high-low)*(float)_randomSource.NextDouble();
	}
}




//public static class ArrayExtensions
//{
//	public static string toJson( this Array obj )
//	{
//		return MiniJSON.jsonEncode( obj );
//	}
//	
//}
