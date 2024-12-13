namespace Trabalho_Pratico_26752.Classes
{
    public interface IAssistanceManager
    {
        void AssignAssistance(Assistance assistance);
        void CloseAssistance(Assistance assistance, bool resolved);
    }
}
