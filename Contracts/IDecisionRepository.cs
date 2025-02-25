namespace DecisionDeck.Contracts
{
    public interface IDecisionRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        int Add(T entity);
        void Update(T entity);
        void Delete(int id);
    }
}
