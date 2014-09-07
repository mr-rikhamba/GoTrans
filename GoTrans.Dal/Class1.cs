using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDb.Repository;

namespace GoTrans.Dal
{
    public class GenericDal<T> : IDal<T> where T : new()
    {
        private readonly MongoCollection<T> _collection;
        private readonly Connections _connection = new Connections();

        public GenericDal(string collectionName)
        {
            _collection = _connection.GetCollection<T>(collectionName);
        }

        public T Get(Func<T, bool> prediate)
        {
            return _collection.FindAll().FirstOrDefault(prediate);
        }

        public List<T> GetMany(Func<T, bool> prediate)
        {
            return _collection.FindAll().Where(prediate).ToList();
        }

        public T Save(T model)
        {
            if ((ObjectId)model.GetType().GetProperty("_id").GetValue(model) == ObjectId.Empty)
            {
                _collection.Save(model);
            }
            else
            {
                _collection.Insert(_collection);
            }
            return model;
        }

        public List<T> SaveMany(List<T> models)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            return _collection.FindAll().ToList();
        }
    }
}
