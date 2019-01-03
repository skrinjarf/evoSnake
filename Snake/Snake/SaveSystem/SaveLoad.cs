using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace SnakeGame.SaveSystem
{
    public static class SaveLoad
    {
        public static void Save ()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream("config.snake", FileMode.Create);
            GameData data = new GameData(Configerator.instance);
            bf.Serialize(stream, data);
            stream.Close();
        }

        public static GameData Load ()
        {
            if (File.Exists("config.snake"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream stream = new FileStream("config.snake", FileMode.Open);
                GameData data = bf.Deserialize(stream) as GameData;
                stream.Close();
                return data;
            }
            else
            {
                return new GameData();
            }
        }
    }
}
