using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;
using UnityEditor;
using Mono.Data.Sqlite;
using System.Data;
using System.Globalization;
public class Database : MonoBehaviour
{
    public List<string> characterNamesHolder = new List<string>();
    public int tablelength;

    public static void Main()
    {
/*        string fileName = "testme.sqlite3";
        string sourcePath = @"C:\Users\cattoy\Documents\Python Projects\loreapi\loreapi\";
        string targetPath = @"C:\Users\cattoy\Documents\Unity Projects\Lore\unitylore\Lore\Assets\DB";
        string relativePath = @"C: \Users\cattoy\Documents\Python Projects\loreapi\loreapi\testme.sqlite3";*/

        // use path class to manipulate file and directory paths
/*        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);*/
    }

    public void Start()
    {
        string fileName = "db.sqlite3";
        string sourcePath = @"C:\Users\cattoy\Documents\Python Projects\loreapi\loreapi\";
        string targetPath = @"C:\Users\cattoy\Documents\Unity Projects\Lore\unitylore\Lore\Assets\DB";
        var relativePath = "Assets/DB/db.sqlite3";

        // use path class to manipulate file and directory paths
        string sourceFile = System.IO.Path.Combine(sourcePath, fileName);
        string destFile = System.IO.Path.Combine(targetPath, fileName);

        IDbCommand dbcmd;

        //To copy folder's content to a new location create target folder. If the directory already exists than this does nothing.
        /*System.IO.Directory.CreateDirectory(targetPath);*/

        //To copy a file to another location and overwrite it if it already exists.
        System.IO.File.Copy(sourceFile, destFile, true);
        AssetDatabase.ImportAsset(relativePath);

        string connection = "URI=file:/Users/cattoy/Documents/Unity Projects/Lore/unitylore/Lore/Assets/DB/db.sqlite3";
        IDbConnection dbcon = new SqliteConnection(connection);
        //dbcon.ConnectionString = destFile;
        dbcon.Open();
        //IDbCommand cmnd_read = dbcon.CreateCommand();
        
        string length = "SELECT COUNT(id) FROM 'lore_lore'";
        string tlength = GetLength(length);
        //public variable
        tablelength = int.Parse(tlength);
        System.Random rnd = new System.Random();
        int random_character = rnd.Next(2, tablelength + 2);
        //Debug.Log(random_character + "int random character");

        IDbCommand cmd = dbcon.CreateCommand();
        var parameter = cmd.CreateParameter();
        parameter.ParameterName = "@random_character";
        parameter.Value = random_character;
        cmd.Parameters.Add(parameter);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "SELECT * FROM 'lore_lore' WHERE id = @random_character";

        IDbCommand putnamesinlist = dbcon.CreateCommand();
        putnamesinlist.CommandType = CommandType.Text;
        putnamesinlist.CommandText = "SELECT firstname FROM 'lore_lore'";
        //Debug.Log(tablelength + "table length");




        //string query = $"SELECT * FROM 'lore_lore'";


        IDataReader reader;
        //cmnd_read.CommandText = query;
/*        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("created: " + reader[1].ToString());
            Debug.Log("title: " + reader[2].ToString());
            Debug.Log("firstname: " + reader[3].ToString());
            Debug.Log("owner_id: " + reader[5].ToString());
            Debug.Log("id: " + reader[0].ToString());
            Debug.Log("firstname: " + reader[3].ToString());

        }
        reader.Close();*/

        reader = putnamesinlist.ExecuteReader();
        while (reader.Read())
        {
            characterNamesHolder.Add(reader["firstname"].ToString());
/*            for (var x = 0; x < tablelength - 1; x++)
            {
*//*                Debug.Log(reader["firstname"].ToString());*/
                /*characterNamesHolder.Add(reader.GetValue(reader.GetOrdinal("firstname")).ToString());*/
                /*                characterNamesHolder.Add(reader[x].ToString());*//*
                
            }*/
        }

        reader.Close();


        // Close connection
        dbcon.Close();
/*        foreach(string x in characterNamesHolder)
        {
            Debug.Log(x + "hehe");
        }*/
        
    }

    public string GetLength(string query)
    {
        string result = "";
        string connection = "URI=file:/Users/cattoy/Documents/Unity Projects/Lore/unitylore/Lore/Assets/DB/db.sqlite3";
        IDbConnection dbcon = new SqliteConnection(connection);
        //dbcon.ConnectionString = destFile;
        dbcon.Open();
        IDbCommand cmd = dbcon.CreateCommand();
        cmd.CommandText = query;
        result = cmd.ExecuteScalar().ToString();
        dbcon.Close();
        return result;
    }
}

