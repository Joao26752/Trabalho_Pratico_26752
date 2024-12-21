namespace Trabalho_Pratico_26752.Classes
{
    public interface IAssistanceManager
    {
        void AssignToOperator(Assistance assistance, Operator op);
        void CloseAssistance(Assistance assistance, bool resolved);
        void ResolveAssistance(Assistance assistance, bool resolved, int rating);
        void RejectAssistance(Assistance assistance);
    }
}
