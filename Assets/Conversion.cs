//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using UnityEngine;



	public class Conversion
	{


		public Conversion ()
		{
		//ssssss
			
		}

		public static Vector3 makeFixedPoint(Vector3 screenPoint){
			float workWidth = 18;
			float workHeight = 8;
			Convert factor = new Convert (Screen.height / 2, Screen.width / 2);
			float xWorkDist = screenPoint.x;

			float xRatio =  1 - xWorkDist / workWidth;
			Debug.Log (xRatio);
			float xFixed = factor.camWidth - xRatio * factor.camWidth;

			float yWorkDist =screenPoint.y;
			float yRatio = 1-yWorkDist / workHeight;
			float yFixed = factor.camHeight - yRatio * factor.camHeight;

			Vector3 fixedPoint = new Vector3 (xFixed, yFixed, 0);
			return fixedPoint;
		
		}
	}


