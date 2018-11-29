using System;
using System.Collections.Generic;


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
        T AddEntity<T>(T entity) where T : class;

        bool UpdateEmployee(Employee employee);
    }
}
