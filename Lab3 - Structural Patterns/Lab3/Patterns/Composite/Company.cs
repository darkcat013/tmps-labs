namespace Lab3.Patterns.Composite
{
    public class Company : IOwnership
    {
        public string Name { get; init; }
        public string Address { get; init; }
        public List<IOwnership> Ownerships { get; init; }
        public string GetFullInfo()
        {
            string ownershipInfos = "";
            foreach (var ownership in Ownerships)
            {
                ownershipInfos += ownership.GetShortInfo() + "\n";
            }
            return $"{nameof(Company)} {Name} at address {Address} owns : \n {ownershipInfos}"; 
        }
        public string GetShortInfo()
        {
            return $"{nameof(Company)} name: {Name} \n Address: {Address}";
        }

        public void AddOwnership(IOwnership ownership)
        {
            Ownerships.Add(ownership);
        }
    }
}
