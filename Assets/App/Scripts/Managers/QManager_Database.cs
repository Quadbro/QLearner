

using System;
using iBoxDB.LocalServer;
using UnityEngine;

public class QManager_Database : QManager<QManager_Database> {

    public AutoBox auto = null;

    protected override void OnAwake() {

        /*
        var dirPath = Application.streamingAssetsPath + "/Data";

        Directory.CreateDirectory(dirPath);

        string conn = "URI=file:" + dirPath  + "/database.db"; //Path to database.
        var dbconn = (IDbConnection)new SqliteConnection(conn); ;
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * FROM Users";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read()) {
            var id = reader.GetInt32(0);
            var username = reader["username"];
            var password = reader["password"];

            Debug.Log("id= " + id + "  username =" + username + "  password =" + password);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;*/
        /*

        // Open database (or create if doesn't exist)
        using (var db = new LiteDatabase(@"Database.db")) {
            // Get customer collection
            var col = db.GetCollection<User>("users");

            // Create your new customer instance
            var user = new User {
                Name = "Mike",
                Username = "Quadbro",
                Password = "1234",
            };

            // Create unique index in Name field
            //col.EnsureIndex(x => x.Name, true);

            // Insert new customer document (Id will be auto-incremented)
            col.Insert(user);

            // Update a document inside a collection
            user.Name = "Joana Doe";

            col.Update(user);

            // Use LINQ to query documents (will create index in Age field)
            var results = col.FindAll();

            foreach (var u in results) {
                Debug.Log(string.Format("{0} {1} {2} {3}", u.Id, u.Username, u.Password, u.Name));

            }

        }*/
        if (auto == null) {
            DB.Root(Application.streamingAssetsPath + "/Data");

            var db = new DB();

            db.GetConfig().EnsureTable<User>("Users", "Id");

            auto = db.Open();

            // max length is 20 , default is 32
            // db.GetConfig().EnsureTable<Item>("Items", "Name(20)");
        }

        var user = new User {
            Name = "Mike",
            Username = "Quadbro",
            Password = "1234",
            Id = auto.NewId(1)
        };
 
        auto.Insert("Users", user);

        foreach (var u in auto.Select<User>("from Users")) {
            Debug.Log(string.Format("{0} {1} {2} {3}", u.Id, u.Username, u.Password, u.Name));
        }

        /*
        using (var box = db.Cube()) {
            Member m = new Member();
            m.ID = box.newId(Member.IncTableID, 1);
            m.setName("Andy");
            m.setTags(new Object[] {"Nice", "Strong"});
            box.bind("Table").insert(m);

        }*/
        }


    protected override void OnStart() {
   
    }

    protected override void OnUpdate() {

    }
}

public class User {
    public long Id { get; set; }
    public string Name { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
}
