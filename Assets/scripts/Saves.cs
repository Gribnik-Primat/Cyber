using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class Saves : MonoBehaviour {

   /* public GameObject player;

    [System.Serializable]


    public void Position()
    { 
    public float x;
    public float y;
    public float z;
    }

    public void Save()
    {
    Position positionP= new Position();
    positionP.x = Player.transform.position.x;
    positionP.y = Player.transform.position.y;
    positionP.z = Player.transform.position.z;
    if (!Directory.Exists(Application.dataPath + "/saves"))
        Directory.CreateDirectory(Application.dataPath + "/saves");
    FileStream fs = new FileStream(Application.dataPath + "/saves/save.tr", FileMode.Create);
    BinaryFormatter formatter = new BinaryFormatter();
    formatter.Serialize(fs, Position);
    fs.Close();
    }

public void Load()
{
    if (File.Exists(Application.dataPath + "/saves/save.tr"))
    {
        FileStream fs = new FileStream(Application.dataPath + "/saves/save.tr", FileMode.Open);
        BinaryFormatter formatter = new BinaryFormatter();
        try
        {
            Position pos = (Position)formatter.Deserialize(fs);
            player.transform.position = new Vector3(pos.x, pos.y, pos.z);
        }
        catch (System.Exception e)
        {
            Debug.Log(e.Message);
        }
        finally
        {
            fs.Close();
        }
    } */
}
    
	
	

