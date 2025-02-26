﻿namespace DecisionDeck.Contracts
{
    public interface IDecisionRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
