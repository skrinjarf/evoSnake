﻿using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using SnakeGame.Entities;

namespace SnakeGame.SaveSystem
{
    public static class SaveLoad
    {
        public static void Save ()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.LocalUserAppDataPath + "\\config.snake", FileMode.Create);
            GameData data = new GameData(Configerator.instance);
            bf.Serialize(stream, data);
            stream.Close();
        }

        public static GameData Load ()
        {
            if (File.Exists(Application.LocalUserAppDataPath + "\\config.snake"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream stream = new FileStream(Application.LocalUserAppDataPath + "\\config.snake", FileMode.Open);
                GameData data = bf.Deserialize(stream) as GameData;
                stream.Close();
                return data;
            }
            else
            {
                return new GameData();
            }
        }

        public static void SaveSnakeBot(BotSnake snake)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.LocalUserAppDataPath + "\\config.snakeBotData", FileMode.Create);
            SnakeBotData data = new SnakeBotData(snake);
            bf.Serialize(stream, data);
            stream.Close();
        }

        public static SnakeBotData LoadSnakeBot()
        {
            if (File.Exists(Application.LocalUserAppDataPath + "\\config.snakeBotData"))
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream stream = new FileStream(Application.LocalUserAppDataPath + "\\config.snakeBotData", FileMode.Open);
                SnakeBotData data = bf.Deserialize(stream) as SnakeBotData;
                stream.Close();
                return data;
            }
            else
            {
                return new SnakeBotData();
            }
        }
    }
}
