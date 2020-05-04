using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PriSchLecs.Api.Domains.BaseEntities;

namespace PriSchLecs.Api.Infrastructures.Services
{
    public static class CommonService
    {
        public static T UpdateCommonInt<T>(this T entity) where T : BaseEntityByInt
        {
            if (entity.Id > 0)
            {
                entity.UpdatedTime = DateTimeOffset.Now;
            }
            else
            {
                entity.UpdatedTime = entity.CreatedTime = DateTimeOffset.Now;
            }
            return entity;
        }

        public static T UpdateCommon<T>(this T entity) where T : BaseEntity
        {
            entity.UpdatedTime = entity.CreatedTime = DateTimeOffset.Now;
            return entity;
        }
    }
}
