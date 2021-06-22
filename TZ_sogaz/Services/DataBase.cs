using LiteDB;
using System;

namespace TZ_sogaz.Services
{
    public class DataBase
    {
        static private LiteDatabase db; //база данных
        static private ILiteCollection<UserInfo> col; //коллекция в базе данной
        static private string DataBaseName = "chat.db";

        public static UserInfo GetUserByUsername(string username)
        {
            DBConnect();

            UserInfo user = col.FindOne(user => user.Username == username);

            DBDispose();

            return user;
        }

        public static void UpdateUserMessages(UserInfo user)
        {
            DBConnect();

            user.countMessages++;
            col.Update(user);

            DBDispose();
        }

        public static void AddNewUser(UserInfo user)
        {
            DBConnect();

            col.Insert(user);

            DBDispose();
        }

        private static void DBConnect()
        {
            db = new LiteDatabase(DataBaseName);
            col = db.GetCollection<UserInfo>("usersInfo");
        }

        private static void DBDispose()
        {
            db.Dispose();
        }
    }
}
