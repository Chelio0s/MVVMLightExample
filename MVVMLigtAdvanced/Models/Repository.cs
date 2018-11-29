using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace MVVMLigtAdvanced.Models
{
    class Repository : IRepository
    {
        /// <summary>
        /// Метод выбора коллекции сущностей по указнному условию предиката
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public List<T> GetEntityes<T>(Func<T, bool> predicate) where T : class
        {
            using (var context = new DataContext())
            {

                return context.Set<T>().Where(predicate).ToList();
            }
        }
        /// <summary>
        /// Метод выбора коллекции сущностей
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <returns></returns>
        public List<T> GetEntityes<T>() where T : class
        {
            using (var context = new DataContext())
            {
                var query = context.Set<T>();
                switch (typeof(T).Name)
                {
                    case "Employee": return query.Include("Post").ToList();
                    default: return context.Set<T>().ToList();
                }
            }
        }
        /// <summary>
        /// Метод добавления сущности в БД
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Объект сущности</param>
        public EntityEntry<T>  AddEntity<T>(T entity) where T : class
        {
            using (var context = new DataContext())
            {
                var adedEntity = context.Set<T>().Add(entity);
                context.SaveChanges();
                
                return adedEntity;
            }
        }
        /// <summary>
        /// Обновить сотрудника в БД
        /// </summary>
        /// <param name="employee"></param>
        /// <returns></returns>
        public bool UpdateEmployee(Employee employee)
        {
            if (!string.IsNullOrEmpty(employee.Name) && employee.Post != null)
            {
                using (var context = new DataContext())
                {
                    var emp = context.Employee.FirstOrDefault(x=>x.Id ==employee.Id);
                    var post = context.Post.FirstOrDefault(x => x.Id == employee.Post.Id);
                    if (emp != null)
                    {
                        emp.Name = employee.Name;
                        emp.Post = post;

                        context.SaveChanges();
                    }
                    return true;
                }
            }
            else return false;
        }
    }
}
