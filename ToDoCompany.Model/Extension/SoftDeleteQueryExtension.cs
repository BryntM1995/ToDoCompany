using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using ToDoCompany.Model.Entities;

namespace ToDoCompany.Model.Extension
{
    public static class SoftDeleteQueryExtension
    {
        public static void AddSoftDeleteQueryFilter(
         this IMutableEntityType entityData)
        {
            var methodToCall = typeof(SoftDeleteQueryExtension)
                .GetMethod(nameof(GetSoftDeleteFilter),
                    BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(entityData.ClrType);
            var filter = methodToCall.Invoke(null, new object[] { });
            entityData.SetQueryFilter((LambdaExpression)filter);
            entityData.AddIndex(entityData.
                 FindProperty(nameof(IBaseEntity.IsDeleted)));
        }

        private static LambdaExpression GetSoftDeleteFilter<Entity>()
            where Entity : class, IBaseEntity
        {
            Expression<Func<Entity, bool>> filter = x => !x.IsDeleted;
            return filter;
        }
    }
}
