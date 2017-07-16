using UnityEngine;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class Sending : MonoBehaviour{

	//public static SerialPort sp = new SerialPort("COM4",9600,Parity.
	public static SerialPort sp = new SerialPort("/dev/cu.usbmodem1421",9600);
	public string message2;
	float timePassed = 0.0f;
	//Use this for initialization

	void Start()
	{
		OpenConnection();
	}

	//Update is called once per frame
	void Update(){
		//timePassed+= Time.deltaTime;
		//if(timePassed)=0.2f){

		//print("BytesToRead" +sp.BytesToRead);
		message2 = sp.ReadLine ();
		print (message2);
		///timePassed = 0.0f;
		//}
	}

	public void OpenConnection()
	{
		if(sp != null)
		{
			if (sp.IsOpen) {
				sp.Close ();
				print ("Closing port, because it was already open!");
			} else {
				sp.Open ();//open the connection
				sp.ReadTimeout = 16;
				print ("Port Opened!");
				//message = "Port Opened";
			}
		}
		else 
		{
			if (sp.IsOpen)
			{
				print ("Port is already open");
			}
			else
			{
				print ("Port == null");
			}
		}
	}

	void OnApplicationQuit()
	{
		sp.Close();
	}

	public static void sendYellow(){
		sp.Write ("y");
	}

	public static void sendGreen(){
		sp.Write("g");
	}

	public static void sendRed(){
		sp.Write("r");
	}
		}

