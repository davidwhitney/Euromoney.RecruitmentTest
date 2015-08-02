namespace NegativeContentManager.Interfaces
{
  public interface INegativeWordsManager<T1, T2>
  {
    T1 Manage(T2 userState);
  }
}
