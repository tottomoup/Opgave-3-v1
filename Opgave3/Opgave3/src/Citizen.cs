namespace Opgave3
{
    public class Citizen
    {
        private string _name;
        private int _age;
        private string _address;
        private string _MitID;
        private DirectDemocracySystem _system;

        public Citizen(string name, int age, string address, string _MitID)
        {
           _name = name;
           _age = age; 
           _address = address;
        }
        public void Register(DirectDemocracySystem system)
        {
            _system = system;
        }
        public void CastVote(Vote vote)
        {
            _system.VoteOnProposal(vote);
        }
    }
}