using UnityEngine;
using System.Collections;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public class Saves : MonoBehaviour
{

    public GameObject Player;
    public bool s = false;
    [System.Serializable]
   

    public class Position
    {
        public float x;
        public float y;
        public float z;
    }

    public void Save()//TODO: понять откуда берутся первые значения позиции при запуске
    {
        if (s)
        {
            Position positionP = new Position();
            positionP.x = Player.transform.position.x;
            positionP.y = Player.transform.position.y;
            positionP.z = Player.transform.position.z;
            if (!Directory.Exists(Application.dataPath + "/saves"))
                Directory.CreateDirectory(Application.dataPath + "/saves");
            FileStream fs = new FileStream(Application.dataPath + "/saves/save.sv", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, positionP);
            fs.Close();
        }
    }
    public void Save(Vector3 pos)
    {
        if (s)
        {
            Position positionP = new Position();
            positionP.x = pos.x;
            positionP.y = pos.y;
            positionP.z = pos.z;
            if (!Directory.Exists(Application.dataPath + "/saves"))
                Directory.CreateDirectory(Application.dataPath + "/saves");
            FileStream fs = new FileStream(Application.dataPath + "/saves/save.sv", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(fs, positionP);
            fs.Close();
        }
    }

    public void Load()
    {
        if (s == true)
        {
            if (File.Exists(Application.dataPath + "/saves/save.sv"))
            {
                FileStream fs = new FileStream(Application.dataPath + "/saves/save.sv", FileMode.Open);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    Position pos = (Position)formatter.Deserialize(fs);
                    Player.transform.Translate((GameObject.FindGameObjectWithTag("TriggerSave").transform.position));//нужно помедитировать и понять почему игрок не хочет телепортироваться(необходимость в какой-нибудь функции update???)
                }
                catch (System.Exception e)
                {
                    Debug.Log(e.Message);
                }
                finally
                {
                    s = false;
                    fs.Close();
                }
            }
        }
    }
}

