using System;
using System.IO;
using UnityEngine;
using System.Collections;
//Written by M. Gibson Bethke
public class Manager : MonoBehaviour 
{

	public GUISkin guiSkin;
	
	string fileLocation = "File Location";
	byte [] originalBytes;
	byte [] newBytes;
	byte firstByte;
	byte lastByte;
	
	int index;
	
	
	void OnGUI ()
	{
		
		GUI.skin = guiSkin;
		
		fileLocation = GUI.TextField ( new Rect ( Screen.width / 2 - 200, Screen.height / 2 - 20, 400, 20 ), fileLocation.Trim ());
		
		if ( GUI.Button ( new Rect ( Screen.width / 2 - 200, Screen.height / 2 + 90, 400, 20 ), "ByteShift" ))
		{
			
			UnityEngine.Debug.Log ( "byteShift" );
			originalBytes = File.ReadAllBytes ( fileLocation );
			
			firstByte = originalBytes [0];
			lastByte = originalBytes [originalBytes.Length - 1];
			
			UnityEngine.Debug.Log ( "Original First Byte: " + firstByte + " Original Last Byte: " + lastByte );
			
			newBytes = new byte[originalBytes.Length];
			index = 0;
			
			while ( index < originalBytes.Length )
			{
				
				if ( index == 0 )
				{
					
					newBytes[0] = lastByte;
					index =+ 1;
				} else {
				
					newBytes[index] = ( originalBytes [index] );
					index += 1;
				
					if ( index == originalBytes.Length - 1  )
					{
					
						UnityEngine.Debug.Log ( "LastStep" );
						newBytes[index] = firstByte;
						
						index += 1;
					}
				}
			}
			
			if ( File.Exists ( fileLocation ))
				File.Delete ( fileLocation );
				
			File.WriteAllBytes ( fileLocation, newBytes );
			
			UnityEngine.Debug.Log ( "Your dastardly deed is done." );
		}
		
		if ( GUI.Button ( new Rect ( Screen.width / 2 - 200, Screen.height / 2 + 120, 400, 20 ), "RightShift" ))
		{
			
			UnityEngine.Debug.Log ( "rightShift" );
			originalBytes = File.ReadAllBytes ( fileLocation );
			
			firstByte = originalBytes [ originalBytes.Length - 1 ];
			lastByte = originalBytes [ 0 ];
			
			UnityEngine.Debug.Log ( "Original First Byte: " + firstByte + " Original Last Byte: " + lastByte );
			
			newBytes = new byte[originalBytes.Length];
			index = 0;
			
			while ( index < originalBytes.Length )
			{
				
				if ( index == 0 )
				{
					
					newBytes[0] = firstByte;
					index += 1;
				} else {
				
					newBytes[index] = ( originalBytes [index] );
					index += 1;
					
					if ( index == originalBytes.Length )
					{
						
						UnityEngine.Debug.Log ( "LastStep" );
						newBytes[originalBytes.Length - 1] = lastByte;
					}
				}
			}
			
			if ( File.Exists ( fileLocation ))
				File.Delete ( fileLocation );
				
			File.WriteAllBytes ( fileLocation, newBytes );
			
			UnityEngine.Debug.Log ( "I've undone your mistake." );
		}
	}
}