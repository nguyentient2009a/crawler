using System.Collections.Generic;
using Raw.entity;
using Raw.helper;

namespace Raw.model
{
    public class AnimalModelMySQLImplement: AnimalModel
    {
         public bool Save(Animal obj)
        {
            var cnn = DbConnectionHelper.GetConnection();
            var mySqlCommand = cnn.CreateCommand();
            mySqlCommand.CommandText = $"insert into animals " +
                                       $"(Id, Name)" +
                                       $" values " +
                                       $"(@Id, @Name) ";
            mySqlCommand.Parameters.AddWithValue("@Id", obj.Id);
            mySqlCommand.Parameters.AddWithValue("@Name", obj.Name);
            var result = mySqlCommand.ExecuteNonQuery();
            cnn.Close();
            return result == 1;
        }
        
        public Animal FindById(int id)
        {
            Animal result = null;
            var cnn = DbConnectionHelper.GetConnection();
            var mySqlCommand = cnn.CreateCommand();
            mySqlCommand.CommandText = $"select * from `animals` where Id = {id}";
            var reader = mySqlCommand.ExecuteReader();
            if (reader.Read())
            {
                result = new Animal();
                result.Id = reader.GetInt32("Id");
                result.Name = reader.GetString("Name");                
            }
            reader.Close();
            cnn.Close();
            return result;
        }
        
        public List<Animal> FindAll()
        {
            var list = new List<Animal>();
            var cnn = DbConnectionHelper.GetConnection();
            var mySqlCommand = cnn.CreateCommand();
            mySqlCommand.CommandText = $"select * from `animals`";
            var reader = mySqlCommand.ExecuteReader();
            while (reader.Read())
            {
                var obj = new Animal();
                obj.Id = reader.GetInt32("Id");
                obj.Name = reader.GetString("Name");
                list.Add(obj);
            }
            reader.Close();
            cnn.Close();
            return list;
        }

        public bool Update(int id, Animal updateAccount)
        {
            var existing = FindById(id);
            if (existing == null)
            {
                return false;
            }
            existing.Name = updateAccount.Name;
            var cnn = DbConnectionHelper.GetConnection();
            var mySqlCommand = cnn.CreateCommand();
            mySqlCommand.CommandText = $"update animals " +
                                       $"set Name = '{existing.Name}'" +
                                       $" where Id = {existing.Id}";
            var result = mySqlCommand.ExecuteNonQuery();
            cnn.Close();
            return result == 1;
        }

        public bool Delete(int id)
        {
            var existing = FindById(id);
            if (existing == null)
            {
                return false;
            }
            var cnn = DbConnectionHelper.GetConnection();
            var mySqlCommand = cnn.CreateCommand();
            mySqlCommand.CommandText = $"delete from animals where Id = {id}";
            var result = mySqlCommand.ExecuteNonQuery();
            cnn.Close();
            return result == 1;
        }
    }
}