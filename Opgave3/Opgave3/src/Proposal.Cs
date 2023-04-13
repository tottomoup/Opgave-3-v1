namespace Opgave3
{
public class Proposal
{
    private string _title;
    private string _description;
    private Citizen _proposer;
    private int _requiredVotes;
    private List<Vote> _votes = new List<Vote>();

   public Proposal(string title, string description, int requiredVotes, Citizen proposer)
   {
        _title = title;
        _description = description;
        _requiredVotes = requiredVotes;
        _proposer = proposer;

   }
    public void AddVote(Vote vote)
    {
        _votes.Add(vote);
    }
    
    public bool IsPassed()
    {
        int yesVotes = 0;
        foreach (Vote vote in _votes)
        {
            yesVotes++;
        }
        if(yesVotes > _requiredVotes)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
}