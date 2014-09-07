using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoTrans.Dal;
using GoTrans.Model;

namespace GoTrans.Bll
{
    public class LocationHistoryBll : BusinessLogic.IBusinessLogic<Model.LocationHistoryModel>
    {
        GenericDal<LocationHistoryModel> genericDal = new GenericDal<LocationHistoryModel>("LocationHistory");
        public override bool Validate(LocationHistoryModel model)
        {
            throw new NotImplementedException();
        }

        public override LocationHistoryModel Get(Func<LocationHistoryModel, bool> prediate)
        {
            var items = genericDal.Get(prediate);
            return items;
        }

        public override List<LocationHistoryModel> GetMany(Predicate<LocationHistoryModel> prediate)
        {
            throw new NotImplementedException();
        }

        public override LocationHistoryModel Save(LocationHistoryModel model)
        {
            genericDal.Save(model);
            return model;
        }

        public override List<LocationHistoryModel> SaveMany(List<LocationHistoryModel> models)
        {
            throw new NotImplementedException();
        }

        public override List<LocationHistoryModel> GetAll()
        {
            return genericDal.GetAll();
        }
    }
}
