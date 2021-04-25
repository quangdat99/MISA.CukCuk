using MISA.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.BL
{
    public class BaseBL
    {
        public IEnumerable<MISAEntity> GetAll<MISAEntity>()
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.GetAll<MISAEntity>();
        }

        public MISAEntity GetById<MISAEntity>(Guid entityId)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.GetById<MISAEntity>(entityId);
        }

        public int Insert<MISAEntity>(MISAEntity entity)
        {
            Validate<MISAEntity>(entity);
            BaseDL baseDL = new BaseDL();
            return baseDL.Insert<MISAEntity>(entity);
        }

        public int Update<MISAEntity>(MISAEntity entity, Guid id)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.Update(entity, id);
        }

        public int Delete<MISAEntity>(Guid id)
        {
            BaseDL baseDL = new BaseDL();
            return baseDL.Delete<MISAEntity>(id);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="MISAEntity"></typeparam>
        /// <param name="entity"></param>
        protected virtual void Validate<MISAEntity>(MISAEntity entity)
        {

        }
    }
}
