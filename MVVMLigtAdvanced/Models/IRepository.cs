using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;


namespace MVVMLigtAdvanced.Models
{
    public interface IRepository
    {
        /// <summary>
        /// Метод выбора коллекции сущностей по указнному условию предиката
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <returns></returns>
        List<T> GetEntityes<T>(Func<T, bool> predicate) where T : class;

        /// <summary>
        /// Метод выбора коллекции сущностей
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <returns></returns>
        List<T> GetEntityes<T>() where T : class;

        /// <summary>
        /// Метод добавления сущности в БД
        /// </summary>
        /// <typeparam name="T">Тип сущности</typeparam>
        /// <param name="entity">Объект сущности</param>
        EntityEntry<T> AddEntity<T>(T entity) where T : class;

        /// <summary>
        /// Обновление сотрудника
        /// </summary>
        /// <param name="employee111"></param>
        /// <returns></returns>
        bool UpdateEmployee(Employee employee111);
    }
}
