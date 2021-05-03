using MISA.BL.Interfaces;
using MISA.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class BaseBL<MISAEntity>:IBaseBL<MISAEntity>
    {
        public IEnumerable<MISAEntity> GetAll()
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.GetAll<MISAEntity>();
        }

        public MISAEntity GetById(Guid entityId)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.GetById<MISAEntity>(entityId);
        }

        public int Insert(MISAEntity entity)
        {
            Validate(entity);
            BaseDL baseDL = new BaseDL();
            return baseDL.Insert(entity);
        }

        public int Update(MISAEntity entity, Guid id)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.Update(entity, id);
        }

        public int Delete(Guid id)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.Delete<MISAEntity>(id);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        protected virtual void Validate(MISAEntity entity)
        {

        }
    }
}
