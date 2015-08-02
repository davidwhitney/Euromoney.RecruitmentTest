using NegativeContentManager.DTO;

namespace NegativeContentManager.Interfaces
{
  public interface IContentManager
  {
    UserState Manage(UserState value);
  }
}
