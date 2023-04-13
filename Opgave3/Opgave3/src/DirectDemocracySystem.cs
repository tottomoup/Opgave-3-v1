namespace Opgave3
{
    public class DirectDemocracySystem
    {
        private List<Citizen> _citizens = new List<Citizen>();
        private List<Proposal> _proposals = new List<Proposal>();

        public DirectDemocracySystem()
        {

        }
        public void RegisterCitizen(Citizen citizen)
        {
            _citizens.Add(citizen);
        }
        public void RemoveCitizen(Citizen citizen)
        {
            _citizens.Remove(citizen);
        }
        public void AuthenticateCitizen(Citizen citizen)
        {
            if(_citizens.Contains(citizen))
            {
                citizen.Register(this);
            }
        }
        public List<Proposal> GetProposals()
        {
            return _proposals;
        }

        public void SubmitProposal(Proposal proposal)
        {
            _proposals.Add(proposal);
        }
        public void VoteOnProposal(Vote vote)
        {
            vote.GetProposal().AddVote(vote);
        }
    }
}