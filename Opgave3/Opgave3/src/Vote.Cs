namespace Opgave3
{
public class Vote
{
    private Proposal _proposal;
    private Citizen _citizen;
    private bool _choice;

    public Vote(Proposal proposal, Citizen voter, bool choice)
    {
        _proposal = proposal;
        _citizen = voter;
        _choice = choice;
    }
    public bool GetChoice()
    {
        return _choice;
    }

    public Citizen GetCitizen()
    {
        return _citizen;
    }

    public Proposal GetProposal()
    {
        return _proposal;
    }
}
}