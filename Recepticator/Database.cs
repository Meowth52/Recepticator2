using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Recepticator
{
    public class Database
    {
        SQLiteConnection SqlConnection;
        public Database()
        {
            if (!System.IO.File.Exists("RecepticatorDb.sqlite"))
            {
                SQLiteConnection.CreateFile("RecepticatorDb.sqlite");
            }
            SqlConnection = new SQLiteConnection("Data Source=RecepticatorDb.sqlite;Version=3;");
            SqlConnection.Open();
            SQLiteCommand Command = SqlConnection.CreateCommand();
            Command.CommandText = "CREATE TABLE Ingridients(Id integer PRIMARY KEY AUTOINCREMENT, Name varchar, UnitId integer, DefaultPicked boolean); CREATE TABLE Recipes(Id integer PRIMARY KEY AUTOINCREMENT, Name varchar, ActiveInstructionId integer ); CREATE TABLE Instructions(Id integer PRIMARY KEY AUTOINCREMENT, PreviousId integer, NextId integer, RecipeId integer, Text text, TimerAmount integer); CREATE TABLE IngridientToRecipe(IngridientId integer, RecipeId integer, Amount float); CREATE TABLE Units(Id integer PRIMARY KEY AUTOINCREMENT, Name varchar); CREATE TABLE Lists(Id integer, Description varchar); CREATE TABLE IngridientToList(IngridientId integer, ListId integer, Amount float, Done boolean); CREATE TABLE SiUnit(Id integer PRIMARY KEY AUTOINCREMENT, Name varchar); CREATE TABLE UnitRelation(SiUnitId integer, UnitId integer, UnitsPerSiUnit float); ";
            Command.ExecuteNonQuery();
            SqlConnection.Close();
        }
    }
}
